using Meta.Exame.Api.Models;
using Meta.Exame.Api.Dal;
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
            List<Veiculo> Veiculo = new List<Veiculo>();
            Veiculo = context.ToList();
            string res = JsonConvert.SerializeObject(Veiculo, new JsonSerializerSettings { });
            return res;
        }
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(context.FindById(id));
            return json;
        }
        public void Post(Veiculo Veiculo)
        {
            context.Add(Veiculo);
        }

        public void Put(Veiculo Veiculo)
        {
            context.Update(Veiculo);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
    }
}