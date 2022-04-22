using AppMercado.Models;
using AppMercado.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppMercado.Controllers
{
    public class PedidoController : Controller
    {
        
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {            
            _pedidoRepository = pedidoRepository;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            var pedido = _pedidoRepository.getPedido();
            var itens = (pedido == null || pedido.itens == null ) ? new List<ItemPedido>() : pedido.itens;
            return View(itens);
        }
        public ActionResult AdicionarItem(int idProduto) {
            _pedidoRepository.addItem(idProduto);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult removerItem(int idProduto)
        {
            _pedidoRepository.removeItem(idProduto);
            return RedirectToAction(nameof(Index));
        }

        
        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }
        
    }
}
