using Exercicio2.Models;
using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Food.Utils;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        // GET: api/<UtilizadoresController>
        [HttpGet(Name = "GetCategoria")]
        public IEnumerable<Categoria> Get()
        {
            return Categoria.GetAllItems();
        }

        [HttpGet]
        [Route("[action]/{id}")]

        public Categoria Get(string id)
        {
            return Categoria.GetItem(id);
        }
        
        [HttpGet]
        [Route("[action]/{name}")]

        public Categoria GetCategoria(string name)
        {
            return Categoria.GetCategoria(name);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<string> GetNome()
        {
            return Categoria.GetNome();
        }
        
        [HttpGet]
        [Route("[action]/{name}")]
        public int? GetIDCategory(string name)
        {
            return Categoria.GetIDCategoria(name);
        }

        [HttpPost]
        [Route("[action]")]
        public string AdicionarCategoria([FromBody] Categoria categoria)
        {
            if (Categoria.GetCategoria(categoria.nome) == null)
            {
                return Categoria.AdicionarCategoria(categoria);
            }
            else
            {
                return "Ingrediente já registado";
            }
        }
            
        [HttpPut("[action]/{id}")]
        public string Update(string id, [FromBody] Categoria categoria)
        {
            Categoria categoriaOnDB = Categoria.GetItem(id);

            if (categoria.nome == null)
            {
                categoria.nome = categoriaOnDB.nome;
            }

            if (categoria.url == null)
            {
                categoria.url = categoriaOnDB.url;
            }

            return Categoria.Update(id ,categoria);
        }
        
        [HttpDelete("[action]/{id}")]
        public string Delete(string id)
        {
            if (Categoria.GetItem(id) != null)
            {
                return Categoria.Delete(id);
            }
            else
            {
                return "Categoria não existe";
            }
        }
    
    }
}

