using Microsoft.EntityFrameworkCore;
using RentalProperty_.Data;

namespace RentalProperty_
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// Setup DbContext with SQL Server
			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddLogging();
			// Add controllers

			services.AddControllers();

			// Register Swagger
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "RentalProperty API",
					Version = "v1"
				});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseHttpsRedirection();

			// Swagger configuration
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentalProperty API V1");
			});

			// CORS
			app.UseCors(options => options
				.SetIsOriginAllowed(x => _ = true)
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials());

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});
		}
	}
}
