using DBAccess.DBAccessPoint;
using DBAccess.DBControllers;
using LogicLayer.APIDeleteLogic;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using LogicLayer.DBDeleteLogic;
using LogicLayer.DBGetLogic;
using LogicLayer.DBPostLogic;
using LogicLayer.Validation.IDValidationsForPost;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection Services
builder.Services.AddTransient<IDBCardAccess, DBCardAccess>();
builder.Services.AddTransient<IAvailableCardsController, AvailableCardsController>();
builder.Services.AddTransient<IDBGetHandlers, DBGetHandlers>();
builder.Services.AddTransient<IDBPostHandlers, DBPostHandlers>();
builder.Services.AddTransient<IAPIGetHandlers, APIGetHandlers>();
builder.Services.AddTransient<IAPIPostHandlers, APIPostHandlers>();
builder.Services.AddTransient<IIDValidations, IDValidations>();
builder.Services.AddTransient<IDBDeleteHandlers, DBDeleteHandlers>();
builder.Services.AddTransient<IAPIDeleteHandler, APIDeleteHandler>();
builder.Services.AddTransient<ICheckIfNameExists, CheckIfNameExists>();
builder.Services.AddTransient<IValueValidations, ValueValidations>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", 
		builder => builder.WithOrigins("deckbuilderdemo.azurewebsites.net")
		.AllowAnyMethod()
		.AllowCredentials()
		.AllowAnyHeader());
});

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
