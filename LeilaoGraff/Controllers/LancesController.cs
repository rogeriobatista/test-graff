using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoGraff.Controllers
{
    public class LancesController : Controller
    {
        private readonly ILanceService _lanceService;
        private readonly IPessoaService _pessoaService;
        private readonly IProdutoService _produtoService;

        public LancesController(ILanceService lanceService, IPessoaService pessoaService, IProdutoService produtoService)
        {
            _lanceService = lanceService;
            _pessoaService = pessoaService;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            ViewData["lances"] = _lanceService.Listar();

            return View();
        }

        public IActionResult Filtrar(FiltroLanceDto filtro)
        {
            ViewData["lances"] = _lanceService.Filtrar(filtro);

            return View("~/Views/Lances/Index.cshtml");
        }

        public IActionResult Novo()
        {
            ViewData["pessoas"] = _pessoaService.Listar();
            ViewData["produtos"] = _produtoService.Listar();

            return View();
        }

        [HttpPost]
        public IActionResult Armazenar(LanceDto lance)
        {
            if (!_lanceService.Armazenar(lance))
            {
                ViewData["pessoas"] = _pessoaService.Listar();
                ViewData["produtos"] = _produtoService.Listar();

                ViewData["message"] = "Lance inválido";
                return View("~/Views/Lances/Novo.cshtml");
            }

            return Redirect("/Lances/Index");
        }
    }
}