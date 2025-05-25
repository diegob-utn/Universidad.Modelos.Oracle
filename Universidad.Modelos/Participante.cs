using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{

    public class Participante
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        // Relación muchos a uno con Evento
        [ForeignKey("EventoId")]
        public int EventoId { get; set; }

        // Relación muchos a uno con Sesion
        [ForeignKey("SesionId")]
        public int SesionId { get; set; }
        public Sesion? Sesion { get; set; }
        public Evento? Evento { get; set; }
    }

}
