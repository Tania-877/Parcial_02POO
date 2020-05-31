using System.Data;
using Npgsql;

namespace ClaseGUI05.Modelo
{
    public static class Conexion
    {
        

        private static string CadenaConexion = 
            "Server=ec2-52-72-65-76.compute-1.amazonaws.com;Port=5432;" +
            "User Id=tkndpvttlmtrta;Password=eeed4d73b75b2ea2d59fc78596ad34c5267a9512ef74318e9ed1e5918595f72e;" +
            "Database=d10q9ucvc9n785";
        
        public static DataTable realizarConsulta(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            DataSet ds = new DataSet();
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            
            return ds.Tables[0];
        }

        public static void realizarAccion(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            
            conn.Open();
            NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
            nc.ExecuteNonQuery();
            conn.Close();
        }
    }
}