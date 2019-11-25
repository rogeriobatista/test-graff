using LeilaoGraff.Context;
using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using LeilaoGraff.Models;
using System.Collections.Generic;
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

        public ProdutoDto ObterPorId(int id)
        {
            return ProdutoDto.CriarProdutoDto(_context.Produtos.FirstOrDefault(x => x.Id == id));
        }

        public List<ProdutoDto> Listar()
        {
            return _context.Produtos.Select(x => ProdutoDto.CriarProdutoDto(x)).ToList();
        }

        public List<ProdutoDto> Filtrar(ProdutoDto produto)
        {
            var consulta = _context.Produtos.AsQueryable();

            consulta = consulta.Where(x => ( string.IsNullOrEmpty(produto.Nome) || x.Nome == produto.Nome) &&
                                           ( produto.Valor == 0 || x.Valor == produto.Valor)
                                     );
            return consulta.Select(x => ProdutoDto.CriarProdutoDto(x)).ToList();
        }

        public void Armazenar(ProdutoDto produto)
        {
            if (produto.Id == 0)
            {
                var novoProduto = new Produto(produto.Nome, produto.Valor);

                if (novoProduto.Validar())
                {
                    _context.Produtos.Add(novoProduto);
                    _context.SaveChanges();
                }
            }
            else
            {
                var produtoEditado = _context.Produtos.FirstOrDefault(x => x.Id == produto.Id);

                if (produtoEditado != null)
                {
                    produtoEditado.AlterarNome(produto.Nome);
                    produtoEditado.AlterarValor(produto.Valor);

                    if (produtoEditado.Validar())
                    {
                        _context.Produtos.Update(produtoEditado);
                        _context.SaveChanges();
                    }
                }
            }
        }

        public void Deletar(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
