using Microsoft.AspNetCore.Mvc;
using Exercicio2.Models;
using Exercicio2.Utils;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
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

        [HttpPost]
        [Route("[action]")]
        public string Adicionar([FromBody] Ingrediente ingrediente)
        {
            if (Ingrediente.GetIngrediente(ingrediente.nome) == null)
            {
                return Ingrediente.Adicionar(ingrediente);
            }
            else
            {
                return "Ingrediente já registado";
            }
        }

        /*
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
                    return cliente.password;
                }
            }
            else
            {
                return "Email non existent";
            }
        }
        */
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

