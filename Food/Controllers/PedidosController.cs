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
    [Route("[action]/{id_cliente}/{date}")]
    public Pedido GetPedidoDataCliente(string id_cliente, string date)
    {
        return Pedido.GetPedido(date, id_cliente);
    }
    
    [HttpGet]
    [Route("[action]/{id}")]
    public Pedido GetPedidoID(string id)
    {
        return Pedido.GetPedidoID(id);
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

    [HttpGet]
    [Route("[action]/{genero}")]
    public decimal? GetCountPedidoGenero(string genero)
    {
        return Pedido.GetCountPedidoGenero(genero);
    }
    
    [HttpGet]
    [Route("[action]")]
    public decimal? GetTotalPedido()
    {
        return Pedido.GetTotalPedido();
    }
    
    [HttpGet]
    [Route("[action]")]
    public decimal? GetDesvPedido()
    {
        return Pedido.GetDesvPedido();
    }
}