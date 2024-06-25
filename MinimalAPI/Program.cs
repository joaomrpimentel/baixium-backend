using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dtos;
using MinimalAPI.Endpoints;
using MinimalAPI.Models;
using System;

// modules


namespace MinimalAPI
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContextDb>(opt => opt.UseInMemoryDatabase("db"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            // Authorization
            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ContextDb>();

            builder.Services.AddAuthorization();
            // End Authorization

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();

            // CORS
            builder.Services.AddCors();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
               );


            // Authentication Mapgroup
            app.MapGroup("/users").CustomMapIdentityApi<User>();

            app.ArticleEndpoints();
            app.UsersEndpoints();

            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }

}