using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class FornecedorController : Controller
    {
        private static IList<Fornecedor> Fornecedores = new List<Fornecedor>()
        {
            new Fornecedor()
            {
                FornecedorId = 1,
                Nome = "Lucas",
                CNPJ = 123456789,
                Pais = "China",
            },

            new Fornecedor()
            {
                FornecedorId = 2,
                Nome = "Caio",
                CNPJ = 123456788,
                Pais = "Brasil"
            }
        };
        public IActionResult Index()
        {
            return View(Fornecedores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Fornecedor fornecedor)
        {
            fornecedor.FornecedorId = Fornecedores.Select(x => x.FornecedorId).Max() + 1;
            Fornecedores.Add(fornecedor);
            return RedirectToAction("Index");
        }
    }
}
