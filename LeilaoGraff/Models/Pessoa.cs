using FluentValidation;
using System.Collections.Generic;

namespace LeilaoGraff.Models
{
    public class Pessoa : Entidade<int, Pessoa>
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public List<Lance> Lances { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public override bool Validar()
        {
            RuleFor(x => x.Nome)
                .NotEmpty();

            RuleFor(x => x.Idade)
                .NotNull()
                .GreaterThan(0);

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarIdade(int idade)
        {
            Idade = idade;
        }
    }
}
