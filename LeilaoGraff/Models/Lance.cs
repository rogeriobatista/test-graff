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

        public Lance(int pessoaId, int produtoId, decimal valor)
        {
            PessoaId = pessoaId;
            ProdutoId = produtoId;
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

        public void AlterarPessoaId(int pessoaId)
        {
            PessoaId = pessoaId;
        }

        public void AlterarProdutoId(int produtoId)
        {
            ProdutoId = produtoId;
        }

        public void AlterarValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
