using Meta.Exame.Entidade;
using Meta.Exame.Repositorio;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
namespace Meta.Exame.Api.Controllers
{
    public class VeiculoController : ApiController
    {
        static readonly VeiculoContext context = new VeiculoContext();
        public string Get()
        {
            List<Veiculo> veiculo = new List<Veiculo>();
            veiculo = context.ToList();
            string res = JsonConvert.SerializeObject(veiculo, new JsonSerializerSettings { });
            return res;
        }
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(context.FindById(id));
            return json;
        }
        public void Post(Veiculo veiculo)
        {
            context.Add(veiculo);
        }

        public void Put(Veiculo veiculo)
        {
            context.Update(veiculo);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
    }
}