using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Proyecto_Probabilidad_Estadistica
{
    public partial class Muestreo_Aleatorio_Sistematico : Form
    {
        public Muestreo_Aleatorio_Sistematico()
        {
            InitializeComponent();
        }

        private void Muestreo_Aleatorio_Sistematico_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }
      
        Boolean val = false;

        public void validar()
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                val = false;
            }
            else
            {
                val = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validar();
            if (val)
            {
                int k = 0;
                
                try
                {
                    int pob = int.Parse(textBox1.Text);
                    int mue = int.Parse(textBox2.Text);

                    k = pob/mue;
                    textBox3.Text = k.ToString();

                    Random aleatorio = new Random();
                    int numA = 0;

                    numA = aleatorio.Next(1, k + 1);
                    textBox4.Text = numA.ToString();

                    textBox5.Text = numA.ToString();
                    for( int f = 1; f < mue; f++ ) 
                    {
                        int sigN = numA + (f * k);
                        textBox5.Text += ", " + sigN.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe ingresar numeros!"+ex);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
        }
    }
}
