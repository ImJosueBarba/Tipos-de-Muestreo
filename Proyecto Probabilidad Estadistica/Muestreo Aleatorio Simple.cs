using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Probabilidad_Estadistica
{

    public partial class Muestreo_Aleatorio_Simple : Form
    {
        Boolean val = false;
        public Muestreo_Aleatorio_Simple()
        {
            InitializeComponent();
        }

        public void validar()
        {
            if(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex==-1 || String.IsNullOrEmpty(textBox1.Text))
            {
                val = false;
            }
            else
            {
                val = true;
            }
        }
        public void numbersOnly(KeyPressEventArgs e)
        {
            if (Char.IsPunctuation(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (Char.IsSymbol(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            validar();
            if (val)
            {
            double p = 0;
            double aux = 0;
            double z = 0;
                try
                {
                    double err = double.Parse(textBox1.Text);
                    if (radioButton1.Checked)
                    {
                        p = double.Parse(textBox4.Text);
                        p = p / 100;
                    }
                    else
                    {
                        p = 0.5;
                    }
                    double q = (p - 1.00) * -1;

                    if (comboBox2.SelectedIndex == 0)
                    {
                        z = 3.00;
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        z = 2.58;
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        z = 2.33;
                    }
                    if (comboBox2.SelectedIndex == 3)
                    {
                        z = 2.05;
                    }
                    if (comboBox2.SelectedIndex == 4)
                    {
                        z = 2.00;
                    }
                    if (comboBox2.SelectedIndex == 5)
                    {
                        z = 1.96;

                    }
                    if (comboBox2.SelectedIndex == 6)
                    {
                        z = 1.645;
                    }
                    if (comboBox2.SelectedIndex == 7)
                    {
                        z = 1.28;
                    }
                    if (comboBox2.SelectedIndex == 8)
                    {
                        z = 1.00;
                    }
                    if (comboBox2.SelectedIndex == 9)
                    {
                        z = 0.6745;
                    }
                    err = err / 100;
                    
                    aux = (Math.Pow(z, 2) * p * q) / (Math.Pow(err, 2));
                    int n = (int)aux;
                    textBox2.Text = n.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Debe ingresar numeros!" + ex);
                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
        }

        private void Muestreo_Aleatorio_Simple_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.ReadOnly = true;
            label5.Visible = false;
            textBox3.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
               label5.Visible = true;
               textBox3.Visible = true;
            }
            else
            {
                label5.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label6.Visible = true;
                textBox4.Enabled = true;
                textBox4.Text = "";
            }
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            numbersOnly(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            numbersOnly(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            numbersOnly(e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label6.Visible = false;
                textBox4.Enabled = false;
                textBox4.Text = "0.5";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
