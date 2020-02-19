using System.Collections.Generic;
using Meta.Exame.WebApplication.Dal;
using Meta.Exame.WebApplication.Models;
namespace Meta.Exame.WebApplication.Service
{
    public class VeiculoService
    {
        private VeiculoContext context;
        public VeiculoService(VeiculoContext _context)
        {
            context = _context;
        }
        public List<Veiculo> FindAll()
        {
            return context.ToList();
        }
        public Veiculo FindById(int id)
        {
            return context.FindById(id);
        }
        public void Insert(Veiculo Veiculo)
        {
            context.Add(Veiculo);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
        public void Update(Veiculo Veiculo)
        {
            context.Update(Veiculo);
        }
    }
}