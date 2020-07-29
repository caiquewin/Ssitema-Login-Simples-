using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetoLogin.DAL
{
    //vamos criar 3 métodos para esse classe
    public class Conexao
    {
        SqlConnection con = new SqlConnection();// isso é uma classe para conectar ao banco de dados (vamos fazer uma instancia)
        
        public Conexao()
        {
            con.ConnectionString = @"Data Source=DESKTOP-PRPUO5C\;Initial Catalog=ProjetoLogin;Integrated Security=True";
        }

         // método para conectar e desconectar ao banco de dados

        public SqlConnection conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed) // se essa conexão estiver fechada
            {
                con.Open();// ele vai abir a conexão 

            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {//
                con.Close();
            }
            
        }

    }
}
