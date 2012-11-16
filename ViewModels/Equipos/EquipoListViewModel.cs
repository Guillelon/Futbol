using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futbol.ViewModels
{
    public class EquipoListViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Division { get; set; }
        public int Plantilla { get; set; }
    }
}