using MicroService1.Data.Context;
using Microsoft.EntityFrameworkCore;
using MicroService1.Data.Models;
using MicroService1.Services.Abstractions;
using MicroService1.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LectureContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(LectureContext))));

builder.Services.AddTransient<IUserCourseService, UserCourseService>();

// Add services to the container.

var app = builder.Build();
app.MapControllers();
app.UseRouting();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
