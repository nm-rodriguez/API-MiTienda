using API_MiTienda.InitialSetup;
using Microsoft.EntityFrameworkCore;
using MiTienda.DataAccess.Contexts;

namespace API_MiTienda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("StringConnection");
            builder.Services.InitialCharges(connectionString);
            

            var app = builder.Build();
            
            //LOG en consola
            app.Use(async (context,next) =>
            { using (var swapStream = new MemoryStream())
                {
                    var respuestaOriginal = context.Response.Body;
                    context.Response.Body = swapStream;
                    await next.Invoke();

                    swapStream.Seek(0, SeekOrigin.Begin);
                    string respuesta = new StreamReader(swapStream).ReadToEnd();
                    swapStream.Seek(0, SeekOrigin.Begin);

                    await swapStream.CopyToAsync(respuestaOriginal);
                    context.Response.Body = respuestaOriginal;
                    app.Logger.LogInformation(respuesta);
                }
            });
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}