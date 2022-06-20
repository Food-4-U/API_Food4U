using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Food.Models;

public class Item
{
    [Key] public int id_item { get; set; }
    public string? nome { get; set; }
    public decimal? preco { get; set; }
    public int temp_prep { get; set; }
    public Boolean destaque { get; set; }
    public string? url { get; set; }
    public int? id_categoria { get; set; }
    public int? id_subcategoria { get; set; }

    public decimal? avaliação { get; set; }

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
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static List<Item> GetItemsOrderCategory()
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens ORDER BY id_categoria");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static List<Item> GetItemCategory(string categoria)
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE id_categoria = " + categoria + ";");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static List<Item> GetItemSubcategory(string subcategoria)
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE id_subcategoria = " + subcategoria + ";");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }

    public static List<Item> GetItemHot()
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE destaque = " + 1 + ";");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            items.Add(item);
        }

        dbCon.Close();
        return items;
    }
    
    public static List<Item> GetItemTopRated()
    {
        List<Item> items = new List<Item>();

        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE id_categoria = " + 2 + " ORDER BY avaliação DESC LIMIT 4;");

        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

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
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            dbCon.Close();
            return item;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static string? GetImageURL(string id)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE id_item = " + id + ";");
        if (reader.Read())
        {
            var item = new Item();
            item.url = reader.GetString(5);

            dbCon.Close();
            return item.url;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }

    public static Item? GetItemNome(string nome)
    {
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE nome = '" + nome + "';");
        if (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);

            dbCon.Close();
            return item;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }
    
    public static List<Item>? SearchItem(string nome)
    {
        List<Item> items = new List<Item>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM itens WHERE nome LIKE '%" + nome + "%';");
        
        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);
            items.Add(item);
        }
       
        dbCon.Close();
        return items;
    }

    public static string AdicionarItem(Item item)
    {
        var dbCon = new DataBaseConnection();
        var destaqueResult = 0;

        if (item.destaque)
        {
            destaqueResult = Convert.ToInt32(item.destaque);
        }
        else
        {
            destaqueResult = Convert.ToInt32(item.destaque);
        }

        var result = dbCon.DbNonQuery(
            "INSERT INTO itens (id_item, nome, preco, temp_prep, destaque, url, id_categoria, id_subcategoria, avaliação) VALUES ('" +
            item.id_item + "', '" +
            item.nome + "', '" +
            item.preco + "', '" +
            item.temp_prep + "', '" +
            destaqueResult + "', '" +
            item.url + "', '" +
            item.id_categoria + "', '" +
            item.id_subcategoria + "', '" +
            item.avaliação + "');");
        
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
    
    public static string AdicionarItemFavoritos(string id_cliente, string id_item)
    {
        var dbCon = new DataBaseConnection();
        var destaqueResult = 0;

        var result = dbCon.DbNonQuery(
            "INSERT INTO favoritos (id_favoritos, favorito, clientes_id, itens_id_item) VALUES ('" +
            null + "', '" +
            1 + "', '" +
            id_cliente + "', '" +
            id_item + "');");
        
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

    public static string DeleteFromFavoritos(string id_cliente, string id_item)
    {
        var dbCon = new DataBaseConnection();
        var destaqueResult = 0;

        var result = dbCon.DbNonQuery(
            "DELETE FROM favoritos WHERE clientes_id = '" + id_cliente + "' AND itens_id_item = '" + id_item + "';");
        
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

    public static List<Item> Favorito(string id)
    {
        List<Item> items = new List<Item>();
        
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT i.* FROM favoritos f Join itens i ON f.itens_id_item = i.id_item WHERE clientes_id = '" + id + "' AND favorito = 1;");
        while (reader.Read())
        {
            var item = new Item();
            item.id_item = reader.GetInt32(0);
            item.nome = reader.GetString(1);
            item.preco = reader.GetDecimal(2);
            item.temp_prep = reader.GetInt32(3);
            item.destaque = reader.GetBoolean(4);
            item.url = reader.GetString(5);
            item.id_categoria = reader.GetInt32(6);
            item.id_subcategoria = reader.GetInt32(7);
            item.avaliação = reader.GetDecimal(8);
            items.Add(item);
        }
       
        dbCon.Close();
        return items;
    }

    public static string Update(string id, Item item)
    {
        var dbCon = new DataBaseConnection();
            
        String strQuery = 
            "UPDATE itens SET " + 
            "nome = '" + item.nome + "', " +
            "preco = '" + item.preco + "', " +
            "temp_prep = '" + item.temp_prep + "', " +
            "destaque = '" + item.destaque + "', " +
            "url = '" + item.url + "', " +
            "id_categoria = " + item.id_categoria + ", " +
            "id_subcategoria = " + item.id_subcategoria + ", " +
            "avaliação = '" + item.avaliação + "' " +
            "WHERE id_item = " + id;
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