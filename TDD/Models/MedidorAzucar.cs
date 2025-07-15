using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Models
{
    public class MedidorAzucar
    {
        public int CucharadasDisponibles { get; private set; }

        public MedidorAzucar(int cantidadInicial)
        {
            CucharadasDisponibles = cantidadInicial;
        }

        public bool AgregarAzucar(int cucharadas)
        {
            if (CucharadasDisponibles >= cucharadas)
            {
                CucharadasDisponibles -= cucharadas;
                return true;
            }
            return false;
        }
    }
}
