using Microsoft.AspNetCore.Mvc;
using Food.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {

        // GET: api/<UtilizadoresController>
        [HttpGet(Name = "GetSubcategorias")]
        public IEnumerable<Subcategoria> Get()
        {
            return Subcategoria.GetAllItems();
        }
        
        //Get categoria
        [HttpGet]
        [Route("[action]/{subcategoria}")]
        public Subcategoria ItemCategoria(string subcategoria)
        {
            return Subcategoria.GetSubcategoria(subcategoria);
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public Subcategoria GetItem(string id)
        {
            return Subcategoria.GetItem(id);
        }
        
        [HttpGet]
        [Route("[action]/{name}")]
        public int? GetIDSubcategory(string name)
        {
            return Subcategoria.GetIDSubcategoria(name);
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<string> GetNome()
        {
            return Subcategoria.GetNome();
        }
        
        
        [HttpPost]
        [Route("[action]")]
        public string AdicionarSubcategoria([FromBody] Subcategoria subcategoria)
        {
            if (Subcategoria.GetSubcategoria(subcategoria.nome) == null)
            {
                return Subcategoria.AdicionarSubcategoria(subcategoria);
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }
        
        // Atualizar necessita id
        [HttpPut("[action]/{id}")]
        public string Update(string id, [FromBody] Subcategoria subcategoria)
        {
            Subcategoria subcategoriaOnDb = Subcategoria.GetSubcategoria(id);

            if (subcategoria.nome == null)
            {
                subcategoria.nome = subcategoriaOnDb.nome;
            }
            
            if (subcategoria.url == null)
            {
                subcategoria.url = subcategoriaOnDb.url;
            }
            
            return Subcategoria.Update(id, subcategoria);
        }

        [HttpDelete("[action]/{id}")]
        public string Delete(string id)
        {
            if (Subcategoria.GetItem(id) != null)
            {
                return Subcategoria.Delete(id);
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }

    }
}

