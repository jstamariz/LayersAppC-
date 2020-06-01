using System;

namespace CapaEntidad
{
    public class EntidadCondominios
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public int Apto { get; set; }

        public EntidadCondominios(string nombre, string cedula, int apto)
        {
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Apto = apto;
        }
    }
}
