using System.Collections.Generic;
using Meta.Exame.WebApplication.Dal;
using Meta.Exame.WebApplication.Models;
namespace Meta.Exame.WebApplication.Service
{
    public class SeguradoService
    {
        private SeguradoContext context;
        public SeguradoService(SeguradoContext _context)
        {
            context = _context;
        }
        public List<Segurado> FindAll()
        {
            return context.ToList();
        }
        public Segurado FindById(int id)
        {
            return context.FindById(id);
        }
        public void Insert(Segurado segurado)
        {
            context.Add(segurado);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
        public void Update(Segurado segurado)
        {
            context.Update(segurado);
        }
    }
}
