using Meta.Exame.WebApplication.Models;
using Meta.Exame.WebApplication.Service;
using OpenQA.Selenium;
using System.Data;
using System.Web.Mvc;
namespace Meta.Exame.WebApplication.Controllers
{
    public class MarcaController : Controller
    {
        private readonly MarcaService _marcaService;
        public MarcaController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        public ActionResult Index()
        {
            return View(_marcaService.FindAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca marca)
        {
            _marcaService.Insert(marca);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            _marcaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            var marca = _marcaService.FindById(id.Value);
            return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marca marca)
        {
            try
            {
                _marcaService.Update(marca);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}