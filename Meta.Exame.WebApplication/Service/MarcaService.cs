using System.Collections.Generic;
using Meta.Exame.WebApplication.Dal;
using Meta.Exame.WebApplication.Models;
namespace Meta.Exame.WebApplication.Service
{
    public class MarcaService
    {
        private MarcaContext context;
        public MarcaService(MarcaContext _context)
        {
            context = _context;
        }
        public List<Marca> FindAll()
        {
            return context.ToList();
        }
        public Marca FindById(int id)
        {
            return context.FindById(id);
        }

        public void Insert(Marca marca)
        {
            context.Add(marca);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }

        public void Update(Marca marca)
        {
            context.Update(marca);
        }
    }
}
