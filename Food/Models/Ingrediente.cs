using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Exercicio2.Models;

public class Ingrediente
{
    [Key] public int id_ingrediente { get; set; }
    public string? nome { get; set; }

    public Ingrediente()
    {

    }

    public static List<Ingrediente> GetAllItems()
    {
        List<Ingrediente> ingredientes = new List<Ingrediente>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM ingredientes");

        while (reader.Read())
        {
            var ingrediente = new Ingrediente();
            ingrediente.id_ingrediente = reader.GetInt32(0);
            ingrediente.nome = reader.GetString(1);

            ingredientes.Add(ingrediente);
        }

        dbCon.Close();
        return ingredientes;
    }

    public static Ingrediente? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM ingredientes WHERE id_ingrediente = " + id + ";");
        if (reader.Read())
        {
            var ingrediente = new Ingrediente();
            ingrediente.id_ingrediente = reader.GetInt32(0);
            ingrediente.nome = reader.GetString(1);

            dbCon.Close();
            return ingrediente;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static Ingrediente? GetIngrediente(string desc)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM ingredientes WHERE nome = '" + desc + "';");
        if (reader.Read())
        {
            var ingrediente = new Ingrediente();
            ingrediente.id_ingrediente = reader.GetInt32(0);
            ingrediente.nome = reader.GetString(1);

            dbCon.Close();
            return ingrediente;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static string AdicionarIngrediente(Ingrediente ingrediente)
    {
        var dbCon = new DataBaseConnection();
        var result = dbCon.DbNonQuery(
            "INSERT INTO ingredientes (id_ingrediente, nome) VALUES ('" +
            ingrediente.id_ingrediente + "', '" +
            ingrediente.nome + "');");

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

    public static string Update(string id, Ingrediente ingrediente)
    {
        var dbCon = new DataBaseConnection();
            
        String strQuery = 
            "UPDATE ingredientes SET " + 
            "nome = '" + ingrediente.nome + "' " +
            "WHERE id_ingrediente = " + id + ";";
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

        String strQuery = "DELETE FROM ingredientes where id_ingrediente = " + id + ";";

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