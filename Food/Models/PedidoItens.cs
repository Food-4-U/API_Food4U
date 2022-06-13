namespace Food.Models;

public class PedidoItens
{
    public int id_pedido_item { get; set; }
    public int id_pedido { get; set; }
    public int id_item { get; set; }
    public int qtd { get; set; }

    public PedidoItens()
    {
        
    }
    
    public static string AdicionarPedidoItem(PedidoItens pedidoItem)
    {
        var dbCon = new DataBaseConnection();

        var result = dbCon.DbNonQuery(
            "INSERT INTO pedidos_itens (id_pedido_item, id_pedido, id_item, qtd) VALUES ('" +
            pedidoItem.id_pedido_item + "', '" +
            pedidoItem.id_pedido + "', '" +
            pedidoItem.id_item + "', '" +
            pedidoItem.qtd + "');");
        
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

    public static List<PedidoItensFatura> GetItemsFromPedido(string id_pedido)
    {
        List<PedidoItensFatura> itens = new List<PedidoItensFatura>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT i.nome, pi.qtd, i.preco FROM pedidos_itens pi JOIN itens i USING (id_item) WHERE id_pedido = " + id_pedido + ";");
        while (reader.Read())
        {
            PedidoItensFatura item = new PedidoItensFatura();
            item.nome = reader.GetString(0);
            item.qtd = reader.GetInt32(1);
            item.preco = reader.GetDecimal(2);

            itens.Add(item);
        }

        dbCon.Close();
        return itens;
    }
}

public class PedidoItensFatura
{
    public string nome { get; set; }
    public int qtd { get; set; }
    public decimal preco { get; set; }
}