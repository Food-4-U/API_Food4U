﻿using Microsoft.AspNetCore.Mvc;
using Exercicio2.Models;
using Exercicio2.Utils;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercicio2.Controllers
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
            
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Categoria categoria)
        {
            Categoria categoriaOnDB = Categoria.GetItem(id);
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

