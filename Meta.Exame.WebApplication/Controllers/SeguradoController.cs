using Meta.Exame.WebApplication.Models;
using Meta.Exame.WebApplication.Service;
using OpenQA.Selenium;
using System.Data;
using System.Web.Mvc;
namespace Meta.Exame.WebApplication.Controllers
{
    public class SeguradoController : Controller
    {
        private readonly SeguradoService _seguradoService;
        public SeguradoController(SeguradoService seguradoService)
        {
            _seguradoService = seguradoService;
        }
        public ActionResult Index()
        {
            return View(_seguradoService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Segurado segurado)
        {
            _seguradoService.Insert(segurado);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            _seguradoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            var segurado = _seguradoService.FindById(id.Value);
            return View(segurado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Segurado segurado)
        {
            try
            {
                _seguradoService.Update(segurado);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}