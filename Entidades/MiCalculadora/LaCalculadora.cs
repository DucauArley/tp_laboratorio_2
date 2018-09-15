using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

            lblResultado.Text = "" + resultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            string strNumero;

            strNumero = Numero.DecimalBinario(numero);

            lblResultado.Text = strNumero;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string binario = lblResultado.Text;
            double numero;

            if (ValidarBinario(binario))
            {
                numero = double.Parse(Numero.BinarioDecimal(binario));

                lblResultado.Text = "" + numero;
            }
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }
        
        private static bool ValidarBinario(string binario)
        {
            bool ok = true;
            int numero = -1;

            for (int i = 0; i < binario.Length; i++)
            {
                numero = int.Parse(binario[i].ToString());

                if (numero != 0 && numero != 1)
                {
                    ok = false;
                    break;
                }
            }

            return ok;
        }
    }
}
