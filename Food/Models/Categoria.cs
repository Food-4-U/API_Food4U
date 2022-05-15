using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Exercicio2.Models;

public class Categoria
{
    [Key] public int id_categoria { get; set; }
    public string? nome { get; set; }
    public double? faturado { get; set; }

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
            categoria.faturado = reader.GetDouble(2);

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
            categoria.faturado = reader.GetDouble(2);

            dbCon.Close();
            return categoria;
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
            categoria.faturado = reader.GetDouble(2);

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
            "INSERT INTO categorias (id_categoria, nome, faturado) VALUES ('" + 
            categoria.id_categoria + "', '" +
            categoria.nome + "', '" +
            categoria.faturado + "');");
        
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
}