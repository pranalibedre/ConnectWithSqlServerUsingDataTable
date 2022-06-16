using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerUsingDataTable
{
    public class State
    {
        public string StateName { get; set; }
        public int StateId { get; set; }
        public List<State> GetState()
        {
            DataTable dataTable = DataRepository.ExecuteDataTable("spGetStates");
            var listStates = new List<State>();
            Console.WriteLine("State Details");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                State state = new State();
                state.StateId = Convert.ToInt16(dataTable.Rows[i]["StateId"]);
                state.StateName = Convert.ToString(dataTable.Rows[i]["State"]);
                listStates.Add(state);
            }
            foreach (var list in listStates)
            {
                Console.WriteLine("\t{0}\t{1}", list.StateId, list.StateName);
            }
            return listStates;
        }
    }
}
