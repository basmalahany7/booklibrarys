
using booklibrarys.Repo.AuthorRepos;
using booklibrarys.Repo.BookRepos;
using booklibrarys.Repo.GenreRepos;
using Microsoft.EntityFrameworkCore;

namespace booklibrarys
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
            builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefulConnection")));
            builder.Services.AddScoped<IAuthorRepo,AuthorRepo>();
            builder.Services.AddScoped<IBookRepo,BookRepo>();
            builder.Services.AddScoped<IGenreRepo,GenreRepo>();
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
