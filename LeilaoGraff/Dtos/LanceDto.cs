using System;

namespace LeilaoGraff.Dtos
{
    public class LanceDto
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public PessoaDto Pessoa { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoDto Produto { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
