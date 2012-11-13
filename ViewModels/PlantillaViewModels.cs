using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Futbol.ViewModels
{
    public class PlantillaViewModels
    {
         public List<JugadorViewModels> Plantilla { get; set; }

         public PlantillaViewModels() 
         {
             this.Plantilla = new List<JugadorViewModels>();
         }
    }
}
