using System.Data.SqlTypes;
using MySql.Data.Types;

namespace Food.Models;

public class Pedido
{
    public int id_pedido { get; set; }
    public string dataHora { get; set; }
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

        var result = dbCon.DbNonQuery(
            "INSERT INTO pedidos (id_pedido, dataHora, total, pago, avaliação, aval_funcio, id_mesa, id_cliente) VALUES ('" +
            pedido.id_pedido + "', '" +
            pedido.dataHora + "', '" +
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
        var reader = dbCon.DbQuery("SELECT * FROM pedidos WHERE id_cliente = " + id + " ORDER BY dataHora DESC;");
        while (reader.Read())
        {
            Pedido pedido = new Pedido();
            pedido.id_pedido = reader.GetInt32(0);
            pedido.dataHora = reader.GetString(1);
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
            Pedido pedido = new Pedido();
            pedido.id_pedido = reader.GetInt32(0);
            pedido.dataHora = reader.GetString(1);
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

    public static Pedido? GetPedido(string dataHora, string id_cliente)
    {
        
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM pedidos WHERE dataHora = '" + dataHora + "' AND id_cliente = " +
                                   id_cliente + ";");
        if (reader.Read())
        {
            var pedido = new Pedido(); 
            pedido.id_pedido = reader.GetInt32(0);
            pedido.dataHora = reader.GetString(1);
            pedido.total = reader.GetDecimal(2);
            pedido.pago = reader.GetBoolean(3);
            pedido.avaliação = reader.GetDecimal(4);
            pedido.aval_funcio = reader.GetDecimal(5);
            pedido.id_mesa = reader.GetInt32(6);
            pedido.id_cliente = reader.GetInt32(7);
            
            dbCon.Close();
            return pedido;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }
    
    public static Pedido? GetPedidoID(string id)
    {
        
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM pedidos WHERE id_pedido = " + id + ";");
        if (reader.Read())
        {
            var pedido = new Pedido(); 
            pedido.id_pedido = reader.GetInt32(0);
            pedido.dataHora = reader.GetString(1);
            pedido.total = reader.GetDecimal(2);
            pedido.pago = reader.GetBoolean(3);
            pedido.avaliação = reader.GetDecimal(4);
            pedido.aval_funcio = reader.GetDecimal(5);
            pedido.id_mesa = reader.GetInt32(6);
            pedido.id_cliente = reader.GetInt32(7);
            
            dbCon.Close();
            return pedido;
        }
        else
        {
            dbCon.Close();
            return null;
        }
    }
}





