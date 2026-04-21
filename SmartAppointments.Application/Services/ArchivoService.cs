using SmartAppointments.Application.DTOs.Common;
using SmartAppointments.Application.Interfaces.Repositories;
using SmartAppointments.Application.Interfaces.Services;

namespace SmartAppointments.Application.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly IArchivoRepository _repository;

        public ArchivoService(IArchivoRepository repository)
        {
            _repository = repository;
        }


        #region Generales
        public async Task<ApiResponse<IEnumerable<GeneralesDTO>>> Estados(int tipo)
        {
            var data = await _repository.Estados(tipo);

            return new ApiResponse<IEnumerable<GeneralesDTO>>
            {
                Success = true,
                Data = data,
                Message = "Estados obtenidos correctamente"
            };
        }
        public async Task<ApiResponse<IEnumerable<GeneralesDTO>>> Obtener_Paises()
        {
            var data = await _repository.Obtener_Paises();

            return new ApiResponse<IEnumerable<GeneralesDTO>>
            {
                Success = true,
                Data = data,
                Message = "Paises obtenidos correctamente"
            };
        }
        public async Task<ApiResponse<IEnumerable<GeneralesDTO>>> Especialidades()
        {
            var data = await _repository.Especialidades();

            return new ApiResponse<IEnumerable<GeneralesDTO>>
            {
                Success = true,
                Data = data,
                Message = "Especialidades obtenidas correctamente"
            };
        }
        public async Task<ApiResponse<(IEnumerable<GeneralesDTO> Profesionales, IEnumerable<GeneralesDTO> Entidades)>> ProfesionalyEntidad(int id_persona)
        {
            var data = await _repository.ProfesionalyEntidad(id_persona);

            return new ApiResponse<(IEnumerable<GeneralesDTO> Profesionales, IEnumerable<GeneralesDTO> Entidades)>
            {
                Success = true,
                Data = data,
                Message = "Información obtenida correctamente"
            };
        }
        public async Task<ApiResponse<IEnumerable<GeneralesDTO>>> PosiblesHoras()
        {
            var data = await _repository.PosiblesHoras();

            return new ApiResponse<IEnumerable<GeneralesDTO>>
            {
                Success = true,
                Data = data,
                Message = "Horas obtenidas correctamente"
            };
        }

        #endregion
    }
}
