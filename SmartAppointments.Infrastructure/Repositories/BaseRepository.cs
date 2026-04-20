using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SmartAppointments.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected async Task<IDbConnection> GetConnection(DbContext context)
        {
            var connection = context.Database.GetDbConnection();

            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();

            return connection;
        }
    }
}
