using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Futbol.Models;
using Futbol.ViewModels;
using AutoMapper;


namespace Futbol.Controllers
{   
    public class JugadoresController : Controller
    {
		private readonly IEquipoRepository equipoRepository;
		private readonly IJugadorRepository jugadorRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public JugadoresController() : this(new EquipoRepository(), new JugadorRepository())
        {
        }

        public JugadoresController(IEquipoRepository equipoRepository, IJugadorRepository jugadorRepository)
        {
			this.equipoRepository = equipoRepository;
			this.jugadorRepository = jugadorRepository;
        }


        public ViewResult Index()
        {
            var jugadores = jugadorRepository.AllIncluding(jugador => jugador.Equipo);
            var jugadoresViewModel = ManualMapperJugadoresList(jugadores.ToList());
            return View(jugadoresViewModel);
        }

        public ViewResult Plantilla(int id) 
        {
            var equipo = equipoRepository.Find(id);
            var jugadoresViewModel = ManualMapperJugadoresList(equipo.Plantilla.ToList());
            return View(jugadoresViewModel);
        }

        //
        // GET: /Jugadores/Details/5

        public ViewResult Details(int id)
        {
            return View(jugadorRepository.Find(id));
        }

        //
        // GET: /Jugadores/Create

        public ActionResult Create()
        {
            var jugadorCreateViewModel = new JugadorCreateViewModel(equipoRepository.All.ToList());
            return View(jugadorCreateViewModel);
        } 

        //
        // POST: /Jugadores/Create

        [HttpPost]
        public ActionResult Create(JugadorCreateViewModel jugadorViewModel)
        {
            if (ModelState.IsValid) {
                var jugador = ManualMapperJugadorCreateViewModel(jugadorViewModel);
                jugadorRepository.InsertOrUpdate(jugador);
                jugadorRepository.Save();
                return RedirectToAction("Index");
            } else {
                return View(jugadorViewModel);
			}
        }
        
        //
        // GET: /Jugadores/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleEquipoes = equipoRepository.All;
            return View(jugadorRepository.Find(id));
        }

        //
        // POST: /Jugadores/Edit/5

        [HttpPost]
        public ActionResult Edit(Jugador jugador)
        {
            if (ModelState.IsValid) {
                jugadorRepository.InsertOrUpdate(jugador);
                jugadorRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleEquipoes = equipoRepository.All;
				return View();
			}
        }

        //
        // GET: /Jugadores/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(jugadorRepository.Find(id));
        }

        //
        // POST: /Jugadores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            jugadorRepository.Delete(id);
            jugadorRepository.Save();

            return RedirectToAction("Index");
        }

        private IList<JugadorListViewModels> ManualMapperJugadoresList(List<Jugador> jugadores) 
        {
            var jugadoresViewModel = new List<JugadorListViewModels>();
            foreach (var jugador in jugadores) 
            {
                var jugadorViewModel = new JugadorListViewModels();
                jugadorViewModel.ID = jugador.ID;
                jugadorViewModel.Apellido = jugador.Apellido;
                jugadorViewModel.Equipo = jugador.Equipo.Nombre;
                jugadoresViewModel.Add(jugadorViewModel);
            }
            return jugadoresViewModel;
        }

        private Jugador ManualMapperJugadorCreateViewModel(JugadorCreateViewModel jugadorViewModel)
        {
            var jugador = new Jugador();
            jugador.Nombre = jugadorViewModel.Nombre;
            jugador.Apellido = jugadorViewModel.Apellido;
            jugador.Nacionalidad = jugadorViewModel.Nacionalidad;
            jugador.EquipoId = jugadorViewModel.EquipoSeleccionado;
            return jugador;
        }
    }
}

