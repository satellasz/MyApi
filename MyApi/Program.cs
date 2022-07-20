using MyApi.Infrastructure.Data.Context;
using MyApi.Infrastructure.Data.Repositories;
using MyApi.Domain.Services;

using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace MyApi
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = builder.Configuration.GetConnectionString("DevelopmentDb");

            builder.Services.AddDbContext<DbPostContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<PostService>();
            builder.Services.AddScoped<PostRepository>();

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
        }
    }
}
