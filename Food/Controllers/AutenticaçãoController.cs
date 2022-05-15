using Microsoft.AspNetCore.Mvc;
using Food.Models;
using Food.Utils;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticaçãoController : ControllerBase
    {
        //POST api/<AutenticaçãoController>
        //[HttpPost]
        //[Route("[action]")] 
        //public void Registar([FromBody] Cliente cliente)
        //{
            //cliente.password = CryptoUtils.Sha256(cliente.password);

            //return Cliente.Registar(cliente);
            
            /*
            clientes clientesOnDb = db.Utilizadores.Where(uti => uti.Email.Equals(utilizador.Email)).FirstOrDefault();

            if (utilizadorOnDb == null)
            {

                utilizador.password = CryptoUtils.Sha256(utilizador.password);
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();

                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            }
        
            */
        }

        
        /*
        [HttpPost]
        [Route("[action]")]
        public void Login([FromBody] Utilizadores utilizador)
        {
            using (var db = new DbHelper())
            {
                Utilizadores utilizadorOnDb = db.Utilizadores.Where(uti => uti.Email.Equals(utilizador.Email)).FirstOrDefault();

                
                if (utilizadorOnDb != null)
                {
                    utilizador.Password = CryptoUtils.Sha256(utilizador.Password);

                    if (utilizadorOnDb.Password == utilizador.Password)
                    {
                        HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
        */}
    //}

