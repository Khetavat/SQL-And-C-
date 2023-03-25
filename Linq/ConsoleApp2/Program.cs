using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    class Product
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set;}
        public int UnitsInStock { get; set; }
    }

    class NewClass
    {
        public string NewClassName { get; set; }
        public int NewClassUnitsInStock { get; set; }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categorylist = Database.GetRecords<Category>("categories");
            List<Product> productlist1 = Database.GetRecords<Product>("Products");
            //Program.Display(list);

          
            var list2 = Program.Get(productlist1);
            Console.WriteLine("Product to NewClass");
            Console.WriteLine();
            Program.DisplayList(list2);

            List<ProductCategory> list3 = Program.GetProductCategory(productlist1, categorylist);
            Console.WriteLine();
            Console.WriteLine("Product Category");
            Console.WriteLine();
            Program.DisplayList(list3);

            Console.WriteLine();
            Console.WriteLine("Product To Anonymous");
            Console.WriteLine();
            Program.GetWithAnonymous(productlist1);
            Console.ReadLine();
        }

        private static List<string> GetStringOfLenthFive(List<Category> list)
        {

            List<String> list1 = (from c in (list) where c.CategoryName.Length == 5 || c.CategoryName.Contains("s") select c.CategoryName).ToList();
            return list1;
        }
        /*
        private static List<string> GetStartingWithC(List<Category> list)
        {
            

            var list1 = (from c in (list) where c.CategoryName.StartsWith("C") || c.CategoryName.StartsWith("c")  select c.CategoryName).ToString();
            return list1;
        }
        */


        public static List<NewClass> Get(List<Product> product)
        {

            var list1 = (from p in (product) select new NewClass() { NewClassName = p.ProductName,NewClassUnitsInStock = p.UnitsInStock}).ToList();
            return list1;
        }
        private static void Display(List<string> newList)
        {
            int i = 1;
            foreach (var c in newList)
            {
                Console.Write(i + ".");
                for(int j = 0; j < c.Length; j++)
                {
                    Console.Write("*");
                }
                
                i++;
                Console.WriteLine();
            }
        }

        private static void DisplayList(List<NewClass> newList)
        {
            int i = 1;
            foreach (var c in newList)
            {
                if(i == 5)
                {
                    break;
                }
                Console.Write("{0,-35}",c.NewClassName);
                Console.WriteLine(c.NewClassUnitsInStock);
                i++;
            }
        }

        private static void DisplayList(List<ProductCategory> newList)
        {
            int i = 1;
            foreach (var c in newList)
            {
                if(i == 5)
                {
                    break;
                }
                Console.Write("{0,-35}", c.ProductName);
                Console.WriteLine(c.CategoryName);
                i++;
            }
        }

        public static void GetWithAnonymous(List<Product> produt)
        {
            int i = 0;
            foreach( var item in (from p in (produt) select new { var = p.ProductName, var2 = p.UnitsInStock }).ToList())
            {
                if(i == 5)
                {
                    break;
                }
                Console.Write("{0,-25}",item.var);
                Console.WriteLine(item.var2);
                i++;
            }
            
        }

        public static List<ProductCategory> GetProductCategory(List<Product> product,List<Category> category)
        {
             var list1 = (from p in product join c in category on p.CategoryId equals c.CategoryId select new ProductCategory() 
             { ProductName = p.ProductName, CategoryName = c.CategoryName }).ToList();
            return list1;
        }

        //private static List<Category> GetRecords()
        //{
        //    using (SqlConnection con1 = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
        //    {

        //        var category1 = con1.Query<Category>("SELECT * FROM Categories").ToList();
        //        return category1;
        //    }
        //}

    }
}
