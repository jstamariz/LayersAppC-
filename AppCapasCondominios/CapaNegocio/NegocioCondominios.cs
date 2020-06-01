using System;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NegocioCondominios
    {
        DatosCondominio capaDatos = new DatosCondominio();
        public DataTable NegocioListado()
        {
            return capaDatos.DatosListado();
        }
        public void insert (EntidadCondominios entidad)
        {
            capaDatos.InsertData(entidad);
        }
        public SqlDataAdapter fillComboBox ()
        {
            return capaDatos.returnDataAdapter();
        }
        public void deleteFromDatabase (string idCard)
        {
            capaDatos.Deletedata(idCard);
        }
        public void UpdateFromDatabase(string idCard, EntidadCondominios entidad)
        {
            capaDatos.UpdateData(idCard,entidad);
        }
        public void DeleteDatabase (string idCard)
        {
            capaDatos.Deletedata(idCard);
        }
        public DataTable PersonasPorManzana()
        {
            return capaDatos.PersonasPorManzana();
        }
        public DataTable PersonasPorEdificio()
        {
            return capaDatos.PersonasPorEdifico();
        }
        public DataTable Buscar(string Search)
        {
            return capaDatos.Search(Search);
        }

    }
}
