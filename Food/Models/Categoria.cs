using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Exercicio2.Models;

public class Categoria
{
    [Key] public int id_categoria { get; set; }
    public string? nome { get; set; }
    public string? url { get; set; }

    public Categoria()
    {
        
    }
    
    public static List<Categoria> GetAllItems()
    {
        List<Categoria> categorias = new List<Categoria>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM categorias");

        while (reader.Read())
        {
            var categoria = new Categoria();
            categoria.id_categoria = reader.GetInt32(0);
            categoria.nome = reader.GetString(1);
            categoria.url = reader.GetString(2);

            categorias.Add(categoria);
        }

        dbCon.Close();
        return categorias;
    }
    
    public static Categoria? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM categorias WHERE id_categoria = " + id + ";");
        if (reader.Read())
        {
            var categoria = new Categoria();
            categoria.id_categoria = reader.GetInt32(0);
            categoria.nome = reader.GetString(1);
            categoria.url = reader.GetString(2);

            dbCon.Close();
            return categoria;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static List<string> GetNome()
    {

        List<string> nomes = new List<string>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT nome FROM categorias");
        while (reader.Read())
        {
            var nome = "";
            nome = reader.GetString(0);
            
            nomes.Add(nome);
        }

        dbCon.Close();
        return nomes;

    }

    public static int? GetIDCategoria(string name)
    {

        var id = new int();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT id_categoria FROM categorias WHERE nome = '" + name + "';");
        if (reader.Read())
        {
            id = reader.GetInt32(0);
            dbCon.Close();
            return id;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }


    public static Categoria? GetCategoria(string desc)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM categorias WHERE nome = '" + desc + "';");
        if (reader.Read())
        {
            var categoria = new Categoria();
            categoria.id_categoria = reader.GetInt32(0);
            categoria.nome = reader.GetString(1);
            categoria.url = reader.GetString(2);

            dbCon.Close();
            return categoria;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static string AdicionarCategoria(Categoria categoria)
    {
        var dbCon = new DataBaseConnection();
        var result = dbCon.DbNonQuery(
            "INSERT INTO categorias (id_categoria, nome, url) VALUES ('" + 
            categoria.id_categoria + "', '" +
            categoria.nome + "', '" +
            categoria.url + "');");
        
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }
    
    public static string Update(string id, Categoria categoria)
    {
        var dbCon = new DataBaseConnection();
            
        String strQuery = 
            "UPDATE categorias SET " + 
            "nome = '" + categoria.nome + "', " +
            "url = '" + categoria.url + "' " +
            "WHERE id_categoria = " + id + ";";
        var result = dbCon.DbNonQuery(strQuery);
            
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }
    
    public static string Delete(string id)
    {
        var dbCon = new DataBaseConnection();

        String strQuery = "DELETE FROM categorias where id_categoria = " + id + ";";

        var result = dbCon.DbNonQuery(strQuery);
            
        dbCon.Close();
        if (result > 0)
        {
            return "{ \"status\" :\"ok\" }";
        }
        else
        {
            return "{ \"status\" :\"error\" }";
        }
    }
    
    //Create a method to add user
    
    
    
    
    
    
}