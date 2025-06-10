using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class PagosController : Controller
    {
        // GET: PagosController
        public ActionResult Index()
        {
            var data = Crud<Pago>.GetAll();
            return View(data);
        }        // GET: PagosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pago>.GetById(id);
            return View(data);
        }

        // GET: PagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                data.Id = 0;
                data.Inscripcion = null;
                Crud<Pago>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PagosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Pago>.GetById(id);
            return View(data);
        }

        // POST: PagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pago data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                Crud<Pago>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PagosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pago>.GetById(id);
            return View(data);
        }

        // POST: PagosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pago data)
        {
            try
            {
                Crud<Pago>.Delete(id);
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
