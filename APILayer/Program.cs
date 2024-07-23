using DBAccess.DBAccessPoint;
using DBAccess.DBControllers;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;
using Microsoft.Extensions.Configuration;
using LogicLayer.DBLogic;
using LogicLayer.APILogic;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builder => builder.WithOrigins("http://localhost:4200")
		.AllowAnyMethod()
		.AllowCredentials()
		.AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Dependency Injection Services
builder.Services.AddTransient<IDBCardAccess, DBCardAccess>();
builder.Services.AddTransient<IAvailableCardsController, AvailableCardsController>();
builder.Services.AddTransient<IIDValidations, IDValidations>();
builder.Services.AddTransient<ICheckIfNameExists, CheckIfNameExists>();
builder.Services.AddTransient<IValueValidations, ValueValidations>();
builder.Services.AddTransient<IDBLogicHandlers, DBLogicHandlers>();
builder.Services.AddTransient<ILogger>(s => s.GetRequiredService<ILogger<Program>>());
builder.Services.AddTransient<IAPILogicHandlers, APILogicHandlers>();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeckBuildAPI"));

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
