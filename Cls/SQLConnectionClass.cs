using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ajanda.Cls
{
    public class SQLConnectionClass
    {
        private static string SQLConnectionString = "Data Source=DESKTOP-9AG1BFS;Integrated Security=True;Trust Server Certificate=True";
        private static SqlConnection con = new SqlConnection();
        private static SqlDataAdapter da = new SqlDataAdapter();
        private static SqlCommand com = new SqlCommand();
        public static SqlException exception = null;
        public static void Baglanti()
        {
            con = new SqlConnection(SQLConnectionString);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static object Command(string query)
        {
            exception = null; 

            
            object obj = null;
            com.Connection = con; 
            com.CommandText = query; 

            try
            {
                obj = com.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                exception = ex;
                MessageBox.Show(ex.GetType().Name + " - " + ex.Message); 
               
            }


            return obj;
        }

        public static DataTable Table(string query)
        {
            exception = null; 

            DataTable dt = new DataTable();
            com.Connection = con; 
            com.CommandText = query; 
            da.SelectCommand = com; 

            try
            {
                da.Fill(dt);
            }
            catch (SqlException ex)
            {

                exception = ex;
                MessageBox.Show(ex.GetType().Name + " - " + ex.Message);
            }


            return dt;
        }
    }
}