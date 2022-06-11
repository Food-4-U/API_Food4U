using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers;

public class CartaoController
{
    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Cartao> GetCartoesCliente(string id)
    {
        return Cartao.GetCartaoCliente(id);
    }
    

    [HttpPost]
    [Route("[action]/{id}")]
    public string RegistarCartao(Cartao cartao)
    {
        return Cartao.AdicionarCartao(cartao);
    }
}