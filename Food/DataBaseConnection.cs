using MySql.Data.MySqlClient;

namespace Food;

public class DataBaseConnection
{
    private MySqlConnection con;

    public DataBaseConnection()
    {
        string cs =
            @"server=food-4-u.cam7xmtivgt0.eu-west-2.rds.amazonaws.com;userid=admin;password=adminfood4u;database=food4u";
        con = new MySqlConnection(cs);
        con.Open();
    }
    
    public MySqlDataReader DbQuery(String query)
    {
        var cmd = new MySqlCommand(query, con);
        return cmd.ExecuteReader();
    }
    
    public int DbNonQuery(String query)
    {
        var cmd = new MySqlCommand(query, con);
        return cmd.ExecuteNonQuery();
    }
    
    public void Close()
    {
        con.Close();
    }
}