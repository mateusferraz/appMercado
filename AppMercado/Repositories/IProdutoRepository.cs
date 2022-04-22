using AppMercado.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppMercado.Repositories
{
    public interface IProdutoRepository
    {
        void saveProdutos(List<Produto> produtos);
        public List<Produto> getAll();
        public IQueryable<Produto> getAllQuery();
        public Produto getById(int idProduto);
        public bool updateProduto(Produto produto);        
    }
}