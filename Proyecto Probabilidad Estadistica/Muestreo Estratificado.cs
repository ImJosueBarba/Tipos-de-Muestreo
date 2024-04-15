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
    public partial class Muestreo_Estratificado : Form
    {
        public Muestreo_Estratificado()
        {
            InitializeComponent();
            label5.Visible = true;
            textBox3.Visible = true;
            dataGridView1.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            textBox4.Visible = false;
            textBox4.Enabled = false;
            textBox2.Enabled = false;
        }
        double suma = 0;

        public void LimpiarAlCambiar()
        {
            dataGridView1.Rows.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.Equals("Muestreo Proporcional"))
            {
                suma = 0; 
                LimpiarAlCambiar();
                label4.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                dataGridView1.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                label1.Visible = true;
                label1.Text = "Suma Muestreo Proporcional";
                textBox4.Visible = true;
                dataGridView1.Columns[0].HeaderText = "Salon";
                dataGridView1.Columns[1].HeaderText = "Numero de Alumnos";
                dataGridView1.Columns[2].HeaderText = "Muestra Proporcional";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;


            }
            else if (comboBox2.SelectedItem.Equals("Muestreo Uniforme"))
            {
                suma = 0;
                LimpiarAlCambiar();
                label4.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                dataGridView1.Visible = true;
                label1.Visible = true;
                textBox4.Visible = true;
                label1.Text = "Suma Muestreo Uniforme";
                dataGridView1.Columns[0].HeaderText = "Salon";
                dataGridView1.Columns[1].HeaderText = "Numero de Alumnos";
                dataGridView1.Columns[2].HeaderText = "Muestra UNIFORME";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;

            }
            else if (comboBox2.SelectedItem.Equals("Muestreo Optimo"))
            {
                suma = 0; 
                LimpiarAlCambiar();
                label4.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                dataGridView1.Visible = true;
                label1.Visible = true;
                textBox4.Visible = true;
                label1.Text = "Suma Muestreo Optimo";
                dataGridView1.Columns[0].HeaderText = "Salon";
                dataGridView1.Columns[1].HeaderText = "Numero de Alumnos";
                dataGridView1.Columns[2].HeaderText = "VARIANZA";
                dataGridView1.Columns[3].HeaderText = "DESVIACION ESTANDAR";
                dataGridView1.Columns[4].HeaderText = "MUESTRA OPTIMA";
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;

            }
        }
        public void CalcularMuestra()
        {
            if (!double.TryParse(textBox3.Text, out double textBox3Value))
            {
                MessageBox.Show("Por favor, ingresa un número válido en el Tamaño de la Muestra.");
                return;
            }

            double textBox2Value = Double.Parse(textBox2.Text);

            if (comboBox2.SelectedItem.Equals("Muestreo Proporcional"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double numeroDeAlumnos = Double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    double result = (textBox3Value / textBox2Value) * numeroDeAlumnos;
                    dataGridView1.Rows[i].Cells[2].Value = result.ToString();
                }

                double calculos = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double valor = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    calculos += valor;
                }

                textBox4.Text = calculos.ToString();

            }
            else if (comboBox2.SelectedItem.Equals("Muestreo Uniforme"))
            {

                double calculos = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double result = textBox3Value / dataGridView1.Rows.Count;
                    dataGridView1.Rows[i].Cells[2].Value = result.ToString();
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double valor = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    calculos += valor;
                }

                textBox4.Text = calculos.ToString();

            }
            else if (comboBox2.SelectedItem.Equals("Muestreo Optimo"))
            {
                double total = 0;
                double calculos = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double numeroDeAlumnos = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    double desviacionEstandar = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    double des = numeroDeAlumnos * desviacionEstandar;
                    total += des;
                }


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double numeroDeAlumnos = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    double desviacionEstandar = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    double Df = numeroDeAlumnos * desviacionEstandar * textBox3Value;
                    double result = Df / total;

                    dataGridView1.Rows[i].Cells[4].Value = result.ToString();
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double valor = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    calculos += valor;
                }

                textBox4.Text = calculos.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                if (double.Parse(textBox2.Text) > double.Parse(textBox3.Text))
                {
                    CalcularMuestra();
                }
                else
                {
                    MessageBox.Show("La Muestra no puede superar a la Población");
                }
            }
            else
            {
                MessageBox.Show("Campos Obligatorios Vacios");
            }
        }

        public void Calcular()
        {
            if (double.TryParse(textBox1.Text, out double valor))
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cellSalon = new DataGridViewTextBoxCell();
                char letter = (char)('A' + dataGridView1.Rows.Count + 0);
                cellSalon.Value = letter.ToString();
                row.Cells.Add(cellSalon);

                DataGridViewTextBoxCell cellNumeroAlumnos = new DataGridViewTextBoxCell();
                cellNumeroAlumnos.Value = textBox1.Text;
                row.Cells.Add(cellNumeroAlumnos);

                if (comboBox2.SelectedItem.Equals("Muestreo Optimo"))
                {
                    DataGridViewTextBoxCell cellVarianza = new DataGridViewTextBoxCell();
                    Random random = new Random();
                    int numeroAleatorio = random.Next(1, 101);
                    cellVarianza.Value = numeroAleatorio.ToString();
                    row.Cells.Add(cellVarianza);

                    DataGridViewTextBoxCell cellDesviacionEstandar = new DataGridViewTextBoxCell();
                    double raizCuadrada = Math.Sqrt(numeroAleatorio);
                    cellDesviacionEstandar.Value = raizCuadrada.ToString();
                    row.Cells.Add(cellDesviacionEstandar);
                }

                suma += valor;
                textBox2.Text = suma.ToString();

                textBox1.Clear();

                dataGridView1.Rows.Add(row);
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un número válido en ESTUDIANTES.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                Calcular();
            }
        }

        private void Muestreo_Estratificado_Load(object sender, EventArgs e)
        {

        }
    }
}
