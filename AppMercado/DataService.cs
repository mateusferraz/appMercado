using AppMercado.Models;
using AppMercado.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AppMercado
{
    public class DataService : IDataService
    {
        private readonly appDbContext _contexto;
        private readonly IProdutoRepository _produtoRepository;
        public DataService(appDbContext contexto,
                            IProdutoRepository produtoRepository
        )
        {
            this._contexto = contexto;
            this._produtoRepository = produtoRepository;
        }
        public void InincializaDB()
        {
            _contexto.Database.Migrate();
            var json = File.ReadAllText("Files/produtos.json");

            var produtos = JsonConvert.DeserializeObject<List<Produto>>(json);

            _produtoRepository.saveProdutos(produtos);
        }

    }

}
