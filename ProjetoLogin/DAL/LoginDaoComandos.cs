using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProjetoLogin.DAL;

namespace ProjetoLogin.Modelo
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public string mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao(); // instanciar a pagina Conexao
        SqlDataReader dr;


        /* esse método verificarLogin
        *ele vai no banco de dados verificar se 
        * tem um email ou senha caso tenha a senha e nao tem o email o valor vai ser 
        * falso se tiver os dois certo vai voltar com o valor verdadeiro.
        */

        public bool verificarLogin(String login, string senha) //1° recebe a informação do controle que venho do formulario (login e senha)

        {
            //aqui vamos escrever o comando no banco de dados aqui
            cmd.CommandText = "select *from logins where email =@login and senha = @senha";//2° verifica se o user e a senha tem no banco de dados 
            //o login passarar os dados para o "@login" dai ele colocarar esse informação na linha acima
            cmd.Parameters.AddWithValue("@login", login);
            //a senha passarar os dados para o "@senha" dai ele colocarar essa informação na linha acima
            cmd.Parameters.AddWithValue("@senha", senha);
            try // o try vai execultar essa informação
            {
                cmd.Connection = con.conectar();// aqui  é a linha que escrevemos 
                dr = cmd.ExecuteReader();// aqui ele guarda as informações 
                if (dr.HasRows)//se foi encontrado informações
                {
                    tem = true;
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com banco de Dados!";

            }
            //aqui iremos colocar os comandos SQL para verificar se tem no Banco de Dados
            return tem;
        }

        /*
         * Esse método vai cadastrar ele vai pegar o email e a senha
         * do controle e vai enviar para essa classe e esse método vai realmente cadastrar 
         * no Banco
         */
        public string cadastrar(string email, string senha, string confSenha)
        {
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into dbo.logins VALUES ('@email','@senha');";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso";
                    tem = true;
                }
                catch (SqlException)
                {

                    this.mensagem = "Erro com banco de dados";
                }
            }

            else
            {
                this.mensagem = "Senhas não correspondem";
            }
            return mensagem;
        }
    }
}

