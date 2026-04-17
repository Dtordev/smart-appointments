using Dapper;
using Microsoft.EntityFrameworkCore;
using SmartAppointments.Application.DTOs.Common;
using SmartAppointments.Application.Interfaces.Repositories;
using SmartAppointments.Infrastructure.Data;
using System.Data;

namespace SmartAppointments.Infrastructure.Repositories
{
    public class ArchivoRepository : IArchivoRepository
    {
        private readonly AppDbContext _db;

        public ArchivoRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<GeneralesDTO>> Estados(int tipo)
        {
            var connection = _db.Database.GetDbConnection();

            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();

            return await connection.QueryAsync<GeneralesDTO>(
                "spTipoEstado_Estados",
                new { TipoEstado = tipo },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
