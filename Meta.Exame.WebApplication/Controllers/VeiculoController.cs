using Meta.Exame.WebApplication.Models;
using Meta.Exame.WebApplication.Models.ViewModel;
using Meta.Exame.WebApplication.Service;
using OpenQA.Selenium;
using System.Web.Mvc;
namespace Meta.Exame.WebApplication.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly VeiculoService _veiculoService;
        private readonly MarcaService _marcaService;
        public VeiculoController(VeiculoService veiculoService, MarcaService marcaService)
        {
            _veiculoService = veiculoService;
            _marcaService = marcaService;
        }
        public ActionResult Index()
        {
            return View(_veiculoService.FindAll());
        }

        public ActionResult Create()
        {
            var marca = _marcaService.FindAll();
            var viewModel = new VeiculoFormViewModel { Marca = marca };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            _veiculoService.Insert(veiculo);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            _veiculoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int? id)
        {
            var veiculo = _veiculoService.FindById(id.Value);
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veiculo veiculo)
        {
            try
            {
                _veiculoService.Update(veiculo);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }
    }
}