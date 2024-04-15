using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Probabilidad_Estadistica
{
    public class Conglomerado
    {
        private int valorx;
        private int valory;
        private int valorz;

        public Conglomerado(int valorx, int valory, int valorz)
        {
            this.Valor_x = valorx;
            this.Valor_y = valory;
            this.valorz = valorz;
        }

        public int Valor_x { get => valorx; set => valorx = value; }
        public int Valor_y { get => valory; set => valory = value; }
        public int Valor_z { get => valorz; set => valorz = value; }
    }
}
