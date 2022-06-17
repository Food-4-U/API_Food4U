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
    [Route("[action]/{id}")]
    public IEnumerable<Pedido> GetPedidosCliente(string id)
    {
        return Pedido.GetPedidosClientes(id);
    }
    

    [HttpPost]
    [Route("[action]")]
    public string RegistarPedidos([FromBody]Pedido pedido)
    {
        return Pedido.AdicionarPedido(pedido);
    }

    [HttpGet]
    [Route("[action]/{id_cliente}")]
    public Pedido GetPedidoDataCliente([FromBody]string dataHora, string id_cliente)
    {
        return Pedido.GetPedido(dataHora, id_cliente);
    }

    [HttpGet]
    [Route("[action]")]
    public decimal? GetAvgPedido()
    {
        return Pedido.GetAvgPedido();
    }
    
    [HttpGet]
    [Route("[action]/{genero}")]
    public decimal? GetAvgPedidoGenero(string genero)
    {
        return Pedido.GetAvgPedidoGenero(genero);
    }
}