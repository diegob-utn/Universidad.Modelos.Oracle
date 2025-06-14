﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class InscripcionesController : Controller
    {
        // GET: InscripcionesController
        public ActionResult Index()
        {
            var data = Crud<Inscripcion>.GetAll();
            return View(data);
        }        // GET: InscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Inscripcion>.GetById(id);
            return View(data);
        }

        // GET: InscripcionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inscripcion data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                data.Id = 0;
                data.Evento = null;
                data.Participante = null;
                Crud<Inscripcion>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: InscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Inscripcion>.GetById(id);
            return View(data);
        }

        // POST: InscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inscripcion data)
        {
            try
            {
                // Normaliza la fecha a UTC
                data.Fecha = DateTime.SpecifyKind(data.Fecha, DateTimeKind.Utc);

                Crud<Inscripcion>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: InscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Inscripcion>.GetById(id);
            return View(data);
        }

        // POST: InscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inscripcion data)
        {
            try
            {
                Crud<Inscripcion>.Delete(id);
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
