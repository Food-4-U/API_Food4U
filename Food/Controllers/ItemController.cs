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

        [HttpGet]
        [Route("[action]/{id}")]
        public Item Get(string id)
        {
            return Item.GetItem(id);
        }

        //Get categoria
        [HttpGet]
        [Route("[action]/{categoria}")]
        public IEnumerable<Item> ItemCategoria(string categoria)
        {
            return Item.GetItemCategory(categoria);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Item> ItemTopRated()
        {
            return Item.GetItemTopRated();
        }
        
        [HttpGet]
        [Route("[action]/{subcategoria}")]
        public IEnumerable<Item> ItemSubcategoria(string subcategoria)
        {
            return Item.GetItemSubcategory(subcategoria);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Item> ItemHot()
        {
            return Item.GetItemHot();
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Item> OrderCategory()
        {
            return Item.GetItemsOrderCategory();
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public IEnumerable<Item> Favoritos(string id)
        {
            return Item.Favorito(id);
        }
        
        [HttpGet]
        [Route("[action]/{nome}")]
        public IEnumerable<Item> Search(string nome)
        {
            return Item.SearchItem(nome);
        }
        
        
        [HttpPost]
        [Route("[action]")]
        public string AdicionarItem([FromBody] Item item)
        {
            if (Item.GetItemNome(item.nome) == null)
            {
                return Item.AdicionarItem(item);
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public string ItemURL(string id)
        {
            return Item.GetImageURL(id);
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

            if (item.destaque == null)
            {
                item.destaque = itemOnDb.destaque;
            }

            if (item.url == null)
            {
                item.url = itemOnDb.url;
            }
            
            if (item.id_categoria == null)
            {
                item.id_categoria = itemOnDb.id_categoria;
            }
            if (item.id_subcategoria == null)
            {
                item.id_subcategoria = itemOnDb.id_subcategoria;
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

        [HttpPost]
        [Route("[action]/{id_cliente}/{id_item}")]
        public string AddFavorito(string id_cliente, string id_item)
        {
            return Item.AdicionarItemFavoritos(id_cliente, id_item);
        }
        
        [HttpDelete]
        [Route("[action]/{id_cliente}/{id_item}")]
        public string DeleteFavorito(string id_cliente, string id_item)
        {
            return Item.DeleteFromFavoritos(id_cliente, id_item);
        }

    }
}

