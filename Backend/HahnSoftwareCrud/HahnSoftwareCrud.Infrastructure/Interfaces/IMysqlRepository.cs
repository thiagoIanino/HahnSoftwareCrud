using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Infrastructure.Interfaces
{
    public interface IMysqlRepository
    {
        Task ExecuteAsync(CommandDefinition commandDefinition);

        Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition commandDefinition);

        Task<T?> QueryFirstOrDefaultAsync<T>(CommandDefinition commandDefinition);
    }
}
