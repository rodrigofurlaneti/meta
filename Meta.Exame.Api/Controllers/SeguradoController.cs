using Meta.Exame.Entidade;
using Meta.Exame.Repositorio;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
namespace Meta.Exame.Api.Controllers
{
    public class SeguradoController : ApiController
    {
        static readonly SeguradoContext context = new SeguradoContext();
        public string Get()
        {
            List<Segurado> segurado = new List<Segurado>();
            segurado = context.ToList();
            string res = JsonConvert.SerializeObject(segurado, new JsonSerializerSettings { });
            return res;
        }
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(context.FindById(id));
            return json;
        }
        public void Post(Segurado segurado)
        {
            context.Add(segurado);
        }

        public void Put(Segurado segurado)
        {
            context.Update(segurado);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
    }
}