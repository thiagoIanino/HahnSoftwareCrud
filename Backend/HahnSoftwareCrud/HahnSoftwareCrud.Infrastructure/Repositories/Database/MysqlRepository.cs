using Dapper;
using HahnSoftwareCrud.Infrastructure.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Infrastructure.Repositories.Database
{
    public class MysqlRepository : IMysqlRepository
    {
        public IDbConnection Connection { get; }

        public MysqlRepository() {
            Connection = GetMysqlConnection();
        }

        public async Task ExecuteAsync(CommandDefinition commandDefinition)
        {
            using (var conn = Connection) 
            {
                await conn.ExecuteAsync(commandDefinition);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition commandDefinition)
        {
            using (var conn = Connection)
            {
                return await conn.QueryAsync<T>(commandDefinition);
            }
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(CommandDefinition commandDefinition)
        {
            using (var conn = Connection)
            {
                 return await conn.QueryFirstOrDefaultAsync<T>(commandDefinition);
            }
        }

        private static IDbConnection GetMysqlConnection()
        {
            return new MySqlConnection("Server=127.0.0.1;Port=3306;Database=hahnSoftware;Uid=root;Pwd=hard_password;");
        }

    }
}
