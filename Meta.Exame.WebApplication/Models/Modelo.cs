using System;
namespace Meta.Exame.WebApplication.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Modelo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Modelo()
        {
        }
    }
}