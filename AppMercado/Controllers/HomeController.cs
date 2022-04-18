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

        public HomeController(IProdutoRepository produtoRepository
         )
        {
            _produtoRepository = produtoRepository;
        }
        public ActionResult Index()
        {
            var data = _produtoRepository.getAll();
            return View(data);
        }
    }
}
