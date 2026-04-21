using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Application.Interfaces.Repositories
{
    public interface IArchivoRepository
    {


        #region Generales
        Task<IEnumerable<GeneralesDTO>> Estados(int tipo);
        Task<IEnumerable<GeneralesDTO>> Obtener_Paises();
        Task<IEnumerable<GeneralesDTO>> Especialidades();
        Task<(IEnumerable<GeneralesDTO> Profesionales, IEnumerable<GeneralesDTO> Entidades)> ProfesionalyEntidad(int id_persona);
        Task<IEnumerable<GeneralesDTO>> PosiblesHoras();

        #endregion
    }
}
