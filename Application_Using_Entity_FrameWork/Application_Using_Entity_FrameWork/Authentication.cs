using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database3;
using EntityClass;


namespace Application_Using_Entity_FrameWork
{
    public class Authentication
    {
        public static List<Vishal_Authentication> Login(string username,string password)
        {
            var list = Class1.GetLogin();
            var Result = (from l in list
                          where l.Username == username && l.Password == password
                          select l
                         ).ToList();
            return Result;
        
        }

        public static void CheckLogin()
        {

            var List = Class1.GetLogin();
            foreach( var item in List)
            {

                if (item.Isactive == "Yes" && item.RoleId == 1)
                {
                    AdminProgram.Admin(item.Username,item.Password, "back");
                    Console.WriteLine();
                }
                if (item.Isactive == "Yes" && item.RoleId == 2)
                {
                    AgentProgram.Agent(item.Username, item.Password, "back");
                    Console.WriteLine();
                }
                if (item.Isactive == "Yes" && item.RoleId == 3)
                {
                    CustomerProgram.Customer(item.Username, item.Password, "back",item.ReferenceId);
                    Console.WriteLine();
                }

            }

        }

        public static void IsActive(string username, string password)
        {
            Class1.IsActive(username, password);
            Console.WriteLine($"{username} logged in");
        }

        private static void Logout(string username, string password)
        {
            Class1.Logout(username, password);
            Console.WriteLine($"{username} logged out");
        }

    }
}
