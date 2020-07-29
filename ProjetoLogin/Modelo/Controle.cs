using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLogin.Modelo
{
   public class Controle
    {
        public bool tem;// atributo boleano para retorna se tem
        public string mensagem = "";// aqui é onde vai da a mesagem se entro ou não
        
        public  bool acessar(string login, string senha)// DOI PARAMETROS login e senha
        {
            LoginDaoComandos loginDao = new LoginDaoComandos(); // iremos instanciar
            tem = loginDao.verificarLogin(login, senha); //aqui acessamos o método/enviando a string login e senha
            if (!loginDao.mensagem.Equals(""))// se essa mensagem conter alguma informação é por que houve um erro!
            {
                this.mensagem = loginDao.mensagem;
            }

            return tem;
        }
        // método para cadastrar

        
        public string cadastrar(String email, string senha, string confSenha)
        {

            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem=loginDao.cadastrar(email, senha,confSenha);
            if (loginDao.tem )
            {
                this.tem = true;
            }
            return mensagem; // aqui ele retorna com a mesagem
        }

        

    }
}
