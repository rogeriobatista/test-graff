using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoGraff.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IActionResult Index()
        {
            ViewData["pessoas"] = _pessoaService.Listar();

            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);

            if (pessoa == null)
                return Redirect("/Pessoas/Index");

            ViewData["pessoa"] = pessoa;

            return View();
        }

        [HttpPost]
        public IActionResult Armazenar(PessoaDto pessoa)
        {
            _pessoaService.Armazenar(pessoa);

            return Redirect("/Pessoas/Index");
        }

        public IActionResult Remover(int id)
        {
            _pessoaService.Deletar(id);

            return Redirect("/Pessoas/Index");
        }
    }
}