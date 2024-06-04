using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Context;
using RepoLayer.Interface;
using RepoLayer.Service;

namespace MyFirst
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Mydb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyString"));
            });
            builder.Services.AddScoped<ICustomerRL,CustomerRL>();
            builder.Services.AddScoped<ICustomerBL,CustomerBL>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}