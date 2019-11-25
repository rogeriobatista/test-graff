using LeilaoGraff.Dtos;
using System.Collections.Generic;

namespace LeilaoGraff.Interfaces
{
    public interface IPessoaService
    {
        PessoaDto ObterPorId(int id);
        List<PessoaDto> Listar();
        List<PessoaDto> Filtrar(PessoaDto pessoa);
        void Armazenar(PessoaDto pessoa);
        void Deletar(int id);
    }
}
