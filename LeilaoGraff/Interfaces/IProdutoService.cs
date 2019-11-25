using LeilaoGraff.Dtos;
using System.Collections.Generic;

namespace LeilaoGraff.Interfaces
{
    public interface IProdutoService
    {
        ProdutoDto ObterPorId(int id);
        List<ProdutoDto> Listar();
        List<ProdutoDto> Filtrar(ProdutoDto produto);
        void Armazenar(ProdutoDto produto);
        void Deletar(int id);
    }
}
