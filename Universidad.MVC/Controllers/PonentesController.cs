using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class PonentesController : Controller
    {
        // GET: PonentesController
        public ActionResult Index()
        {
            var data = Crud<Ponente>.GetAll();
            return View(data);
        }        // GET: PonentesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Ponente>.GetById(id);
            return View(data);
        }

        // GET: PonentesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PonentesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ponente data)
        {
            try
            {
                data.Id = 0;
                data.Eventos = null;
                data.Sesiones = null;
                Crud<Ponente>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PonentesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Ponente>.GetById(id);
            return View(data);
        }

        // POST: PonentesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ponente data)
        {
            try
            {
                Crud<Ponente>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PonentesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Ponente>.GetById(id);
            return View(data);
        }

        // POST: PonentesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ponente data)
        {
            try
            {
                Crud<Ponente>.Delete(id);
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
