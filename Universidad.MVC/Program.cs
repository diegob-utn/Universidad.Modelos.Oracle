using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";
            Crud<Certificado>.EndPoint = "https://localhost:7270/api/Certificados";
            Crud<Inscripcion>.EndPoint = "https://localhost:7270/api/Inscripciones";
            Crud<Pago>.EndPoint = "https://localhost:7270/api/Pagos";
            Crud<Participante>.EndPoint = "https://localhost:7270/api/Participantes";
            Crud<Ponente>.EndPoint = "https://localhost:7270/api/Ponentes";
            Crud<Sesion>.EndPoint = "https://localhost:7270/api/Sesiones";
            Crud<EventoPonente>.EndPoint = "https://localhost:7270/api/EventoPonentes";
            Crud<PonenteSesion>.EndPoint = "https://localhost:7270/api/PonenteSesiones";


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
