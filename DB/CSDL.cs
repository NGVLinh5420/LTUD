using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGVL.DB
{
    internal class CSDL
    {
        private static CSDL _instance;
        private SqlConnection connection = new SqlConnection("Data Source=HP-PAVILION-15;Initial Catalog=QLCuaHang;Integrated Security=True");

        public CSDL()
        {

        }

        internal static CSDL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CSDL();
                }

                return _instance;
            }
        }

        public void ThucThi(string querty, object[] parameters = null)
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand(querty, connection))
            {
                if (parameters != null)
                {
                    string[] arrString = querty.Split(' ');
                    int count = 0;

                    foreach (var str in arrString)
                    {
                        if (str.StartsWith("@"))
                        {
                            cmd.Parameters.AddWithValue(str, parameters[count]);
                            count++;
                        }
                    }            
                }

                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public DataTable TruyVan(string querty, object[] parameters = null)
        {
            connection.Open();
            DataTable dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand(querty, connection))
            {
                if (parameters != null)
                {
                    string[] arrString = querty.Split(' ');
                    int count = 0;

                    foreach (var str in arrString)
                    {
                        if (str.StartsWith("@"))
                        {
                            cmd.Parameters.AddWithValue(str, parameters[count]);
                            count++;
                        }
                    }                    
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
            }

            connection.Close();
            return dataTable;
        }
    }
}
