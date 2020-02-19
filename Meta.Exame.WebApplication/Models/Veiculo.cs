namespace Meta.Exame.WebApplication.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public decimal Valor { get; set; }
        public Veiculo(int id, int idmarca, int idmodelo, decimal valor)
        {
            Id = id;
            IdMarca = idmarca;
            IdModelo = idmodelo;
            Valor = valor;
        }
        public Veiculo()
        {
        }
    }
}