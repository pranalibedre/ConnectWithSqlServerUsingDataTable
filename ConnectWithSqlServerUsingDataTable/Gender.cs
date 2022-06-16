using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
    public class Gender
    {
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public Person Person { get; set; }

        public List<Gender> GetGenders()
        {
            DataTable dataTable = DataRepository.ExecuteDataTable("spGetGenders");
            var listGenders = new List<Gender>();
            DataRow row = dataTable.NewRow();
            row["GenderID"] = 4;
            row["Gender"] = "Transgender";
            dataTable.Rows.Add(row);

            Console.WriteLine("Gender Details");
            Console.WriteLine("Number of rows in table are: " + dataTable.Rows.Count);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Gender gender = new Gender();
                gender.GenderId = Convert.ToInt16(dataTable.Rows[i]["GenderId"]);
                gender.GenderName = Convert.ToString(dataTable.Rows[i]["Gender"]);
                listGenders.Add(gender);
            }
            foreach (var list in listGenders)
            {
                Console.WriteLine("\t{0}\t{1}", list.GenderId, list.GenderName);
            }
            return listGenders;
        }

    }
}
