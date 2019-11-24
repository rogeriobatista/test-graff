using FluentValidation;
using System.Collections.Generic;

namespace LeilaoGraff.Models
{
    public class Produto : Entidade<int, Produto>
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public List<Lance> Lances { get; private set; }

        protected Produto() { }

        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Valor)
                .NotNull()
                .GreaterThan(0);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
