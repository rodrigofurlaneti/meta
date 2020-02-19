namespace Meta.Exame.Entidade
{
    public class Segurado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Idade { get; set; }
        public Segurado(int id, string nome, string cpf, string idade)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
        }
        public Segurado()
        {
        }   
    }
}