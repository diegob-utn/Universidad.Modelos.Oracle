using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{
    public class PonenteSesion
    {
        [Key]
        public int Id { get; set; }
        public int PonentesId { get; set; }
        public Ponente Ponente { get; set; }

        public int SesionesId { get; set; }
        public Sesion Sesion { get; set; }
    }
}
