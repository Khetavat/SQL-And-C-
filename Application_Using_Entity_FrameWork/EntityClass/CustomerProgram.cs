using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database3;
using Validation;

namespace EntityClass
{
    public class CustomerProgram
    {
        public static void Customer(string username, string password, string back,int? customerId)
        {
            Console.WriteLine($"Welcome {back} {username}");
            do
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Raise Complaint");
                Console.WriteLine("Option 2 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        int? CustomerIdInput = customerId;
                        string DescriptionInput = ValidationProgram.UserNameInputFromUser("Description");
                        Class1.RaiseComplaint(CustomerIdInput, DescriptionInput);
                        Console.WriteLine("Complaint Raised");
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Class1.Logout(username, password);
                        Console.WriteLine($"{username} logged out");
                        break;

                    }

                }

            } while (true);
        }

        public static void DisplayCustomerDetails()
        {
             Console.WriteLine();
            Console.WriteLine("Customer Details");
            Console.WriteLine();
            var list = Class1.GetCustomers();
            int maxId = 0;
            foreach (var record in list)
            {
                if (record.CustomerId > maxId)
                {
                    maxId = record.CustomerId;
                }
            }
            foreach (var item in list)
            {
                if (maxId == item.CustomerId)
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
