using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Application.Interfaces.Services
{
    public interface IArchivoService
    {


        #region Generales
        Task<ApiResponse<IEnumerable<GeneralesDTO>>> Estados(int tipo);
        Task<ApiResponse<IEnumerable<GeneralesDTO>>> Obtener_Paises();
        Task<ApiResponse<IEnumerable<GeneralesDTO>>> Especialidades();
        Task<ApiResponse<(IEnumerable<GeneralesDTO> Profesionales, IEnumerable<GeneralesDTO> Entidades)>> ProfesionalyEntidad(int id_persona);
        Task<ApiResponse<IEnumerable<GeneralesDTO>>> PosiblesHoras();

        #endregion
    }
}
