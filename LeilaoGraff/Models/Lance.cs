using FluentValidation;
using System;

namespace LeilaoGraff.Models
{
    public class Lance : Entidade<int, Lance>
    {
        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }

        protected Lance() {}

        public Lance(int pessoaId, Pessoa pessoa, int produtoId, Produto produto, decimal valor)
        {
            PessoaId = pessoaId;
            Pessoa = pessoa;
            ProdutoId = produtoId;
            Produto = produto;
            Valor = valor;
            Data = DateTime.Now;
        }

        public override bool Validar()
        {
            RuleFor(x => x.PessoaId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.ProdutoId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Valor)
                .NotNull()
                .GreaterThan(0);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
