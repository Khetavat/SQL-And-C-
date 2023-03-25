using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Database3;

namespace EntityClass
{
    public class AgentProgram
    {
        public static void Agent(string username, string password, string back)
        {
            Console.WriteLine($"Welcome {back} {username}");
            do
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Today's Complaint");
                Console.WriteLine("Option 2 = Resolve Complaint");
                Console.WriteLine("Option 3 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        TodayComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        int ComplaintIdInput = ValidationProgram.NumberInputFromUser("ComplaintId");
                        Console.WriteLine("Enter Multiple Expenses with id and cost in xml format");
                        string MultipleExpenseTypeInput = Console.ReadLine();
                        int AgentIdInput = ValidationProgram.NumberInputFromUser("AgentId");
                        Class1.ResolveComplaint(ComplaintIdInput, MultipleExpenseTypeInput, AgentIdInput);
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Class1.Logout(username, password);
                        Console.Clear();
                        Console.WriteLine($"{username} logged out");
                        break;

                    }
                }
            } while (true);
        }

        private static void TodayComplaint()
        {

            var List = Class1.GetTodayComplaint();
            Console.Write("{0,-15}", "CustomerId");
            Console.Write("{0,-25}", "AreaName");
            Console.Write("{0,-25}", "AgentId");
            Console.WriteLine("{0,-15}", "TotalComplaint");
            Console.WriteLine();

            foreach(var item in List)
            {
                Console.Write("{0,-15}", item.customerid);
                Console.Write("{0,-25}", item.areaname);
                Console.Write("{0,-25}", item.agentid);
                Console.WriteLine("{0,-15}", item.TotalComplaint);
                Console.WriteLine();
            }
        }

        public static void DisplayAgentDetails()
        {
            Console.WriteLine();
            Console.WriteLine("Agent Details");
            Console.WriteLine();
            var list = Class1.GetAgents();
            int maxId = 0;
            foreach (var record in list)
            {
                if (record.AgentId > maxId)
                {
                    maxId = record.AgentId;
                }
            }
            foreach (var item in list)
            {
                if (maxId == item.AgentId)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("CustomerId = {0}", item.AgentId);
                    Console.WriteLine("Firstname = {0}", item.FirstName);
                    Console.WriteLine("Lastname = {0}", item.LastName);
                    Console.WriteLine("--------------------------------");
                }
            }

        }
    }
}
