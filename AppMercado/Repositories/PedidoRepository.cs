using AppMercado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppMercado.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public PedidoRepository(appDbContext contexto,
            IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this._contextAccessor = contextAccessor;
        }



        public Pedido getPedido()
        {
            var idPedido = getPedidoId();
            var pedido = dbSet.Include(p => p.itens).
                 ThenInclude(i => i.produto)
                 .Where(p => p.idPedido == idPedido)
                 .SingleOrDefault();
            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                _contexto.SaveChanges();
                setPedidoId(pedido.idPedido);
            }
            return pedido;
        }

        public void setPedidoId(int idPedido)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", idPedido);
        }
        public int? getPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public void addItem(int idProduto)
        {
            var produto = _contexto.Set<Produto>().Where(p => p.id == idProduto).SingleOrDefault();
            if (produto == null)
            {
                throw new ArgumentException("Produto não cadastrado.");
            }

            var pedido = getPedido();
            var itemPedido = _contexto.Set<ItemPedido>().
                                        Where(i => i.produto.id == idProduto && i.pedido.idPedido == pedido.idPedido)
                                        .SingleOrDefault();
            if (itemPedido == null)
            {
                itemPedido = new ItemPedido() { pedido = pedido, produto = produto, quantidade = 1, valorUnitario = produto.valor };
                _contexto.Set<ItemPedido>().Add(itemPedido);
                _contexto.SaveChanges();
            }
            else
            {
                itemPedido.quantidade++;
                itemPedido.valorUnitario = produto.valor;
                _contexto.Set<ItemPedido>().Update(itemPedido);
                _contexto.SaveChanges();
            }
        }

        public void removeItem(int idProduto)
        {
            var produto = _contexto.Set<Produto>().Where(p => p.id == idProduto).SingleOrDefault();
            if (produto == null)
            {
                throw new ArgumentException("Produto não cadastrado.");
            }

            var pedido = getPedido();
            var itemPedido = _contexto.Set<ItemPedido>().
                                        Where(i => i.produto.id == idProduto && i.pedido.idPedido == pedido.idPedido)
                                        .SingleOrDefault();
            if (itemPedido != null)
            {
                itemPedido.quantidade--;
                if (itemPedido.quantidade == 0)
                {
                    _contexto.Set<ItemPedido>().Remove(itemPedido); 
                }
                else { 
                    itemPedido.valorUnitario = produto.valor;
                    _contexto.Set<ItemPedido>().Update(itemPedido);
                }
                _contexto.SaveChanges();
            }
        }
    }
}
