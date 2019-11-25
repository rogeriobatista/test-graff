using LeilaoGraff.Context;
using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using LeilaoGraff.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoGraff.Services
{
    public class LanceService : ILanceService
    {
        LeilaoGraffContext _context;

        public LanceService(LeilaoGraffContext context)
        {
            _context = context;
        }

        public List<LanceDto> Listar()
        {
            return _context.Lances.Include(x => x.Produto).Include(x => x.Pessoa).Select(x => LanceDto.CriarLanceDto(x)).ToList();
        }
        public List<LanceDto> Filtrar(FiltroLanceDto filtro)
        {
            var consulta = _context.Lances.Include(x => x.Pessoa).Include(x => x.Produto).AsQueryable();

            consulta = consulta.Where(x => (string.IsNullOrEmpty(filtro.Pessoa) || x.Pessoa.Nome == filtro.Pessoa) &&
                                           (string.IsNullOrEmpty(filtro.Produto) || x.Produto.Nome == filtro.Produto)
                                     );

            return consulta.Select(x => LanceDto.CriarLanceDto(x)).ToList();
        }
        public bool Armazenar(LanceDto lance)
        {
            if (!LanceValido(lance.ProdutoId, lance.Valor))
                return false;

            var novoLance = new Lance(lance.PessoaId, lance.ProdutoId, lance.Valor);

            if (!novoLance.Validar())
                return false;

            _context.Lances.Add(novoLance);
            _context.SaveChanges();

            return true;

        }
        private bool LanceValido(int produtoId, decimal valor)
        {
            return _context.Lances.All(x => x.ProdutoId == produtoId && x.Valor < valor);
        }
    }
}
