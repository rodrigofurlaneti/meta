using System.Collections.Generic;
using Meta.Exame.WebApplication.Dal;
using Meta.Exame.WebApplication.Models;
namespace Meta.Exame.WebApplication.Service
{
    public class ModeloService
    {
        private ModeloContext context;
        public ModeloService(ModeloContext _context)
        {
            context = _context;
        }
        public List<Modelo> FindAll()
        {
            return context.ToList();
        }
        public Modelo FindById(int id)
        {
            return context.FindById(id);
        }
        public void Insert(Modelo modelo)
        {
            context.Add(modelo);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
        public void Update(Modelo modelo)
        {
            context.Update(modelo);
        }
    }
}
