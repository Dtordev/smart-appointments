using Dapper;
using SmartAppointments.Application.DTOs.Common;
using SmartAppointments.Application.Interfaces.Repositories;
using SmartAppointments.Infrastructure.Data;
using System.Data;

namespace SmartAppointments.Infrastructure.Repositories
{
    public class ArchivoRepository : BaseRepository, IArchivoRepository
    {
        private readonly AppDbContext _db;

        public ArchivoRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<GeneralesDTO>> Estados(int tipo)
        {
            var connection = await GetConnection(_db);

            return await connection.QueryAsync<GeneralesDTO>(
                "spTipoEstado_Estados",
                new { TipoEstado = tipo },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
