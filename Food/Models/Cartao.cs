namespace Food.Models;

public class Cartao
{
    public int id_cartao { get; set; }
    public float numero { get; set; }
    public string nome_cartao { get; set; }
    public string data_vencimento { get; set; }
    public int id_cliente { get; set; }
    public int cvc { get; set; }

    public Cartao()
    {
        
    }
    
    public static string AdicionarCartao(Cartao cartao)
    {
        var dbCon = new DataBaseConnection();
        var destaqueResult = 0;
        
        var result = dbCon.DbNonQuery(
            "INSERT INTO cartoes (id_cartao, numero, nome_cartao, data_vencimento, id_cliente, cvc) VALUES ('" +
            cartao.id_cartao + "', '" +
            cartao.numero + "', '" +
            cartao.nome_cartao + "', '" +
            cartao.data_vencimento + "', '" +
            cartao.id_cliente + "', '" +
            cartao.cvc + "');");
        
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
    
    public static List<Cartao> GetCartaoCliente(string id)
    {

        List<Cartao> cartoes = new List<Cartao>();
        var dbCon = new DataBaseConnection();
        var reader = dbCon.DbQuery("SELECT * FROM cartoes WHERE id_cliente = " + id + ";");
        while (reader.Read())
        {
            Cartao cartao = null;
            cartao.id_cartao = reader.GetInt32(0);
            cartao.numero = reader.GetFloat(1);
            cartao.nome_cartao = reader.GetString(2);
            cartao.data_vencimento = reader.GetString(3);
            cartao.id_cliente = reader.GetInt32(4);
            cartao.cvc = reader.GetInt32(5);
            
            cartoes.Add(cartao);
        }

        dbCon.Close();
        return cartoes;

    }
}