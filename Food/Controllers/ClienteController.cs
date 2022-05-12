using Microsoft.AspNetCore.Mvc;
using Exercicio2.Models;
using Exercicio2.Utils;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
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

        // Atualizar
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Cliente cliente)
        {
            return Cliente.Update(id, cliente);
        }

        [HttpPost]
        [Route("[action]")]
        public string Registar([FromBody] Cliente cliente)
        {
            cliente.password = CryptoUtils.Sha256(cliente.password);

            return Cliente.Registar(cliente);



            /* POST api/<UtilizadoresController>
            [HttpPost]
            public void Post([FromBody] Utilizadores utilizadores)
            {
                using (var db = new DbHelper())
                {
                    utilizadores.id_cliente = new Random().Next();
                    db.Utilizadores.Add(utilizadores);
                    db.SaveChanges();
                }
            }
            */

            /* PUT api/<UtilizadoresController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] Utilizadores utilizadores)
            {
                using (var db = new DbHelper())
                {
                    Utilizadores UtilizadoresOnDb = db.Utilizadores.Find(id);
                    if (UtilizadoresOnDb != null)
                    {
                        UtilizadoresOnDb.Nome = utilizadores.Nome != null ? utilizadores.Nome : UtilizadoresOnDb.Nome;
    
    
                        db.Utilizadores.Update(UtilizadoresOnDb);
                    }
                    else
                    {
                        utilizadores.Cod_Utilizadores = id;
                        db.Utilizadores.Add(utilizadores);
                    }
                    db.SaveChanges();
                }
            }
            */

            /* DELETE api/<UtilizadoresController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                using (var db = new DbHelper())
                {
                    Utilizadores UtilizadoresOnDb = db.Utilizadores.Find(id);
    
                    if (UtilizadoresOnDb != null)
                    {
                        db.Utilizadores.Remove(UtilizadoresOnDb);
                        db.SaveChanges();
                    }
                }
            }
            */
        }
    }
}
