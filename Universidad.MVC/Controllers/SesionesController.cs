using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class SesionesController:Controller
    {

        // GET: SesionesController
        public ActionResult Index()
        {
            var data = Crud<Sesion>.GetAll();
            return View(data);
        }

        // GET: SesionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Sesion>.GetById(id);
            return View(data);
        }

        // GET: SesionesController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: SesionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sesion data)
        {
            try
            {
                // Normaliza las fechas a UTC
                data.HoraInicio = DateTime.SpecifyKind(data.HoraInicio, DateTimeKind.Utc);
                data.HoraFin = DateTime.SpecifyKind(data.HoraFin, DateTimeKind.Utc);

                data.Id = 0;
                data.Evento = null;
                data.Participantes = null;
                data.Ponentes = null;
                Crud<Sesion>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: SesionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Sesion>.GetById(id);
            return View(data);
        }

        // POST: SesionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sesion data)
        {
            try
            {
                // Normaliza las fechas a UTC
                data.HoraInicio = DateTime.SpecifyKind(data.HoraInicio, DateTimeKind.Utc);
                data.HoraFin = DateTime.SpecifyKind(data.HoraFin, DateTimeKind.Utc);

                Crud<Sesion>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: SesionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Sesion>.GetById(id);
            return View(data);
        }

        // POST: SesionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sesion data)
        {
            try
            {
                Crud<Sesion>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
