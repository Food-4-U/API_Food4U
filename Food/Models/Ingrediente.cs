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
    
}