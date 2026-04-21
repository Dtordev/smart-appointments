using Microsoft.EntityFrameworkCore;

namespace SmartAppointments.Infrastructure.Data
{
    public class AppDbContextPro : DbContext
    {
        public AppDbContextPro(DbContextOptions<AppDbContextPro> options) : base(options)
        {

        }
    }
}
