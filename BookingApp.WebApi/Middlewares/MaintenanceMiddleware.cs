using BookingApp.Business.Operations.Setting;

namespace BookingApp.WebApi.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;


        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var settingService = context.RequestServices.GetRequiredService<ISettingService>();
            bool maintananceMode = settingService.GetMaintenanceState();

            if (context.Request.Path.StartsWithSegments("/api/auth/login") ||
                context.Request.Path.StartsWithSegments("/api/settings"))
            {
                await _next(context);
                return;
            }


            if (maintananceMode)
            {
                await context.Response.WriteAsync("Şu anda hizmet verememekteyiz.");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
