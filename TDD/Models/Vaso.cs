namespace TDD.Models
{
    public class Vaso
    {
        public string Tamaño { get;  set; }
        public int CantidadOz { get;  set; }
        public int CantidadDisponible { get; set;}

        public Vaso(string tamaño, int cantidadDisponible = 10)
        {
            Tamaño = tamaño.ToLower();
            CantidadDisponible = cantidadDisponible;
            switch (Tamaño)
            {
                case "pequenio": CantidadOz = 3; break;
                case "mediano": CantidadOz = 5; break;
                case "grande": CantidadOz = 7; break;
                default: throw new ArgumentException("Tamanio de vaso no valido.");
            }

        }

        public bool usarVaso()
        {
            if (CantidadDisponible > 0)
            {
                CantidadDisponible--;
                return true;
            }
            return false;
        }
    }
}
