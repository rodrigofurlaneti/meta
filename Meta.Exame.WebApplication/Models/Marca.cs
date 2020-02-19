namespace Meta.Exame.WebApplication.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Marca(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Marca()
        {
        }
    }
}