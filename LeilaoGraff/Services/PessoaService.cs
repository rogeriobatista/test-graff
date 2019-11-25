using LeilaoGraff.Context;
using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using LeilaoGraff.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoGraff.Services
{
    public class PessoaService : IPessoaService
    {
        LeilaoGraffContext _context;

        public PessoaService(LeilaoGraffContext context)
        {
            _context = context;
        }

        public PessoaDto ObterPorId(int id)
        {
            return PessoaDto.CriarPessoaDto(_context.Pessoas.FirstOrDefault(x => x.Id == id));
        }

        public List<PessoaDto> Listar()
        {
            return _context.Pessoas.Select(x => PessoaDto.CriarPessoaDto(x)).ToList();
        }

        public List<PessoaDto> Filtrar(PessoaDto pessoa)
        {
            var consulta = _context.Pessoas.AsQueryable();

            consulta = consulta.Where(x => (string.IsNullOrEmpty(pessoa.Nome) || x.Nome == pessoa.Nome) &&
                                           (pessoa.Idade == 0 || x.Idade == pessoa.Idade)
                                     );

            return consulta.Select(x => PessoaDto.CriarPessoaDto(x)).ToList();
        }

        public void Armazenar(PessoaDto pessoa)
        {
            if (pessoa.Id == 0)
            {
                var novaPessoa = new Pessoa(pessoa.Nome, pessoa.Idade);

                if (novaPessoa.Validar())
                {
                    _context.Pessoas.Add(novaPessoa);
                    _context.SaveChanges();
                }
            }
            else
            {
                var pessoaEditada = _context.Pessoas.FirstOrDefault(x => x.Id == pessoa.Id);

                if (pessoaEditada != null)
                {
                    pessoaEditada.AlterarNome(pessoa.Nome);
                    pessoaEditada.AlterarIdade(pessoa.Idade);

                    if (pessoaEditada.Validar())
                    {
                        _context.Pessoas.Update(pessoaEditada);
                        _context.SaveChanges();
                    }
                }
            }
        }

        public void Deletar(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(x => x.Id == id);

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
            }
        }
    }
}
