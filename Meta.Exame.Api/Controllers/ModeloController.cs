using Meta.Exame.Entidade;
using Meta.Exame.Repositorio;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
namespace Meta.Exame.Api.Controllers
{
    public class ModeloController : ApiController
    {
        static readonly ModeloContext context = new ModeloContext();
        public string Get()
        {
            List<Modelo> modelo = new List<Modelo>();
            modelo = context.ToList();
            string res = JsonConvert.SerializeObject(modelo, new JsonSerializerSettings { });
            return res;
        }
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(context.FindById(id));
            return json;
        }
        public void Post(Modelo modelo)
        {
            context.Add(modelo);
        }

        public void Put(Modelo modelo)
        {
            context.Update(modelo);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
    }
}