using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlydiemsinhvien.DAL
{
    public class DAL_dataprovider
    {
        private string connectString = @"Data Source=DESKTOP-RIOHAA9\SQLEXPRESS;Initial Catalog=quanlydiemsinhvien;Integrated Security=True";
        private static DAL_dataprovider Instance;

        public static DAL_dataprovider GetInstance
        {
            get { if (Instance == null) Instance = new DAL_dataprovider(); return DAL_dataprovider.Instance; }
            private set => Instance = value;
        }
        private DAL_dataprovider()
        {

        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {

            DataTable data = new DataTable();
            SqlConnection conn = new SqlConnection(connectString);

            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(data);
            conn.Close();

            return data;

        }
        public int ExecuteNonQuery(string query, object[] parameter = null) //successful return != 0
        {

            int data = 0;
            try
            {
                SqlConnection conn = new SqlConnection(connectString);

                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) { command.Parameters.AddWithValue(item, parameter[i]); i++; }
                    }
                }
                data = command.ExecuteNonQuery();
                conn.Close();

                return data;
            }
            catch 
            {
                return 0;
            }

        }

        public string ExecuteNonQuery2(string query, object[] parameter = null) //successful return != 0
        {


            try
            {
                SqlConnection conn = new SqlConnection(connectString);

                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@")) { command.Parameters.AddWithValue(item, parameter[i]); i++; }
                    }
                }
                command.ExecuteNonQuery();
                conn.Close();

                return "successful";
            }
            catch (SqlException ex)
            {
                {
                    return ex.Message;
                }

            }
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            SqlConnection connection = new SqlConnection(connectString);

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            data = command.ExecuteScalar();

            connection.Close();


            return data;
        }
    }
}
