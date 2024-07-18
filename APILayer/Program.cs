using DBAccess.DBAccessPoint;
using DBAccess.DBControllers;
using LogicLayer.APIDeleteLogic;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using LogicLayer.DBDeleteLogic;
using LogicLayer.Validation;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation.ValueValidations;


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
builder.Services.AddTransient<IAPIPostHandler, APIPostHandler>();
builder.Services.AddTransient<IIdValidation, IdValidation>();
builder.Services.AddTransient<IDBDeleteHandler, DBDeleteHandler>();
builder.Services.AddTransient<IAPIDeleteHandlers, APIDeleteHandlers>();
builder.Services.AddTransient<ICheckIfNameExists, CheckIfNameExists>();
builder.Services.AddTransient<IValueValidations, ValueValidations>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
