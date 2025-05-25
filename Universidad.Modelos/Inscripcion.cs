using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{

    public class Inscripcion
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } // Ejemplo: Pendiente, Confirmada, Cancelada

        // Relación muchos a uno con Participante
        [ForeignKey("ParticipanteId")]
        public int ParticipanteId { get; set; }

        // Relación muchos a uno con Evento
        [ForeignKey("EventoId")]
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
        public Participante? Participante { get; set; }
    }

}
