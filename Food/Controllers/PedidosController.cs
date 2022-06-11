using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers;

public class PedidosController
{
    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Pedido> GetAllPedidos()
    {
        return Pedido.GetAllPedidos();
    }
    
    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Pedido> GetPedidosCliente(string id)
    {
        return Pedido.GetPedidosClientes(id);
    }
    

    [HttpPost]
    [Route("[action]/{id}")]
    public string RegistarPedidos(Pedido pedido)
    {
        return Pedido.AdicionarPedido(pedido);
    }
}