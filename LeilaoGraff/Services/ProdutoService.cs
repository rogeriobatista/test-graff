using LeilaoGraff.Context;
using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using LeilaoGraff.Models;
using System.Linq;

namespace LeilaoGraff.Services
{
    public class ProdutoService : IProdutoService
    {
        LeilaoGraffContext _context;
        public ProdutoService(LeilaoGraffContext context)
        {
            _context = context;
        }
        public void Armazenar(ProdutoDto produto)
        {
            if (produto.Id == 0)
            {
                var novoProduto = new Produto(produto.Nome, produto.Valor);

                if (novoProduto.Validar())
                    _context.Set<Produto>().Add(novoProduto);
            }
            else
            {
                var produtoEditado = _context.Set<Produto>().FirstOrDefault(x => x.Id == produto.Id);

                if (produtoEditado != null)
                {
                    produtoEditado.AlterarNome(produto.Nome);
                    produtoEditado.AlterarValor(produto.Valor);

                    if (produtoEditado.Validar())
                        _context.Set<Produto>().Update(produtoEditado);
                }
            }

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var produto = _context.Set<Produto>().FirstOrDefault(x => x.Id == id);
            if (produto != null)
                _context.Set<Produto>().Remove(produto);

            _context.SaveChanges();
        }
    }
}
