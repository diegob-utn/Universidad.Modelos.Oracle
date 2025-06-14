﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
    public class ParticipantesController : Controller
    {
        // GET: ParticipantesController
        public ActionResult Index()
        {
            var data = Crud<Participante>.GetAll();
            return View(data);
        }        // GET: ParticipantesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Participante>.GetById(id);
            return View(data);
        }

        // GET: ParticipantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participante data)
        {
            try
            {
                data.Id = 0;
                data.Sesion = null;
                data.Evento = null;
                Crud<Participante>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ParticipantesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Participante>.GetById(id);
            return View(data);
        }

        // POST: ParticipantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Participante data)
        {
            try
            {
                Crud<Participante>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: ParticipantesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Participante>.GetById(id);
            return View(data);
        }

        // POST: ParticipantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Participante data)
        {
            try
            {
                Crud<Participante>.Delete(id);
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
