using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidad.API.Consumer;
using Universidad.Modelos;

namespace Universidad.MVC.Controllers
{
  public class PonenteSesionesController : Controller
  {
    // GET: PonenteSesionesController
    public ActionResult Index()
    {
      var data = Crud<PonenteSesion>.GetAll();
      return View(data);
    }

    // GET: PonenteSesionesController/Details/5
    public ActionResult Details(int id)
    {
      var data = Crud<PonenteSesion>.GetById(id);
      return View(data);
    }

    // GET: PonenteSesionesController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: PonenteSesionesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PonenteSesion data)
    {
      try
      {
        data.Id = 0;
        data.Ponente = null!;
        data.Sesion = null!;
        Crud<PonenteSesion>.Create(data);
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        return View(data);
      }
    }

    // GET: PonenteSesionesController/Edit/5
    public ActionResult Edit(int id)
    {
      var data = Crud<PonenteSesion>.GetById(id);
      return View(data);
    }

    // POST: PonenteSesionesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, PonenteSesion data)
    {
      try
      {
        Crud<PonenteSesion>.Update(id, data);
        return RedirectToAction(nameof(Index));
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        return View(data);
      }
    }

    // GET: PonenteSesionesController/Delete/5
    public ActionResult Delete(int id)
    {
      var data = Crud<PonenteSesion>.GetById(id);
      return View(data);
    }

    // POST: PonenteSesionesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, PonenteSesion data)
    {
      try
      {
        Crud<PonenteSesion>.Delete(id);
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
