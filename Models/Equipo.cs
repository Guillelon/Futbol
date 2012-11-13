using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Futbol.Models
{
    public class Equipo
    {
        public int ID { get; set; }
        [Required]
        [Remote("Validation", "Equipos")]
        public string Nombre { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Division { get; set; }
        
        public string Imagen { get; set; }
        public ICollection<Jugador> Plantilla { get; set; }
    }
}