using SistemaPoc.Data;
using SistemaPoc.Models;
using Microsoft.EntityFrameworkCore;
using SimpleJudicialProcessAPI.Repositorys;
using SimpleJudicialProcessAPI.Repositorys.Interfaces;

namespace SistemaPoc
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
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaPocDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IBaseRepository<Advogado>, BaseRepository<Advogado>>();
            builder.Services.AddScoped<IBaseRepository<Processo>, BaseRepository<Processo>>();
            builder.Services.AddScoped<IBaseRepository<Reclamada>, BaseRepository<Reclamada>>();
            builder.Services.AddScoped<IBaseRepository<Reclamante>, BaseRepository<Reclamante>>();
            builder.Services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();

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