using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Food.Utils;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        // GET: api/<UtilizadoresController>
        [HttpGet(Name = "GetClientes")]
        public IEnumerable<Cliente> Get()
        {
            return Cliente.GetAllItems();
        }

        // Atualizar necessita id
        [HttpPut("[action]/{id}")]
        public string Update(string id, [FromBody] Cliente cliente)
        {
            Cliente clienteOnDB = Cliente.GetItem(id);

            if (cliente.nome == null)
            {
                cliente.nome = clienteOnDB.nome;
            }

            if (cliente.email == null)
            {
                cliente.email = clienteOnDB.email;
            }

            if (cliente.password == null)
            {
                cliente.password = clienteOnDB.password;
            }

            if (cliente.nif == null)
            {
                cliente.nif = clienteOnDB.nif;
            }

            return Cliente.Update(id, cliente);
        }

        [HttpPost]
        [Route("[action]")]
        public string Registar([FromBody] Cliente cliente)
        {
            if (Cliente.GetEmail(cliente.email) == null)
            {
                cliente.password = CryptoUtils.Sha256(cliente.password);

                return Cliente.Registar(cliente);
            }
            else
            {
                return "Cliente já registado";
            }
        }


        [HttpPost]
        [Route("[action]")]

        public string Login([FromBody] Cliente cliente)
        {
            if (Cliente.GetEmail(cliente.email) != null)
            {
                cliente.password = CryptoUtils.Sha256(cliente.password);

                if (Cliente.ClienteLogin(cliente.email, cliente.password) != null)
                {
                    return "{ \"status\" :\"ok\" }";
                }
                else
                {
                    return "{ \"status\" :\"err\" }";
                }
            }
            else
            {
                return "{ \"status\" :\"err\" }";
            }
        }

        [HttpDelete("[action]/{id}")]
        public string Delete(string id)
        {
            if (Cliente.GetItem(id) != null)
            {
                return Cliente.Delete(id);
            }
            else
            {
                return "Cliente não existe";
            }
        }

    }
}
