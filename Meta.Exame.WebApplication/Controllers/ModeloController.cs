using Meta.Exame.WebApplication.Models;
using Meta.Exame.WebApplication.Service;
using OpenQA.Selenium;
using System.Web.Mvc;
namespace Meta.Exame.WebApplication.Controllers
{
    public class ModeloController : Controller
    {
        private readonly ModeloService _modeloService;
        public ModeloController(ModeloService modeloService)
        {
            _modeloService = modeloService;
        }
        public ActionResult Index()
        {
            return View(_modeloService.FindAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo modelo)
        {
            _modeloService.Insert(modelo);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            _modeloService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int? id)
        {
            var modelo = _modeloService.FindById(id.Value);
            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Modelo modelo)
        {
            try
            {
                _modeloService.Update(modelo);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}