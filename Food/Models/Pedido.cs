namespace Food.Models;

public class Pedido
{
    public int id_pedido { get; set; }
    public DateTime data { get; set; }
    public decimal total { get; set; }
    public Boolean pago { get; set; }
    public decimal avaliação { get; set; }
    public decimal aval_funcio { get; set; }
    public int id_mesa { get; set; }

    public int id_cliente { get; set; }

    public Pedido()
    {
        
    }
    
    public static string AdicionarPedido(Pedido pedido)
    {
        var dbCon = new DataBaseConnection();
        var destaqueResult = 0;
        
        var result = dbCon.DbNonQuery(
            "INSERT INTO pedidos (id_pedido, data, total, pago, avaliação, aval_funcio, id_mesa, id_cliente) VALUES ('" +
            pedido.id_pedido + "', '" +
            pedido.data + "', '" +
            pedido.total + "', '" +
            pedido.pago + "', '" +
            pedido.avaliação + "', '" +
            pedido.aval_funcio + "', '" +
            pedido.id_mesa + "', '" +
            pedido.id_cliente + "');");
        
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
    
    public static List<Pedido> GetPedidosClientes(string id)
    {

        List<Pedido> pedidos = new List<Pedido>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM pedidos WHERE id_cliente = " + id + ";");
        while (reader.Read())
        {
            Pedido pedido = null;
            pedido.id_pedido = reader.GetInt32(0);
            pedido.data = reader.GetDateTime(1);
            pedido.total = reader.GetDecimal(2);
            pedido.pago = reader.GetBoolean(3);
            pedido.avaliação = reader.GetDecimal(4);
            pedido.aval_funcio = reader.GetDecimal(5);
            pedido.id_mesa = reader.GetInt32(6);
            pedido.id_cliente = reader.GetInt32(7);
            
            pedidos.Add(pedido);
        }

        dbCon.Close();
        return pedidos;

    }
    
    public static List<Pedido> GetAllPedidos()
    {

        List<Pedido> pedidos = new List<Pedido>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM pedidos;");
        while (reader.Read())
        {
            Pedido pedido = null;
            pedido.id_pedido = reader.GetInt32(0);
            pedido.data = reader.GetDateTime(1);
            pedido.total = reader.GetDecimal(2);
            pedido.pago = reader.GetBoolean(3);
            pedido.avaliação = reader.GetDecimal(4);
            pedido.aval_funcio = reader.GetDecimal(5);
            pedido.id_mesa = reader.GetInt32(6);
            pedido.id_cliente = reader.GetInt32(7);
            
            pedidos.Add(pedido);
        }

        dbCon.Close();
        return pedidos;

    }
}


