using AppMercado.Models;
using AppMercado.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppMercado.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        public HomeController(IProdutoRepository produtoRepository
                            ,IPedidoRepository pedidoRepository
         )
        {
            _produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
        }
        public ActionResult Index()
        {
            var data = _produtoRepository.getAllQuery();
            return View(data);
        }

        public ActionResult AdicionarItem(int idProduto)
        {
            _pedidoRepository.addItem(idProduto);
            return RedirectToAction("index", "Pedido");
        }
    }
}
