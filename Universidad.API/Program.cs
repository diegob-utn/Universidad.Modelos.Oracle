﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Universidad.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    //options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));
            //    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection") ??
            //    throw new InvalidOperationException("Connection string 'OracleConnection' not found.")));

            builder.Services.AddDbContext<AppDbContext>(options =>
                //options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));
            // Add services to the container.

            //builder.Services.AddControllers();


            builder.Services
                .AddControllers()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
