using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataRepository
    {
        public static DataTable ExecuteDataTable(string stored_procedure, [Optional] params SqlParameter[] parameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(stored_procedure, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Count() > 0)
                {
                    foreach (var param in parameters)
                    {
                        sqlCommand.Parameters.Add(param);
                    }
                }
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                {
                    da.SelectCommand.CommandTimeout = 120;
                    DataTable dataTable = new DataTable();
                    da.Fill(dataTable);
                    //foreach (DataRow dataRow in dataTable.Rows)
                    //{
                    //    foreach (var data in dataRow.ItemArray)
                    //    {
                    //        Console.Write(data + " ");
                    //    }
                    //    Console.WriteLine();
                    //}
                    return dataTable;
                }

            }
        }

    }
}

