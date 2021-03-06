using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers;

public class PedidoItensController: Controller
{
    [HttpPost]
    [Route("[action]")]
    public string RegistarItens([FromBody]PedidoItens pedidoItem)
    {
        return PedidoItens.AdicionarPedidoItem(pedidoItem);
    }

    [HttpGet]
    [Route("[action]/{id_pedido}")]
    public IEnumerable<PedidoItensFatura> GetItems(string id_pedido)
    {
        return PedidoItens.GetItemsFromPedido(id_pedido);
    }
}