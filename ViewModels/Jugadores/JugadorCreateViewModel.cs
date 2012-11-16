using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Futbol.Models;

namespace Futbol.ViewModels
{
    public class JugadorCreateViewModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nacionalidad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public int EquipoSeleccionado { get; set; }

        public List<EquipoListViewModel> PosiblesEquipos { get; set; }

        public JugadorCreateViewModel(List<Equipo> equipos) 
        {
            PosiblesEquipos = new List<EquipoListViewModel>();
            foreach (var equipo in equipos) 
            {
                var posibleEquipo = new EquipoListViewModel();
                posibleEquipo.ID = equipo.ID;
                posibleEquipo.Nombre = equipo.Nombre;
                PosiblesEquipos.Add(posibleEquipo);
            }
        }

        public JugadorCreateViewModel() { }
    }
}