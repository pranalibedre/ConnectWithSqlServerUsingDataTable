using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
    class DataRepository
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























//public static void Add<T>([Optional] T[] parameters)
//{
//    string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;
//    string insert = "";
//    SqlConnection sqlConnection = new SqlConnection(connectionString);
//    sqlConnection.Open();
//    SqlCommand sqlCommand = new SqlCommand(insert, sqlConnection);
//    sqlCommand.CommandType = CommandType.Text;
//    try
//    {
//        sqlCommand.ExecuteNonQuery();
//        Console.WriteLine("Record Added Successfully!!");
//    }
//    catch (SqlException ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//    finally
//    {
//        sqlConnection.Close();
//    }















//SqlConnection sqlConnection = new SqlConnection(connectionString);
//sqlConnection.Open();
//SqlCommand sqlCommand = new SqlCommand()
//{
//};
//SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
//DataTable dataTable = new DataTable();
//adapter.SelectCommand = sqlCommand;
//adapter.SelectCommand.Connection = sqlConnection;
//adapter.Fill(dataTable);
//sqlConnection.Close();
//return dataTable;

//dataTable.Columns.Add("NewColumn");

//                    foreach (DataRow row in dataTable.Rows)
//                    {
//                        //need to set value to NewColumn column
//                    }