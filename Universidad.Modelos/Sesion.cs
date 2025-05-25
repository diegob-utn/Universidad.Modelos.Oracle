using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Universidad.Modelos
{
  
public class Sesion
{
    [Key] public int Id { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFin { get; set; }
    public string Lugar { get; set; }

    // Relación muchos a uno con Evento
    public int EventoId { get; set; }
    public Evento? Evento { get; set; }

    // Relación uno a muchos con Participante
    public List<Participante>? Participantes { get; set; }

    public List<Ponente>? Ponentes { get; set; }
    }

}