using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class MovimentacaoController : Controller
    {
        private static IList<Movimentacao> Movimentacoes = new List<Movimentacao>()
        {
            new Movimentacao()
            {
                MovId = 1,
            }
        };
        public IActionResult Index()
        {
            return View(Movimentacoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Movimentacao movimentacao)
        {
            movimentacao.MovId = Movimentacoes.Select(x => x.MovId).Max() + 1;
            Movimentacoes.Add(movimentacao);
            return RedirectToAction("Index");
        }
    }
}
