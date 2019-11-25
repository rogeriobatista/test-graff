using LeilaoGraff.Dtos;
using LeilaoGraff.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeilaoGraff.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            ViewData["produtos"] = _produtoService.Listar();
            return View();
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var produto = _produtoService.ObterPorId(id);

            if (produto == null)
                return Redirect("/Produtos/Index");

            ViewData["produto"] = produto;

            return View();
        }

        [HttpPost]
        public IActionResult Armazenar(ProdutoDto produto)
        {
            _produtoService.Armazenar(produto);

            return Redirect("/Produtos/Index");
        }

        public IActionResult Remover(int id)
        {
            _produtoService.Deletar(id);

            return Redirect("/Produtos/Index");
        }
    }
}