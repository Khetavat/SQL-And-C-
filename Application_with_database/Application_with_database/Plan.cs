using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application_with_database
{
    internal class Plan
    {
        public int PlanId { get; set; }
        public decimal PlanCost { get; set; }
        internal static void DisplayPlan()
        {
                Console.WriteLine();
                Console.WriteLine("Select the Planid");
                Console.WriteLine();
                Console.Write("{0,-15}", "PlanId");
                Console.WriteLine("{0,-15}", "PlanCost");
                var list = Database.GetRecords<Plan>("Vishal_Plans");
                foreach (var item in list)
                {
                    Console.Write("{0,-15}", item.PlanId);
                    Console.WriteLine("{0,-15}", item.PlanCost);
                }
            
        }
    }
}
