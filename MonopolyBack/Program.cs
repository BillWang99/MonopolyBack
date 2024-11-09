using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MonopolyBack.Data;
using MonopolyBack.Interfaces;
using MonopolyBack.Services;

var builder = WebApplication.CreateBuilder(args);

//sql 連線
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//加入Services
builder.Services.AddScoped<IGameHistoryService, GameHistoryService>();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<IRoundResultService, RoundResultService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

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
