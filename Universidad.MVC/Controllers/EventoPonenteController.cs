using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
  public class EventoPonenteController : Controller
  {
    // GET: EventoPonenteController
    public ActionResult Index()
    {
      var data = Crud<EventoPonente>.GetAll();
      return View(data);
    }

    // GET: EventoPonenteController/Details/5
    public ActionResult Details(int id)
    {
      var data = Crud<EventoPonente>.GetById(id);
      return View(data);
    }

    // GET: EventoPonenteController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: EventoPonenteController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(EventoPonente data)
    {
      try
      {
        data.Id = 0;
        data.Evento = null!;
        data.Ponente = null!;
        Crud<EventoPonente>.Create(data);
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        return View(data);
      }
    }

    // GET: EventoPonenteController/Edit/5
    public ActionResult Edit(int id)
    {
      var data = Crud<EventoPonente>.GetById(id);
      return View(data);
    }

    // POST: EventoPonenteController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, EventoPonente data)
    {
      try
      {
        Crud<EventoPonente>.Update(id, data);
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        return View(data);
      }
    }

    // GET: EventoPonenteController/Delete/5
    public ActionResult Delete(int id)
    {
      var data = Crud<EventoPonente>.GetById(id);
      return View(data);
    }

    // POST: EventoPonenteController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, EventoPonente data)
    {
      try
      {
        Crud<EventoPonente>.Delete(id);
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
