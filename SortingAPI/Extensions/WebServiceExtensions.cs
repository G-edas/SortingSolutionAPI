namespace SortingAPI.Extensions
{
    public static class WebServiceApplication
    {
        public static void Configure(this WebApplication app, IConfiguration config)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(
                        config =>
                        {
                            config.SwaggerEndpoint("/swagger/v1/swagger.json", "Sorting API");
                        }
                    );
            }
            app.MapControllers();
        }
    }
}
