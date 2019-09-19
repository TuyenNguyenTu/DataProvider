using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnectDataBase.Provider
{
    public class LopCungCapData
    {
        /// <summary>
        /// design patern SingleTon
        /// m?c dích trong 1 th?i di?m ch? có 1 cái instance dc t?o ra
        /// </summary>
        private static LopCungCapData instance;//dóng gói ctrl + R + E


        public static LopCungCapData Instance
        {
            get { if (instance == null) instance = new LopCungCapData(); return LopCungCapData.instance; }
            private set { LopCungCapData.instance = value; } //bên ngoài ko dc thay d?i d? li?u bên trong
        }

        private LopCungCapData() { }


        private string Strconnection = @"*ConnectionString*";
        public DataTable ExecuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(Strconnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listParamater = query.Split();
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }

                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] paramater = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(Strconnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listParamater = query.Split();
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }

                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] paramater = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(Strconnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (paramater != null)
                {
                    string[] listParamater = query.Split();
                    int i = 0;
                    foreach (string item in listParamater)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }

                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data = command.ExecuteScalar();


                connection.Close();
            }
            return data;
        }
    }
}