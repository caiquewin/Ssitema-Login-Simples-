using ProjetoLogin.Apresentacao;
using ProjetoLogin.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjetoLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrese_Click(object sender, EventArgs e)
        {
            CadastreSe cad = new CadastreSe();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("login com sucesso", "Bem vindo");
                    BemVindo bemvindo = new BemVindo();
                    bemvindo.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Login ou senha errado", "Erro 404");
                }
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
