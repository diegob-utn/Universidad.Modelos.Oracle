using Microsoft.AspNetCore.Mvc.RazorPages;
using Universidad.API.Consumer;

public class IndexModel : PageModel
{
    public List<Evento> Eventos { get; set; } = new();

    public void OnGet()
    {
        Crud<Evento>.EndPoint = "https://localhost:7270/api/Eventos";
        Eventos = Crud<Evento>.GetAll();
    }
}