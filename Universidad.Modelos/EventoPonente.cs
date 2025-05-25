using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Modelos
{
    public class EventoPonente
    {

        [Key]
        public int Id { get; set; }
        public int EventosId { get; set; }
        public Evento Evento { get; set; }

        public int PonentesId { get; set; }
        public Ponente Ponente { get; set; }
    }
}
