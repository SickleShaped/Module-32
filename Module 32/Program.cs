namespace Module_32
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            var env = app.Environment;
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapGet("/", () => "Hello World!");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/config", async context =>
                {
                    await context.Response.WriteAsync($"App name: {env.ApplicationName}. App running configuration: {env.EnvironmentName}");
                });
            });

            // Завершим вызовом метода Run
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!");
            });
        }
    }
}
