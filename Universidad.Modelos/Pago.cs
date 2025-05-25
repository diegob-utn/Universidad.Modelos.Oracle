using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{

    public class Pago
    {
        [Key] public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Medio { get; set; } // Ejemplo: Tarjeta, Transferencia, Efectivo

        // Relación muchos a uno con Inscripcion
        [ForeignKey("InscripcionId")]
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
    }

}
