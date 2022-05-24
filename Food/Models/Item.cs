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
    public int destaque { get; set; }
    public string? url { get; set; } 
    public int? id_categoria { get; set; }
    public int? id_subcategoria { get; set; }

    public Item()
    {

    }
    
    public static List<Item> GetAllItems()
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDouble(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetInt32(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static List<Item> GetItemCategory(string categoria)
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE categoria = " + categoria + ";");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDouble(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetInt32(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static Item? GetItem(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE id_item = " + id + ";");
        if (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDouble(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetInt32(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);

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
            "INSERT INTO itens (id_item, nome, preco, temp_prep, destaque, url, id_categoria, id_subcategoria) VALUES ('" +
            item.id_item + "', '" +
            item.nome + "', '" +
            item.preco + "', '" +
            item.temp_prep + "', '" +
            item.destaque + "', '" +
            item.url  + "', '" +
            item.id_categoria  + "', '" +
            item.id_subcategoria + "');");

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
            "UPDATE itens SET " + 
            "nome = '" + item.nome + "' " +
            "preco = '" + item.preco + "' " +
            "temp_prep = '" + item.temp_prep + "' " +
            "destaque = '" + item.destaque + "' " +
            "url = '" + item.url + "' " +
            "id_categoria = '" + item.id_categoria + "' " +
            "ïd_subcategoria = '" + item.id_subcategoria + "' " +
            "WHERE id_item = " + id + ";";
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

        String strQuery = "DELETE FROM itens where id_item = " + id + ";";

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