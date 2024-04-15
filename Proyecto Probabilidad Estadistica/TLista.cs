using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Probabilidad_Estadistica
{
    public class TLista
    {
        public static List<Conglomerado> listaNumeros = new List<Conglomerado>();

        public static void insert(Conglomerado em)
        {
            listaNumeros.Add(em);
        }

        public static void update(Conglomerado em, int pos)
        {
            listaNumeros[pos] = em;
        }

        public static void delete(int pos)
        {
            listaNumeros.Remove(listaNumeros.ElementAtOrDefault(pos));
        }

        public static int buscar(int num)
        {
            int pos = -1;
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                if (listaNumeros[i].Valor_x == num)
                {
                    pos = i; break;
                }
            }
            return pos;
        }
    }
}
