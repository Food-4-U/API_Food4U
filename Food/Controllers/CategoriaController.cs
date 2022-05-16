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

        
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Categoria categoria)
        {
            Categoria categoriaOnDB = Categoria.GetItem(id);
        }
        

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

