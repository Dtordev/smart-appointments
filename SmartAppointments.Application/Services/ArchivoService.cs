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

        public async Task<IEnumerable<GeneralesDTO>> Estados(int tipo)
        {
            var data = await _repository.Estados(tipo);

            return data;
        }
    }
}
