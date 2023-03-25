using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_with_database
{
    internal class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int AgentId { get; set; }
        internal static void DisplayArea()
        {
           
                Console.WriteLine();
                Console.WriteLine("Select the AreaId");
                Console.WriteLine();
                Console.Write("{0,-15}", "AreaId");
                Console.Write("{0,-15}", "AreaName");
                Console.WriteLine("{0,-15}", "AgentId");
                var list = Database.GetRecords<Area>("Vishal_Areas");
                foreach (var item in list)
                {
                    Console.Write("{0,-15}", item.AreaId);
                    Console.Write("{0,-15}", item.AreaName);
                    Console.WriteLine("{0,-15}", item.AgentId);
                }
            
        }
    }
}
