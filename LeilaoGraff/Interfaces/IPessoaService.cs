using LeilaoGraff.Dtos;

namespace LeilaoGraff.Interfaces
{
    interface IPessoaService
    {
        void Armazenar(PessoaDto pessoa);
        void Deletar(int id);
    }
}
