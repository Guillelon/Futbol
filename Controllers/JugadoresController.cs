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

        //
        // GET: /Jugadores/

        public ViewResult MapperExample()
        {
            IEnumerable<Jugador> players = jugadorRepository.All;
            IEnumerable<JugadorViewModels> playersView = Mapper.Map<IEnumerable<Jugador>, IEnumerable<JugadorViewModels>>(players);
            return View(playersView);
        }

        public ViewResult Index()
        {
            var a = jugadorRepository.AllIncluding(jugador => jugador.Equipo);
            //var b = a.Where(p => p.Nombre.Contains("M"));
            return View(a);
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
			ViewBag.PossibleEquipoes = equipoRepository.All;
            return View();
        } 

        //
        // POST: /Jugadores/Create

        [HttpPost]
        public ActionResult Create(Jugador jugador)
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
    }
}

