using AppMercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppMercado.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(appDbContext contexto) : base(contexto)
        {

        }

        public void saveProdutos(List<Produto> produtos)
        {
            foreach (var item in produtos)
            {
                
                if (!dbSet.Where(x => x.id == item.id).Any())
                {
                    dbSet.Add(item);
                }
                //_contexto.Produtos.Add(item);
            }
            _contexto.SaveChanges();
        }

        //public List<Produto> getAllProdutos()
        //{
        //    return dbSet.ToList();
        //}
        public Produto getById(int idProduto)
        {
            return dbSet.SingleOrDefault(x => x.id == idProduto);
        }
        public bool updateProduto (Produto produto)
        {            
            if(produto == null)
            {
                throw new ArgumentException("Produto não cadastrado");
            }
            dbSet.Update(produto);
            _contexto.SaveChanges();
            return true;
        }

    }
}
