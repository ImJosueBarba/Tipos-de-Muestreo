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

namespace Proyecto_Probabilidad_Estadistica
{
    public partial class Muestreo_Conglomerado : Form
    {
        public Muestreo_Conglomerado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TLista.insert(ingresoDatos());
                listarDatos();
                enviarDatos();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingresar correctamente");
            }
        }
        public void listarDatos()
        {
            dataGridView1.DataSource = TLista.listaNumeros.ToList();
        }
        public void cargarDatos()
        {
            TLista.listaNumeros.Add(new Conglomerado(1, 8, 96000));
            TLista.listaNumeros.Add(new Conglomerado(2, 12, 121000));
            TLista.listaNumeros.Add(new Conglomerado(3, 4, 42000));
            TLista.listaNumeros.Add(new Conglomerado(4, 5, 65000));
            TLista.listaNumeros.Add(new Conglomerado(5, 6, 52000));
            TLista.listaNumeros.Add(new Conglomerado(6, 6, 40000));
            TLista.listaNumeros.Add(new Conglomerado(7, 7, 75000));
            TLista.listaNumeros.Add(new Conglomerado(8, 5, 65000));
            TLista.listaNumeros.Add(new Conglomerado(9, 8, 45000));
            TLista.listaNumeros.Add(new Conglomerado(10, 3, 50000));
            TLista.listaNumeros.Add(new Conglomerado(11, 2, 85000));
            TLista.listaNumeros.Add(new Conglomerado(12, 6, 43000));
            TLista.listaNumeros.Add(new Conglomerado(13, 5, 54000));
            TLista.listaNumeros.Add(new Conglomerado(14, 10, 49000));
            TLista.listaNumeros.Add(new Conglomerado(15, 9, 53000));
            TLista.listaNumeros.Add(new Conglomerado(16, 3, 50000));
            TLista.listaNumeros.Add(new Conglomerado(17, 6, 32000));
            TLista.listaNumeros.Add(new Conglomerado(18, 5, 22000));
            TLista.listaNumeros.Add(new Conglomerado(19, 5, 45000));
            TLista.listaNumeros.Add(new Conglomerado(20, 4, 37000));
            TLista.listaNumeros.Add(new Conglomerado(21, 6, 51000));
            TLista.listaNumeros.Add(new Conglomerado(22, 8, 30000));
            TLista.listaNumeros.Add(new Conglomerado(23, 7, 39000));
            TLista.listaNumeros.Add(new Conglomerado(24, 3, 47000));
            TLista.listaNumeros.Add(new Conglomerado(25, 8, 41000));
        }


        public Conglomerado ingresoDatos()
        {
            int valorx = int.Parse(textBox1.Text);
            int valory = int.Parse(textBox2.Text);
            int valorz = int.Parse(textBox3.Text);

            Conglomerado con = new Conglomerado(valorx, valory, valorz);

            return con;
        }

        private void Muestreo_Conglomerado_Load(object sender, EventArgs e)
        {
            cargarDatos();
            listarDatos();
            enviarDatos();
        }

        int sumaColum2 = 0;
        int sumaColum3 = 0;
        int sumaColum4 = 0;
        double sumaColum5 = 0;
        double sumaColum6 = 0;
        int sumaTotal = 0;

        public void enviarDatos()
        {
             sumaColum2 = 0;
             sumaColum3 = 0;
             sumaColum4 = 0;
             sumaColum5 = 0;
             sumaColum6 = 0;
             sumaTotal = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow && row.Cells["Valor_x"].Value != null && row.Cells["Valor_y"].Value != null)
                {
                    int valorColumna2 = Convert.ToInt32(row.Cells["Valor_y"].Value);
                    int valorColumna3 = Convert.ToInt32(row.Cells["Valor_z"].Value);
                    int valorColumna4 = Convert.ToInt32(row.Cells["midos"].Value);
                    double valorColumna5 = Convert.ToDouble(row.Cells["yidos"].Value);
                    double valorColumna6 = Convert.ToDouble(row.Cells["yimi"].Value);

                    sumaTotal += 1;

                    row.Cells["midos"].Value = valorColumna2 * valorColumna2;
                    row.Cells["yidos"].Value = Math.Pow(valorColumna3, 2);
                    row.Cells["yimi"].Value = valorColumna2 * valorColumna3;

                    int sumColum2 = Convert.ToInt32(row.Cells["Valor_y"].Value);
                    int sumColum3 = Convert.ToInt32(row.Cells["Valor_z"].Value);
                    int sumColum4 = Convert.ToInt32(row.Cells["midos"].Value);
                    double sumColum5 = Convert.ToDouble(row.Cells["yidos"].Value);
                    double sumColum6 = Convert.ToInt32(row.Cells["yimi"].Value);

                    sumaColum2 += sumColum2;
                    sumaColum3 += sumColum3;
                    sumaColum4 += sumColum4;
                    sumaColum5 += sumColum5;
                    sumaColum6 += sumColum6;

                }
            }


            borrar();
            textBox7.Text = sumaColum2.ToString();
            textBox8.Text = sumaColum3.ToString();
            textBox9.Text = sumaColum4.ToString();
            textBox10.Text = sumaColum5.ToString();
            textBox11.Text = sumaColum6.ToString();
           
        }
        public void borrar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        public double estimacionMedia(int yi, int mi)
        {
            return (mi / yi);
        }
        public double varianza(double yN, double Sy2, double Sm2, double Syimi, int total)
        {
            double arriba = (Sy2 - (2 * yN * Syimi) + (Math.Pow(yN, 2) * Sm2));
            double abajo = (total - 1);
            double Sc = arriba / abajo;
            return Sc;
        }
        public double tamanioMedio(double mi, double N)
        {
            return (mi / N);
        }
        public double limiteError(double error, double MNe, double confianza)
        {
            double a = (Math.Pow(error / 100, 2) * Math.Pow(MNe, 2)) / Math.Pow((confianza / 100) + 1, 2);
            return a;
        }

        public double tamanioMuestra(double N, double vari, double error)
        {
            return ((N * vari) / ((N * error) + vari));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double N = int.Parse(textBox6.Text);
                double error = double.Parse(textBox7.Text);
                double confianza = double.Parse(textBox9.Text);


                double yN = estimacionMedia(sumaColum2, sumaColum3);

                double vari = varianza(yN, sumaColum5, sumaColum4, sumaColum6, sumaTotal);

                double MNe = tamanioMedio(sumaColum2, N);

                double erro = limiteError(error, MNe, confianza);

                double mues = tamanioMuestra(N, vari, erro);



                textBox12.Text = "";
                textBox12.AppendText("Estimación media: " + yN.ToString("N2"));
                textBox12.AppendText("\r\nVarianza: " + vari.ToString("N2"));
                textBox12.AppendText("\r\nTamaño medio de los conglomerados: " + MNe.ToString());
                textBox12.AppendText("\r\nLímite de error: " + erro.ToString());
                textBox12.AppendText("\r\nTamaño de la muestra: " + mues.ToString("N2"));
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingresar correctamente");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("Deseas eliminar", "Eliminar", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        Conglomerado op = dataGridView1.CurrentRow.DataBoundItem as Conglomerado;
                        int pos = TLista.buscar(op.Valor_x);
                        TLista.delete(pos);
                        MessageBox.Show("Eliminado");
                        listarDatos();
                        enviarDatos();
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila eliminar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {          
            
        }
    }
}
