using Dapper;
using HahnSoftwareCrud.Domain.Entities;
using HahnSoftwareCrud.Domain.Repository;
using HahnSoftwareCrud.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const int Timeout = 30;
        private const string CREATE_ITEM_SQL_COMMAND = "Insert into Items (name,quantity) values (@name, @quantity); SELECT LAST_INSERT_ID()";
        private const string UPDATE_ITEM_SQL_COMMAND = "Update Items set name = @name ,quantity = @quantity Where id = @id";
        private const string DELETE_ITEM_SQL_COMMAND = "Delete from Items Where id = @id";
        private const string GET_ITEM_SQL_QUERY = "Select id, name, quantity from Items where id = @id";
        private const string LIST_ITEMS_SQL_QUERY = "Select id, name, quantity from Items";



        private readonly IMysqlRepository _mysqlRepository;
        public ItemRepository(IMysqlRepository mysqlRepository)
        {
            _mysqlRepository = mysqlRepository;
        }

        public async Task<int> CreateItem(Item item, CancellationToken cancellationToken)
        {
            var parms = new DynamicParameters();
            parms.Add("@name", item.Name, DbType.AnsiString);
            parms.Add("@quantity", item.Quantity, DbType.Int64);

            var commandDefinition = new CommandDefinition(CREATE_ITEM_SQL_COMMAND, parms, commandTimeout: Timeout, cancellationToken: cancellationToken);

            return await _mysqlRepository.QueryFirstOrDefaultAsync<int>(commandDefinition);
        }

        public async Task UpdateItem(Item item, CancellationToken cancellationToken)
        {
            var parms = new DynamicParameters();
            parms.Add("@id", item.Id, DbType.Int64);
            parms.Add("@name", item.Name, DbType.AnsiString);
            parms.Add("@quantity", item.Quantity, DbType.Int64);

            var commandDefinition = new CommandDefinition(UPDATE_ITEM_SQL_COMMAND, parms, commandTimeout: Timeout, cancellationToken: cancellationToken);

            await _mysqlRepository.ExecuteAsync(commandDefinition);
        }

        public async Task DeleteItem(int id, CancellationToken cancellationToken)
        {
            var parms = new DynamicParameters();
            parms.Add("@id", id, DbType.Int64);

            var commandDefinition = new CommandDefinition(DELETE_ITEM_SQL_COMMAND, parms, commandTimeout: Timeout, cancellationToken: cancellationToken);

            await _mysqlRepository.ExecuteAsync(commandDefinition);
        }

        public async Task<Item?> GetItemById(int id, CancellationToken cancellationToken)
        {
            var parms = new DynamicParameters();
            parms.Add("@id", id, DbType.Int64);

            var commandDefinition = new CommandDefinition(GET_ITEM_SQL_QUERY, parms, commandTimeout: Timeout, cancellationToken: cancellationToken);

            return await _mysqlRepository.QueryFirstOrDefaultAsync<Item>(commandDefinition);
        }

        public async Task<List<Item>> ListItems(CancellationToken cancellationToken)
        {
            var commandDefinition = new CommandDefinition(LIST_ITEMS_SQL_QUERY, commandTimeout: Timeout, cancellationToken: cancellationToken);

            return (await _mysqlRepository.QueryAsync<Item>(commandDefinition)).ToList();
        }
    }
}
