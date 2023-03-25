using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_with_database
{
    internal class Customer1
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }
        public string DateOfConnection { get; set; }
        public int PlanId { get; set; }
        public int AreaId { get; set; }
        internal static void DisplayCustomerDetails()
        {
            using (SqlConnection con1 = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                Console.WriteLine();
                Console.WriteLine("Customer Details");
                Console.WriteLine();
                var list = Database.GetRecords<Customer1>("Vishal_Customers");
                int maxId = 0;
                foreach (var record in list) 
                { 
                    if(record.CustomerId > maxId)
                    {
                        maxId = record.CustomerId;
                    }
                }
                foreach (var item in list)
                {
                    if(maxId == item.CustomerId)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("CustomerId = {0}", item.CustomerId);
                        Console.WriteLine("Firstname = {0}", item.FirstName);
                        Console.WriteLine("Lastname = {0}", item.LastName);
                        Console.WriteLine("Date Of Birth = {0}", item.DateOfBirth);
                        Console.WriteLine("Date Of Connection = {0} ", item.DateOfConnection);
                        Console.WriteLine("PlanId = {0}", item.PlanId);
                        Console.WriteLine("AreaId = {0}", item.AreaId);
                        Console.WriteLine("--------------------------------");
                    }
                    
                }
            }
        }
    }
}
