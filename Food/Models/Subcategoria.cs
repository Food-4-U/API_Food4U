using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Food;

namespace Food.Models;

public class Subcategoria
{
    [Key] public int id_subcategoria { get; set; }
    public string? nome { get; set; }
    

    public Subcategoria()
    {
        
    }
    
    public static List<Subcategoria> GetAllItems()
    {
        List<Subcategoria> subcategorias = new List<Subcategoria>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM subcategorias");

        while (reader.Read())
        {
            var subcategoria = new Subcategoria();
            subcategoria.id_subcategoria = reader.GetInt32(0);
            subcategoria.nome = reader.GetString(1);

            subcategorias.Add(subcategoria);
        }

        dbCon.Close();
        return subcategorias;
    }
    
    public static Subcategoria? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM subcategorias WHERE id_subcategoria = " + id + ";");
        if (reader.Read())
        {
            var subcategoria = new Subcategoria();
            subcategoria.id_subcategoria = reader.GetInt32(0);
            subcategoria.nome = reader.GetString(1);
          

            dbCon.Close();
            return subcategoria;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static Subcategoria? GetSubcategoria(string desc)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM subcategorias WHERE nome = '" + desc + "';");
        if (reader.Read())
        {
            var subcategoria = new Subcategoria();
            subcategoria.id_subcategoria = reader.GetInt32(0);
            subcategoria.nome = reader.GetString(1);
           

            dbCon.Close();
            return subcategoria;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static string AdicionarSubcategoria(Subcategoria subcategoria)
    {
        var dbCon = new DataBaseConnection();
        var result = dbCon.DbNonQuery(
            "INSERT INTO subcategorias (id_subcategoria, nome) VALUES ('" + 
            subcategoria.id_subcategoria + "', '" +
            subcategoria.nome + "');");
        
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
    
    public static string Update(string id, Subcategoria subcategoria)
    {
        var dbCon = new DataBaseConnection();
            
        String strQuery = 
            "UPDATE subcategorias SET " + 
            "nome = '" + subcategoria.nome + "' " +
            "WHERE id_subcategoria = " + id + ";";
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

        String strQuery = "DELETE FROM subcategorias where id_subcategorias = " + id + ";";

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
}