using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddScoped<ICSVService, CSVService>()
    .AddScoped<IRecordService, RecordService>()
    .AddSwaggerGen()
    .AddDbContext<TaskDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnStr")));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
