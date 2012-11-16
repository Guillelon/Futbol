using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futbol.ViewModels
{
    public class JugadorListViewModels
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public string Equipo { get; set; }
    }
}