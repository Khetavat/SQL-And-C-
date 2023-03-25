using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Database
    {
        public static List<T> GetRecords<T>(string tablename)
        {
            using (SqlConnection con1 = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {

                var category1 = con1.Query<T>($"SELECT * FROM {tablename}").ToList();
                return category1;
            }
        }
    }
}
