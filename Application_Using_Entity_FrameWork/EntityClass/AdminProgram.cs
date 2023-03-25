using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Database3;
using System.Data.SqlClient;

namespace EntityClass
{
    public class AdminProgram
    {
        static void Main(string[] args)
        {
        }

        public static void Admin(string username, string password, string back)
        {
            Console.WriteLine($"Welcome {back} Admin");
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Add Master");
                Console.WriteLine("Option 2 = Add Transaction");
                Console.WriteLine("Option 3 = Reports");
                Console.WriteLine("Option 4 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        AddMaster();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        AddTransaction();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        ShowReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        Class1.Logout(username, password);
                        Console.Clear();
                        Console.WriteLine($"{username} logged out");
                        break;

                    }

                }

            } while (true);
        }

        private static void AddMaster()
        {
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Add Customer");
                Console.WriteLine("Option 2 = Add Package");
                Console.WriteLine("Option 3 = Add Agent");
                Console.WriteLine("Option 4 = Add Area");
                Console.WriteLine("Option 5 = Exist");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        AddCustomer();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        AddPackage();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        AddAgent();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        AddArea();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '5')
                    {
                        break;
                    }

                }
            } while (true);
        }

        private static void AddArea()
        {
            string AreaNameInput = ValidationProgram.UserNameInputFromUser("Area Name");
            int AgentIdInput = ValidationProgram.NumberInputFromUser("AgentId");

            Class1.InsertIntoArea(AreaNameInput, AgentIdInput);
            Console.WriteLine("Area Added");
            
           
        }

        private static void AddAgent()
        {
            string FirstNameInput = ValidationProgram.UserNameInputFromUser("FirstName");
            string LastNameInput = ValidationProgram.UserNameInputFromUser("LastName");
            string UserNameInput = ValidationProgram.UserNameInputFromUser("Username");
            string PasswordInput = ValidationProgram.PasswordFromUser();

            Class1.InsertIntoAgent(FirstNameInput, LastNameInput, UserNameInput, PasswordInput);
            Console.WriteLine("Agent Created");
            Console.WriteLine();
            AgentProgram.DisplayAgentDetails();

        }
        
        private static void AddPackage()
        {
            int PlanCostInput = ValidationProgram.NumberInputFromUser("Plan Cost");
            int CustomerIdInput = ValidationProgram.NumberInputFromUser("CustomerId");

            Class1.InsertIntoPackage(PlanCostInput, CustomerIdInput);
            Console.WriteLine("Package Added");
        }

        private static void AddCustomer()
        {
            string FirstNameInput = ValidationProgram.UserNameInputFromUser("FirstName");
            string LastNameInput = ValidationProgram.UserNameInputFromUser("LastName");
            string DateOfBirthInput = ValidationProgram.DateInputFromUser("Date Of Birth");
            string DateOfConnectionInput = ValidationProgram.DateInputFromUser("Date Of Connection");
            DisplayPlan();
            int PlanIdInput = ValidationProgram.NumberInputFromUser("Plan Id");
            DisplayArea();
            int AreaIdInput = ValidationProgram.NumberInputFromUser("AreaId");
            string UserNameInput = ValidationProgram.UserNameInputFromUser("Username");
            string PasswordInput = ValidationProgram.PasswordFromUser();

            Class1.InsertIntoCustomer(FirstNameInput,LastNameInput,DateOfBirthInput,DateOfConnectionInput,PlanIdInput,AreaIdInput,UserNameInput, PasswordInput);
            Console.WriteLine("Customer Created");
            Console.WriteLine();
            CustomerProgram.DisplayCustomerDetails();
        }

        internal static void DisplayPlan()
        {
            Console.WriteLine();
            Console.WriteLine("Select the Planid");
            Console.WriteLine();
            Console.Write("{0,-15}", "PlanId");
            Console.WriteLine("{0,-15}", "PlanCost");
            var list = Class1.GetPlan();
            foreach (var item in list)
            {
                Console.Write("{0,-15}", item.PlanId);
                Console.WriteLine("{0,-15}", item.PlanCost);
            }

        }
        internal static void DisplayArea()
        {

            Console.WriteLine();
            Console.WriteLine("Select the AreaId");
            Console.WriteLine();
            Console.Write("{0,-15}", "AreaId");
            Console.Write("{0,-15}", "AreaName");
            Console.WriteLine("{0,-15}", "AgentId");
            var list = Class1.GetArea();
            foreach (var item in list)
            {
                Console.Write("{0,-15}", item.AreaId);
                Console.Write("{0,-15}", item.AreaName);
                Console.WriteLine("{0,-15}", item.AgentId);
            }

        }

        private static void AddTransaction()
        {
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Raise Complaint");
                Console.WriteLine("Option 2 = Resolve Complaint");
                Console.WriteLine("Option 3 = Add Pament");
                Console.WriteLine("Option 4 = Exist");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        int CustomerIdInput = ValidationProgram.NumberInputFromUser("CustomerId");
                        string DescriptionInput = ValidationProgram.UserNameInputFromUser("Description");
                        Class1.RaiseComplaint(CustomerIdInput,DescriptionInput);
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        int ComplaintIdInput = ValidationProgram.NumberInputFromUser("ComplaintId");
                        Console.WriteLine("Enter Multiple Expenses with id and cost in xml format");
                        string MultipleExpenseTypeInput = Console.ReadLine();
                        int AgentIdInput = ValidationProgram.NumberInputFromUser("AgentId");
                        Class1.ResolveComplaint(ComplaintIdInput,MultipleExpenseTypeInput,AgentIdInput);
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {

                        AddPayment();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        break;
                    }

                }
            } while (true);
        }

        private static void AddPayment()
        {
            int? PaymentMethodidInput = 0;
            int YearInput;
            do
            {
                YearInput = ValidationProgram.NumberInputFromUser("Year");
                if (YearInput > DateTime.Now.Year || YearInput < 1900)
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    break;
                }

            } while (true);

            int MonthIdInput = ValidationProgram.NumberInputFromUser("MonthIdInput (like 1-January,2-February..)");
            int CustomerIdInput = ValidationProgram.NumberInputFromUser("CustomerId");
            string StatusInput = ValidationProgram.UserNameInputFromUser("Payment Status");
            if (StatusInput == "Paid" || StatusInput == "paid")
            {
                PaymentMethodidInput = ValidationProgram.NumberInputFromUser("Payment Method id (1-Google pay,2-Phone pay,3-Cash)");
            }
            
            Class1.AddPayment(Convert.ToString(YearInput),MonthIdInput, CustomerIdInput,StatusInput,PaymentMethodidInput);
            Console.WriteLine("Payment Added");
        }

        private static void ShowReport()
        {
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Pending Payment Report");
                Console.WriteLine("Option 2 = Agent Efficiency Report");
                Console.WriteLine("Option 3 = Customer Profit/Loss Report");
                Console.WriteLine("Option 4 = Exist");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    if (ChoiceInput == null || ChoiceInput == "")
                    {
                        continue;
                    }
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        PaymentPendingReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        AgentEfficiencyReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        CustomerProfitLossReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        break;
                    }

                }
            } while (true);
        }

        private static void PaymentPendingReport()
        {
            int? YearInput = ValidationProgram.NumberWithNullableInputFromUser("Year");
            string CustomerIDInput = ValidationProgram.UserNameInputFromUser("CustomerId (like 1,2,3... or pradip,nikhil...)");
            string AgentIdIDInput = ValidationProgram.UserNameInputFromUser("AgentId (like 1,2,3... or pradip,nikhil...)");

            var List = Class1.GetPaymentPendingReport(YearInput,CustomerIDInput,AgentIdIDInput);
            Console.Write("{0,-15}", "CustomerName");
            Console.Write("{0,-10}", "Year");
            Console.Write("{0,-10}", "monthId");
            Console.Write("{0,-15}", "PaymentStatus");
            Console.Write("{0,-15}", "AreaName");
            Console.Write("{0,-15}", "AgentName");
            Console.Write("{0,-25}", "DateOfConnection");
            Console.Write("{0,-10}", "TotalComplaint");

            Console.WriteLine();
            Console.WriteLine();

            foreach(var item in List)
            {
                Console.Write("{0,-15}", item.CustomerName);
                Console.Write("{0,-10}", item.Year);
                Console.Write("{0,-10}", item.MonthId);
                Console.Write("{0,-15}", item.PaymentStatus);
                Console.Write("{0,-15}", item.Areaname);
                Console.Write("{0,-15}", item.AgentName);
                Console.Write("{0,-25}", item.DateOfConnection);
                Console.Write("{0,-10}", item.TotalComplaint);

                Console.WriteLine();
            }
            
        }

        private static void CustomerProfitLossReport()
        {

            var List = Class1.GetCustomerProfitLoss();
            Console.Write("{0,-15}", "CustomerId");
            Console.Write("{0,-25}", "CustomerTotalPayment");
            Console.Write("{0,-25}", "OperatorTotalExpense");
            Console.Write("{0,-25}", "Profit/Loss");


            Console.WriteLine();
            Console.WriteLine();

            foreach(var item in List)
            {
                Console.Write("{0,-15}", item.customerid);
                Console.Write("{0,-25}", item.CustomerTotalPayment);
                Console.Write("{0,-25}", item.OperatorTotalExpense);
                Console.Write("{0,-25}", item.Profit_Loss);


                Console.WriteLine();
            }
            
        }

        private static void AgentEfficiencyReport()
        {
            var List = Class1.GetAgentEfficiency(); 
            Console.Write("{0,-15}", "AgentId");
            Console.Write("{0,-25}", "TotalComplaint");
            Console.Write("{0,-25}", "Solved");
            Console.Write("{0,-25}", "Efficiency");

            Console.WriteLine();

            foreach(var item in List)
            {
                Console.Write("{0,-15}", item.areaname);
                Console.Write("{0,-25}", item.TotalComplaints);
                Console.Write("{0,-25}", item.ComplaintResolveByAgent);
                Console.Write("{0,-25}", item.Efficiency);

                Console.WriteLine();
            }
            
        }
    }
}
