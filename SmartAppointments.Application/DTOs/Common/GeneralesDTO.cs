namespace SmartAppointments.Application.DTOs.Common
{
    public class GeneralesDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public long Id_Long { get; set; }
        public int Estado { get; set; }
    }

    public class FechasDTO
    {
        public string? Fechastr { get; set; }
        public string? Fecha_Aumentada { get; set; }
    }
}
