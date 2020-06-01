using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
    public class DatosCondominio
    {
        SqlConnection Connect =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionSql"].ConnectionString);

        public DataTable DatosListado ()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM v_Personas", Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void InsertData (EntidadCondominios Person)
        {
            SqlCommand insert = new SqlCommand($"INSERT INTO Persona(Nombre,Cedula,Apto_id) VALUES ('{Person.Nombre}','{Person.Cedula}','{Person.Apto}')", Connect);
            Connect.Open();
            insert.ExecuteNonQuery();
            Connect.Close();
        }
        public SqlDataAdapter returnDataAdapter()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM apartamento", Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }
        public void Deletedata (string IdCard)
        {
            SqlCommand delete = new SqlCommand($"DELETE FROM Persona WHERE Cedula = '{IdCard}';", Connect);
            Connect.Open();
            delete.ExecuteNonQuery();
            Connect.Close();
        }
        public void UpdateData (string IdCard, EntidadCondominios Person)
        {
            SqlCommand update = new SqlCommand($"UPDATE Persona SET Nombre = '{Person.Nombre}', Cedula = '{Person.Cedula}',Apto_id = '{Person.Apto}' WHERE Cedula = '{IdCard}'", Connect);
            Connect.Open();
            update.ExecuteNonQuery();
            Connect.Close();
        }
        public DataTable PersonasPorManzana()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM vPersonasPorManzana", Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PersonasPorEdifico()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM vPersonasPorEdifico", Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Search (string Search)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM v_Personas WHERE Nombre = '{Search}'", Connect);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
