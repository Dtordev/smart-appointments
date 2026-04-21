using Scalar.AspNetCore;
using SmartAppointments.Api.Middleware;

namespace SmartAppointments.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication UseProjectMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("Api | Documentation")
                        .WithTheme(ScalarTheme.DeepSpace);
                });
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
