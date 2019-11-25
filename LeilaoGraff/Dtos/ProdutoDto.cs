using LeilaoGraff.Models;

namespace LeilaoGraff.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public static ProdutoDto CriarProdutoDto(Produto model)
        {
            return new ProdutoDto
            {
                Id = model.Id,
                Nome = model.Nome,
                Valor = model.Valor
            };
        }
    }
}
