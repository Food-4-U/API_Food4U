﻿using Microsoft.AspNetCore.Mvc;
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
