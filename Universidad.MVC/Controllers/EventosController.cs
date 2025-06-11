using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class EventosController : Controller
    {
        // GET: EventosController
        public ActionResult Index()
        {
            var data = Crud<Evento>.GetAll();
            ViewBag.TotalEventos = data.Count; // Ejemplo de cómo enviar datos adicionales a la vista
            ViewBag.TotalSesiones = Crud<Sesion>.GetAll().Count;
            return View(data);
        }        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Evento>.GetById(id);
            data.Sesiones = Crud<Sesion>.GetBy("evento", id);
            return View(data);
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                data.Id = 0;
                data.Sesiones = null;
                data.Ponentes = null;
                data.Participantes = null;
                Crud<Evento>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Evento>.GetById(id);
            return View(data);
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Evento data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                Crud<Evento>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EventosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Evento>.GetById(id);
            return View(data);
        }

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Evento data)
        {
            try
            {
                Crud<Evento>.Delete(id);
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
