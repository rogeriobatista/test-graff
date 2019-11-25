using LeilaoGraff.Models;
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

        public static LanceDto CriarLanceDto(Lance model)
        {
            return new LanceDto
            {
                Id = model.Id,
                Valor = model.Valor,
                Pessoa = PessoaDto.CriarPessoaDto(model.Pessoa),
                Produto = ProdutoDto.CriarProdutoDto(model.Produto),
                Data = model.Data,
                PessoaId = model.PessoaId,
                ProdutoId = model.ProdutoId
            };
        }
    }
}
