using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Food.Utils;
using Food.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {

        // GET: api/<UtilizadoresController>
        [HttpGet(Name = "GetIngredientes")]
        public IEnumerable<Ingrediente> Get()
        {
            return Ingrediente.GetAllItems();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public List<String> GetItensIngredientes(string id)
        {
            return Ingrediente.GetItemIngredientes(id);
        }

        [HttpPost]
        public string AdicionarIngrediente([FromBody] Ingrediente ingrediente)
        {
            if (Ingrediente.GetIngrediente(ingrediente.nome) == null)
            {
                return Ingrediente.AdicionarIngrediente(ingrediente);
            }
            else
            {
                return "Ingrediente já registado";
            }
        }
        
        // Atualizar necessita id
        [HttpPut("[action]/{id}")]
        public string Update(string id, [FromBody] Ingrediente ingrediente)
        {
            Ingrediente ingredienteOnDB = Ingrediente.GetItem(id);

            if (ingrediente.nome == null)
            {
                ingrediente.nome = ingredienteOnDB.nome;
            }

            return Ingrediente.Update(id, ingrediente);
        }

        [HttpDelete("[action]/{id}")]
        public string Delete(string id)
        {
            if (Ingrediente.GetItem(id) != null)
            {
                return Ingrediente.Delete(id);
            }
            else
            {
                return "Ingrediente não existe";
            }
        }

    }
}

