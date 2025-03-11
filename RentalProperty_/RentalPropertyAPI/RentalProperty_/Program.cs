using RentalProperty_.Data;
using Microsoft.AspNetCore.Authentication;

using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using RentalProperty_.Helper.Auth;
using RentalProperty_.Services;
using RentalProperty_.Helper.Auth;
using RentalProperty_.Services;

var config = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", false)
	.Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(config.GetConnectionString("DefaultConnection")));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<AutorizacijaSwaggerHeader>());
builder.Services.AddTransient<MyAuthService>();
builder.Services.AddTransient<MyActionLogService>();
builder.Services.AddTransient<MyEmailSenderService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(
	options => options
		.SetIsOriginAllowed(x => _ = true)
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials()
); //This needs to set everything allowed


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
