using SmartAppointments.Application.DTOs.Common;

namespace SmartAppointments.Application.Interfaces.Repositories
{
    public interface IArchivoRepository
    {
        Task<IEnumerable<GeneralesDTO>> Estados(int tipo);
    }
}
