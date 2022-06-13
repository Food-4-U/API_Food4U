using Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food.Controllers;

public class CartaoController
{
    [HttpGet]
    [Route("[action]/{id}")]
    public IEnumerable<Cartao> GetCartoesCliente(string id)
    {
        return Cartao.GetCartaoCliente(id);
    }
    

    [HttpPost]
    [Route("[action]")]
    public string RegistarCartao([FromBody]Cartao cartao)
    {
        return Cartao.AdicionarCartao(cartao);
    }
}