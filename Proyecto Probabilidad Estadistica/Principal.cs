using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Probabilidad_Estadistica
{
    public partial class Principal : Form
    {
       
        int PosY = 0;
        int PosX = 0;
        public Principal()
        {
            InitializeComponent();
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconorestaurar.Visible = true;
            iconoMaximizar.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconorestaurar.Visible = false;
            iconoMaximizar.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 229)
            {
                panelMenu.Width = 60;
            }
            else
            {
                panelMenu.Width = 229;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                PosX = e.X;
                PosY = e.Y;
            }
            else
            {
                Left = Left + (e.X - PosX);
                Top = Top + (e.Y - PosY);
            }
            
        }
        public void AbrirMuestreoSimple(Object muestreoSimple)
        {
            if(this.panelContenedor.Controls.Count > 0)
            
                this.panelContenedor.Controls.RemoveAt(0);
                Form mas = muestreoSimple as Form;
                mas.TopLevel = false;
                mas.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(mas);
                this.panelContenedor.Tag = mas;
                mas.Show();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirMuestreoSimple(new Muestreo_Aleatorio_Simple());
        }

        public void AbrirMuestreoSistematico(Object muestreoSistematico)
        {
            if (this.panelContenedor.Controls.Count > 0)

                this.panelContenedor.Controls.RemoveAt(0);
            Form mas = muestreoSistematico as Form;
            mas.TopLevel = false;
            mas.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(mas);
            this.panelContenedor.Tag = mas;
            mas.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirMuestreoSimple(new Muestreo_Aleatorio_Sistematico());
        }

        public void AbrirMuestreoEstratificado(Object MuestreoEstratificado)
        {
            if (this.panelContenedor.Controls.Count > 0)

                this.panelContenedor.Controls.RemoveAt(0);
            Form mas = MuestreoEstratificado as Form;
            mas.TopLevel = false;
            mas.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(mas);
            this.panelContenedor.Tag = mas;
            mas.Show();

        }
        public void AbrirMuestreoConglomerado(Object muestreoSimple)
        {
            if (this.panelContenedor.Controls.Count > 0)

                this.panelContenedor.Controls.RemoveAt(0);
            Form mas = muestreoSimple as Form;
            mas.TopLevel = false;
            mas.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(mas);
            this.panelContenedor.Tag = mas;
            mas.Show();

        }
        public void AbrirIntegrantes(Object muestreoSimple)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form mas = muestreoSimple as Form;
            mas.TopLevel = false;
            mas.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(mas);
            this.panelContenedor.Tag = mas;
            mas.Show();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            AbrirMuestreoEstratificado(new Muestreo_Estratificado());
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            AbrirMuestreoConglomerado(new Muestreo_Conglomerado());
        }


        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
      
        }
     

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AbrirIntegrantes(new Integrans());
        }
    }
}
