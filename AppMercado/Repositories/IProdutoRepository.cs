using AppMercado.Models;
using System.Collections.Generic;

namespace AppMercado.Repositories
{
    public interface IProdutoRepository
    {
        void saveProdutos(List<Produto> produtos);
        public List<Produto> getAll();
        public Produto getById(int idProduto);
        public bool updateProduto(Produto produto);        
    }
}