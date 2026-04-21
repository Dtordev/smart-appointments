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
        private readonly AppDbContextPro _dbpro;

        public ArchivoRepository(AppDbContext context, AppDbContextPro contextPro)
        {
            _db = context;
            _dbpro = contextPro;
        }


        #region Generales
        public async Task<IEnumerable<GeneralesDTO>> Estados(int tipo)
        {
            var connection = await GetConnection(_db);

            return await connection.QueryAsync<GeneralesDTO>(
                "spTipoEstado_Estados",
                new { TipoEstado = tipo },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<GeneralesDTO>> Obtener_Paises()
        {
            var connection = await GetConnection(_dbpro);

            return await connection.QueryAsync<GeneralesDTO>(
                "spObtener_Paises",
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<IEnumerable<GeneralesDTO>> Especialidades()
        {
            var connection = await GetConnection(_db);

            return await connection.QueryAsync<GeneralesDTO>(
                "spSunem_Profesional_SucursalesyEspecialidades",
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<(IEnumerable<GeneralesDTO> Profesionales, IEnumerable<GeneralesDTO> Entidades)> ProfesionalyEntidad(int id_persona)
        {
            var connection = await GetConnection(_db);

            using var multi = await connection.QueryMultipleAsync(
                "spSunemPro_Usu_ProfesionalyEntidad",
                new { Id_Persona = id_persona },
                commandType: CommandType.StoredProcedure
            );

            var profesionales = await multi.ReadAsync<GeneralesDTO>();
            var entidades = await multi.ReadAsync<GeneralesDTO>();

            return (profesionales, entidades);
        }
        public async Task<IEnumerable<GeneralesDTO>> PosiblesHoras()
        {
            var connection = await GetConnection(_db);

            return await connection.QueryAsync<GeneralesDTO>(
                "spSunemPro_Usuarios_PosiblesHoras",
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion
    }
}
