using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ConsoleApp2
{
    internal class Program2
    {

        public class products
        {
            public int productname { get; set; }
            public string unitsinstock { get; set; }


            public static List<products> GetCategories()
            {

                using (SqlConnection connection = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sagar;Password=aa"))
                {
                    string query = "Select * from Products";
                    List<products> products = connection.Query<products>(query).ToList();

                    return products;

                }

            }


            public static void Main2()
            {
                List<products> productlist = GetCategories();

                foreach (var product in productlist)
                {
                    Console.WriteLine(product.productname);

                }
            }
        }
    }
}
