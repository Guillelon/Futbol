using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Futbol.Models
{
    public class Jugador
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nacionalidad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int EquipoId { get; set; }
        public virtual Equipo Equipo { get; set; }
    } 
}