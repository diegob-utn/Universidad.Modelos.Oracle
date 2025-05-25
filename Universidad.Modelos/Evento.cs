using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{
  public class Evento
{
    [Key] public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public string Lugar { get; set; }
    public string Tipo { get; set; } // Ejemplo: Taller, Conferencia, Webinar

    // Relación uno a muchos con Sesion
    public List<Sesion>? Sesiones { get; set; }

    // Relación uno a muchos con Ponente
    public List<Ponente>? Ponentes { get; set; }

    // Relación uno a muchos con Participante
    public List<Participante>? Participantes { get; set; }
}

}
