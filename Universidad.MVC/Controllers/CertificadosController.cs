using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class CertificadosController : Controller
    {
        // GET: CertificadosController
        public ActionResult Index()
        {
            var data = Crud<Certificado>.GetAll();
            return View(data);
        }        // GET: CertificadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Certificado>.GetById(id);
            return View(data);
        }

        // GET: CertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertificadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Certificado data)
        {
            try
            {
                data.Id = 0;
                data.Participante = null;
                Crud<Certificado>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Certificado>.GetById(id);
            return View(data);
        }

        // POST: CertificadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Certificado data)
        {
            try
            {
                Crud<Certificado>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Certificado>.GetById(id);
            return View(data);
        }

        // POST: CertificadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Certificado data)
        {
            try
            {
                Crud<Certificado>.Delete(id);
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
