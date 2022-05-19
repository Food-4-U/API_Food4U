using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Food.Models;

public class Item
{
    [Key] public int id_item { get; set; }
    public string? nome { get; set; }
    public double? preco { get; set; }
    public int temp_prep { get; set; }
    public int favorito { get; set; }
    public double faturado { get; set; }
    public string? url { get; set; } 

    public Item()
    {

    }
    
    public static List<Item> GetAllItems()
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM item");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDouble(2);
            item.temp_prep = reader.GetInt32(3);
            item.favorito = reader.GetInt32(4);
            item.faturado = reader.GetDouble(5);
            item.url = reader.GetString(6);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }
    
    public static Item? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM item WHERE id_item = " + id + ";");
        if (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDouble(2);
            item.temp_prep = reader.GetInt32(3);
            item.favorito = reader.GetInt32(4);
            item.faturado = reader.GetDouble(5);
            item.url = reader.GetString(6);

            dbCon.Close();
            return item;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }
    
    public static string AdicionarItem(Item item)
    {
        var dbCon = new DataBaseConnection();
        var result = dbCon.DbNonQuery(
            "INSERT INTO item (id_item, nome, preco, temp_prep, favorito, faturado, url) VALUES ('" +
            item.id_item + "', '" +
            item.nome + "', '" +
            item.preco + "', '" +
            item.temp_prep + "', '" +
            item.favorito + "', '" +
            item.faturado + "', '" +
            item.url + "');");

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

    public static string Update(string id, Item item)
    {
        var dbCon = new DataBaseConnection();
            
        String strQuery = 
            "UPDATE ingredientes SET " + 
            "nome = '" + item.nome + "' " +
            "preco = '" + item.preco + "' " +
            "temp_prep = '" + item.temp_prep + "' " +
            "favorito = '" + item.favorito + "' " +
            "faturado = '" + item.faturado + "' " +
            "url = '" + item.url + "' " +
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

        String strQuery = "DELETE FROM item where id_ingrediente = " + id + ";";

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