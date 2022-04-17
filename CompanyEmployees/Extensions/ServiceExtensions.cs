using System;
namespace CompanyEmployees.Extensions
{
	public static class ServiceExtensions
	{
		// CORS cross-origin resource sharing

		// AllowAnyOrigin -> WithOrigins("example.com")
		// AllowAnyMethod -> WithMethods("POST", "GET")
		// AllowAnyHeader -> WithHeaders("accept", "content-type")

		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options => {
				options.AddPolicy("CorsPolicy", builder =>
					builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});

		public static void ConfigureIISIntegration(this IServiceCollection services) =>
			services.Configure<IISOptions>(options => { });
	}
}