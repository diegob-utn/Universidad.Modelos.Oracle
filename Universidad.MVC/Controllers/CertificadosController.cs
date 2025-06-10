using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class CertificadosController:Controller
    {
        // GET: CertificadosController
        public ActionResult Index()
        {
            var data = Crud<Certificado>.GetAll();
            return View(data);
        }

        // GET: CertificadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertificadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CertificadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CertificadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
