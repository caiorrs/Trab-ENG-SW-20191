using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Form2 frm2;
        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
            frm2.Show(this);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            //Cria uma thread
            new Task(() => {
                //Sleep de 1s
                System.Threading.Thread.Sleep(1000);
                //Manda executar um metodo na thread em que a frm2 está rodando (principal)
                frm2.Invoke( (MethodInvoker)delegate {
                    frm2.Text = "Teste";
                });
            }).Start(); //Inicia a execução da thread criada la em cima
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Rodando o mesmo código na thread principal
            System.Threading.Thread.Sleep(1000);
            frm2.Text = "Outro teste";
        }
    }
}
