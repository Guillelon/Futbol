using System;
using System.Globalization;
using System.Web.Mvc;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Futbol.Models;


namespace Futbol.Controllers
{   
    public class EquiposController : Controller
    {
		private readonly IEquipoRepository equipoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public EquiposController() : this(new EquipoRepository())
        {
        }

        public EquiposController(IEquipoRepository equipoRepository)
        {
			this.equipoRepository = equipoRepository;
        }

        //
        // GET: /Equipos/

        public ViewResult Index()
        {
            return View(equipoRepository.AllIncluding(equipo => equipo.Plantilla));
        }

        //
        // GET: /Equipos/Details/5

        public ViewResult Details(int id)
        {
            return View(equipoRepository.Find(id));
        }

        //
        // GET: /Equipos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Equipos/Create

        [HttpPost]
        public ActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid) {
                equipoRepository.InsertOrUpdate(equipo);
                equipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Equipos/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(equipoRepository.Find(id));
        }

        //
        // POST: /Equipos/Edit/5

        [HttpPost]
        public ActionResult Edit(Equipo equipo)
        {
            if (ModelState.IsValid) {
                equipoRepository.InsertOrUpdate(equipo);
                equipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Equipos/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(equipoRepository.Find(id));
        }

        //
        // POST: /Equipos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            equipoRepository.Delete(id);
            equipoRepository.Save();

            return RedirectToAction("Index");
        }

        public JsonResult Validation(string Nombre)
        {
            if (!equipoRepository.Exists(Nombre))
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json("Nombre repetido", JsonRequestBehavior.AllowGet);
        }
    }
}

