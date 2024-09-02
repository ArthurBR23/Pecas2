using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class ProdutoController : Controller
    {

        private static IList<Produto> Produtos = new List<Produto>()
        {
            new Produto()
            {
                ProdId = 1,
                Nome = "Pneu",
                Categoria = "automovel",
                Marca = "Continental",
                Valor = 300,
                Quantidade = 2
            },

            new Produto()
            {
                ProdId = 2,
                Nome = "Motor",
                Categoria = "automovel",
                Marca = "BMW",
                Valor = 600,
                Quantidade = 1
            }

        };
        public IActionResult Index()
        {
            return View(Produtos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Produto produto)
        {
            produto.ProdId = Produtos.Select(x => x.ProdId).Max() + 1;
            Produtos.Add(produto);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(Produtos.Where(produto => produto.ProdId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            var produtoOld = Produtos.Where(produto => produto.ProdId == produto.ProdId).First();
            Produtos.Remove(produtoOld);
            Produtos.Add(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Produtos.Where(produto => produto.ProdId == id).First());
        }
        public IActionResult Delete(int id)
        {
            return View(Produtos.Where(produto => produto.ProdId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = Produtos.Where(produto => produto.ProdId == id).First();
            Produtos.Remove(produto);
            return RedirectToAction("Index");
        }
    }
}
