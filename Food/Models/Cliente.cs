using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Food;

namespace Food.Models
{
    public class Cliente
    {
        [Key] public int id_cliente { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? nif { get; set; }
        public string? genero {get; set; }
        public int? idade { get; set; }
        public string? localidade { get; set; }
        public string? concelho { get; set; }
        public Boolean? isAdmin { get; set; }

        public Cliente()
        {

        }


        public static List<Cliente> GetAllItems()
        {
            List<Cliente> clientes = new List<Cliente>();

            var dbCon = new DataBaseConnection();
            var reader = dbCon.DbQuery("SELECT * FROM clientes");

            while (reader.Read())
            {
                var cliente = new Cliente();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.password = reader.GetString(3);
                cliente.nif = reader.GetString(4);
                cliente.genero = reader.GetString(5);
                cliente.idade = reader.GetInt32(6);
                cliente.localidade = reader.GetString(7);
                cliente.concelho = reader.GetString(8);
                cliente.isAdmin = reader.GetBoolean(9);

                clientes.Add(cliente);
            }

            dbCon.Close();
            return clientes;
        }

        public static Cliente? GetItem(string id)
        {
            var dbCon = new DataBaseConnection();
            var reader = dbCon.DbQuery("SELECT * FROM clientes WHERE id_cliente = " + id + ";");
            if (reader.Read())
            {
                var cliente = new Cliente();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.password = reader.GetString(3);
                cliente.nif = reader.GetString(4);
                cliente.genero = reader.GetString(5);
                cliente.idade = reader.GetInt32(6);
                cliente.localidade = reader.GetString(7);
                cliente.concelho = reader.GetString(8);
                cliente.isAdmin = reader.GetBoolean(9);

                dbCon.Close();
                return cliente;
            }
            else
            {
                dbCon.Close();
                return null;
            }
        }

        public static Cliente? GetEmail(string email)
        {
            var dbCon = new DataBaseConnection();
            var reader = dbCon.DbQuery("SELECT * FROM clientes WHERE email = '" + email + "';");
            if (reader.Read())
            {
                var cliente = new Cliente();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.password = reader.GetString(3);
                cliente.nif = reader.GetString(4);
                cliente.genero = reader.GetString(5);
                cliente.idade = reader.GetInt32(6);
                cliente.localidade = reader.GetString(7);
                cliente.concelho = reader.GetString(8);
                cliente.isAdmin = reader.GetBoolean(9);

                dbCon.Close();
                return cliente;
            }
            else
            {
                dbCon.Close();
                return null;
            }
        }
        
        public static Cliente? ClienteLogin(string email, string password)
        {
            var dbCon = new DataBaseConnection();
            var reader = dbCon.DbQuery("SELECT * FROM clientes WHERE email = '" + email + "' AND password = '" + password + "';");
            if (reader.Read())
            {
                var cliente = new Cliente();
                cliente.id_cliente = reader.GetInt32(0);
                cliente.nome = reader.GetString(1);
                cliente.email = reader.GetString(2);
                cliente.password = reader.GetString(3);
                cliente.nif = reader.GetString(4);
                cliente.genero = reader.GetString(5);
                cliente.idade = reader.GetInt32(6);
                cliente.localidade = reader.GetString(7);
                cliente.concelho = reader.GetString(8);
                cliente.isAdmin = reader.GetBoolean(9);

                dbCon.Close();
                return cliente;
            }
            else
            {
                dbCon.Close();
                return null;
            }
        }

        public static string Registar(Cliente cliente)
        {
            var dbCon = new DataBaseConnection();
            var result = dbCon.DbNonQuery(
                "INSERT INTO clientes (id_cliente, nome, email, password, nif, genero, idade, localidade, concelho, isAdmin) VALUES ('" +
                cliente.id_cliente + "', '" +
                cliente.nome + "', '" +
                cliente.email + "', '" +
                cliente.password + "', '" +
                cliente.nif + "', '" +
                cliente.genero + "', '" +
                cliente.idade + "', '" +
                cliente.localidade + "', '" +
                cliente.concelho + "', '" +
                cliente.isAdmin +
                "');");
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

        public static string Update(string id, Cliente cliente)
        {
            var dbCon = new DataBaseConnection();
            
            String strQuery = 
                "UPDATE clientes SET " + 
                "nome = '" + cliente.nome + "', " +
                "email = '" + cliente.email + "', " +
                "password = '" + cliente.password + "', " +
                "nif = '" + cliente.nif + "', " +
                "genero = '" + cliente.genero + "', " +
                "idade = '" + cliente.idade + "', " +
                "localidade = '" + cliente.localidade + "', " +
                "concelho = '" + cliente.concelho + "', " +
                "isAdmin = '" + cliente.isAdmin + "' " +
                "WHERE id_cliente = " + id + ";";
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

            String strQuery = "DELETE FROM clientes where id_cliente = " + id + ";";

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
}