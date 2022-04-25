using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using KingdomServerManager.BusinessLayer.MapperProfiles;
using KingdomServerManager.BusinessLayer.Services;
using KingdomServerManager.BusinessLayer.Validators;
using KingdomServerManager.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TinyHelpers.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddProblemDetails();
services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<SaveUserRequestValidator>();
});
services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new UtcDateTimeConverter());
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<DataContext>(options =>
{
    var configuration = builder.Configuration;
    var connectionString = configuration.GetConnectionString("SqlConnection");
    options.UseSqlServer(connectionString);
});
services.AddScoped<IDataContext>(sp => sp.GetRequiredService<DataContext>());
services.AddScoped<IReadOnlyDataContext>(sp => sp.GetRequiredService<DataContext>());
services.AddScoped<IRolesService, RolesService>();
services.AddScoped<IUsersService, UsersService>();
services.AddScoped<IServerLogsService, ServerLogsService>();

var app = builder.Build();
app.UseProblemDetails();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();