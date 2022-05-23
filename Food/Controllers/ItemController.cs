using Microsoft.AspNetCore.Mvc;
using Food.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        // GET: api/<UtilizadoresController>
        [HttpGet(Name = "GetItem")]
        public IEnumerable<Item> Get()
        {
            return Item.GetAllItems();
        }
        
        //Get categoria
        [HttpGet]
        [Route("[action]/{categoria}")]
        public IEnumerable<Item> ItemCategoria(string categoria)
        {
            return Item.GetItemCategory(categoria);
        }
        
        
        [HttpPost]
        [Route("[action]")]
        public string AdicionarItem([FromBody] Item item)
        {
            if (Item.GetItem(item.nome) == null)
            {
                return Item.AdicionarItem(item);
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }
        
        // Atualizar necessita id
        [HttpPut("[action]/{id}")]
        public string Update(string id, [FromBody] Item item)
        {
            Item itemOnDb = Item.GetItem(id);

            if (item.nome == null)
            {
                item.nome = itemOnDb.nome;
            }

            if (item.preco == null)
            {
                item.preco = itemOnDb.preco;
            }

            if (item.temp_prep == null)
            {
                item.temp_prep = itemOnDb.temp_prep;
            }

            if (item.favorito == null)
            {
                item.favorito = itemOnDb.favorito;
            }

            if (item.faturado == null)
            {
                item.faturado = itemOnDb.faturado;
            }

            if (item.url == null)
            {
                item.url = itemOnDb.url;
            }

            return Item.Update(id, item);
        }

        [HttpDelete("[action]/{id}")]
        public string Delete(string id)
        {
            if (Item.GetItem(id) != null)
            {
                return Item.Delete(id);
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }

    }
}

