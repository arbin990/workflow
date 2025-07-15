using System.Collections.Generic;

namespace TDD.Models
{
    public class MaquinaCafe
    {
        private Cafetera _cafetera;
        private MedidorAzucar _medidorAzucar;
        private Dictionary<string, Vaso> _vasosDisponibles;

        public MaquinaCafe(Cafetera cafetera, MedidorAzucar  medidorAzucar, Vaso vasoPequeno, Vaso vasoMediano, Vaso vasoGrande)
        {
            _cafetera = cafetera;
            _medidorAzucar =  medidorAzucar;
            _vasosDisponibles = new Dictionary<string, Vaso>
            {
                { vasoPequeno.Tamaño, vasoPequeno },
                { vasoMediano.Tamaño, vasoMediano },
                { vasoGrande.Tamaño, vasoGrande }
            };
        }

        public string GetVasoDeCafe(string tamañoVaso, int cantidadVasos, int cucharadasAzucar)
        {
#pragma warning disable CS8600
            if (!_vasosDisponibles.TryGetValue(tamañoVaso.ToLower(), out Vaso vasoSeleccionado))
            {
                return "Parece que ese tamanio no existe";
            }
#pragma warning restore CS8600

            int cafeNecesario = vasoSeleccionado.CantidadOz * cantidadVasos;

            if (vasoSeleccionado.CantidadDisponible < cantidadVasos)
            {
                return $"No tenemos suficientes vasos {tamañoVaso} solo hay {vasoSeleccionado.CantidadDisponible} por ahora";
            }

            if (_cafetera.CantidadCafeOz < cafeNecesario)
            {
                return $"El cafe no alcanza para {cantidadVasos} vasos {tamañoVaso} necesitas {cafeNecesario} oz y solo hay {_cafetera.CantidadCafeOz} oz disponibles";
            }

            if (_medidorAzucar.CucharadasDisponibles < cucharadasAzucar)
            {
                return $"Nos quedamos cortos de azucar necesitas {cucharadasAzucar} cucharadas y solo hay {_medidorAzucar.CucharadasDisponibles}";
            }

            for (int i = 0; i < cantidadVasos; i++)
            {
                vasoSeleccionado.usarVaso();
            }

            _cafetera.ServirCafe(cafeNecesario);
            _medidorAzucar.AgregarAzucar(cucharadasAzucar);

            return $"Listo se sirvieron {cantidadVasos} vasos {vasoSeleccionado.Tamaño} de {vasoSeleccionado.CantidadOz}oz con {cucharadasAzucar} cucharadas de azucar";
        }
    }
}
