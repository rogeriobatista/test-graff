using LeilaoGraff.Models;

namespace LeilaoGraff.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public static PessoaDto CriarPessoaDto(Pessoa model)
        {
            return new PessoaDto
            {
                Id = model.Id,
                Nome = model.Nome,
                Idade = model.Idade
            };
        }
    }
}
