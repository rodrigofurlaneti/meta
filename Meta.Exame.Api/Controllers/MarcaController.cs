using Meta.Exame.Repositorio;
using Meta.Exame.Entidade;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
namespace Meta.Exame.Api.Controllers
{
    public class MarcaController : ApiController
    {
        static readonly MarcaContext context = new MarcaContext();
        public string Get()
        {
            List<Marca> marca = new List<Marca>();
            marca = context.ToList();
            string res = JsonConvert.SerializeObject(marca, new JsonSerializerSettings { });
            return res;
        }
        public string Get(int id)
        {
            var json = JsonConvert.SerializeObject(context.FindById(id));
            return json;
        }
        public void Post(Marca marca)
        {
            context.Add(marca);
        }
        
        public void Put(Marca marca)
        {
            context.Update(marca);
        }
        public void Delete(int id)
        {
            context.Remove(id);
        }
    }
}