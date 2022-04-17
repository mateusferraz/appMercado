using AppMercado.Models;
using System.Collections.Generic;

namespace AppMercado.Repositories
{
    public interface IPedidoRepository
    {
        public Pedido getPedido();
        public void setPedidoId(int idPedido);
        public int? getPedidoId();

        public void addItem(int idProduto);

    }
}