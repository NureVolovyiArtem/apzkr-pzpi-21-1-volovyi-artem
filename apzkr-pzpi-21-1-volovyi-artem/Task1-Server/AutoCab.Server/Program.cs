using System.Reflection;
using AutoCab.Db;
using AutoCab.Server.BuildInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSetSwagger();
builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddLogging();
builder.Services.AddServices();
builder.Services.AddSetSecurity(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddDbSetup(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors(CorsInjection.PolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();