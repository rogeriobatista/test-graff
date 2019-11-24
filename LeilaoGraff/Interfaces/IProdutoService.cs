using LeilaoGraff.Dtos;

namespace LeilaoGraff.Interfaces
{
    public interface IProdutoService
    {
        void Armazenar(ProdutoDto produto);
        void Deletar(int id);
    }
}
