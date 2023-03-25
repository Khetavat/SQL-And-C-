using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application_with_database
{
    internal class Program
    {
        static void Main()
        {

            Console.Clear();
            Program.Box();
            do
            {
                Program.CheckLogin();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Log In");
                Console.WriteLine("Option 2 = Exist");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.LogIn();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        break;
                    }
                }
            } while (true);
        }

        private static void CheckLogin()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                SqlCommand cm = new SqlCommand($"Select  * from Vishal_Authentication", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();

                // Iterating Data  


                while (sdr.Read())
                {

                    if ((string)sdr["Isactive"] == "Yes" && (int)sdr["RoleId"] == 1)
                    {
                        Program.Admin((string)sdr["username"], (string)sdr["password"],"back");
                        Console.WriteLine();
                    }
                    if ((string)sdr["Isactive"] == "Yes" && (int)sdr["RoleId"] == 2)
                    {
                        Program.Agent((string)sdr["username"], (string)sdr["password"],"back");
                        Console.WriteLine();
                    }
                    if ((string)sdr["Isactive"] == "Yes" && (int)sdr["RoleId"] == 3)
                    {
                        Program.Customer((string)sdr["username"], (string)sdr["password"],"back");
                        Console.WriteLine();
                    }

                }
                
            }
        }

        private static void Box()
        {
           
            
            string text = "Welcome to D2H Operator"; // your string

            Console.ForegroundColor = ConsoleColor.Green;
            int width = text.Length + 4; // width of the box
            string horizontalLine = new string('=', width); // horizontal line with double lines

            int windowHeight = Console.WindowHeight;
            int windowWidth = Console.WindowWidth;

            int left = (windowWidth - width) / 2;
            int top = 0;

            Console.SetCursorPosition(left, top);
            Console.WriteLine("╔" + horizontalLine + "╗"); // top line of the box with double lines

            Console.SetCursorPosition(left, top + 1);
            Console.Write("║  " ); // your text inside the box
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("  ║");
            Console.SetCursorPosition(left, top + 2);
            Console.WriteLine("╚" + horizontalLine + "╝");

            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void LogIn()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
               

                    string UserNameInput = UserNameInputFromUser("Username");
                    string PasswordInput = PasswordFromUser();
                    SqlCommand cm = new SqlCommand($"Select  * from Vishal_Authentication where username =  '{UserNameInput}' and password = '{PasswordInput}'", con);
                    // Opening Connection  
                    con.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();

                    // Iterating Data  


                    if (sdr.Read())
                    {
                        
                        Console.WriteLine("Login Success");

                        Program.RedirectingTime();
                        if ((int)sdr["RoleId"] == 1)
                        {
                            Program.IsActive(UserNameInput, PasswordInput);
                            Program.Admin(UserNameInput,PasswordInput,"");
                            
                        }
                        if ((int)sdr["RoleId"] == 2)
                        {
                            Program.IsActive(UserNameInput, PasswordInput);
                            Program.Agent(UserNameInput, PasswordInput,"");
                        }
                        if ((int)sdr["RoleId"] == 3)
                        {
                            Program.IsActive(UserNameInput, PasswordInput);
                            Program.Customer(UserNameInput, PasswordInput,"");
                        }


                    }
                    else
                    {
                        Console.WriteLine("Login Failed");
                    }
            }
                
        }

        private static void IsActive(string username,string password)
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {


                try
                {
                    SqlCommand cm = new SqlCommand($"execute Vishal_IsActive '{username}','{password}'", con);
                    con.Open();
                    // Executing the SQL query  
                    int i = cm.ExecuteNonQuery();

                    // Iterating Data  
                    if (i >= 1)
                    {
                        Console.WriteLine($"{username} loged in");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Try another username or password");
                }
            }
        }

        private static void Customer(string username,string password,string back)
        {
            Console.WriteLine($"Welcome {back} Customer");
            do
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Raise Complaint");
                Console.WriteLine("Option 2 = Exist");
                Console.WriteLine("Option 3 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.RaiseComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        break;
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Program.Logout(username, password);
                        Program.Main();

                    }

                }

            } while (true);
        }

        private static void RedirectingTime()
        {
            Console.Write("Redirecting");
            int Count = 5;
            do
            {
                Console.Write(".");
                Count--;
                Thread.Sleep(300);
            } while (Count > 0);

            Console.Clear();
        }

        private static void Agent(string username,string password,string back)
        {
            Console.WriteLine($"Welcome {back} Agent");
            do
            {
                
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Today's Complaint");
                Console.WriteLine("Option 2 = Resolve Complaint");
                Console.WriteLine("Option 3 = Exist");
                Console.WriteLine("Option 4 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.TodayComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.ResolveComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        break;
                    }
                    if (ChoiceInput2 == '4')
                    {
                        Program.Logout(username, password);
                        Program.Main();

                    }
                }
            } while (true);
        }

        private static void TodayComplaint()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                SqlCommand cm = new SqlCommand($"Execute Vishal_TodayComplaint", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                Program.RedirectingTime();
                // Iterating Data  
                Console.Write("{0,-15}", "CustomerId");
                Console.Write("{0,-25}", "AreaName");
                Console.Write("{0,-25}", "AgentId");
                Console.WriteLine("{0,-15}", "TotalComplaint");
                Console.WriteLine();

                while (sdr.Read())
                {
                    Console.Write("{0,-15}", sdr["CustomerId"]);
                    Console.Write("{0,-25}", sdr["AreaName"]);
                    Console.Write("{0,-25}", sdr["AgentId"]);
                    Console.WriteLine("{0,-15}", sdr["TotalComplaint"]);
                    Console.WriteLine();
                }
            }
        }

        private static void Admin(string username,string password,string back)
        {
            Console.WriteLine($"Welcome {back} Admin");
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Add Master");
                Console.WriteLine("Option 2 = Add Transaction");
                Console.WriteLine("Option 3 = Reports");
                Console.WriteLine("Option 4 = Exist");
                Console.WriteLine("Option 5 = Logout");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.AddMaster();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.AddTransaction();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Program.ShowReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        break;
                    }
                    if (ChoiceInput2 == '5')
                    {
                        Program.Logout(username,password);
                        Program.Main();

                    }

                }



            } while (true);
        }

        private static void Logout(string username,string password)
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                try
                {
                    // Creating Connection  


                    // writing sql query  

                    try
                    {
                        SqlCommand cm = new SqlCommand($"execute Vishal_Logout '{username}','{password}'", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine($"{username} loged out");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try another username or password");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
            }
        }

        private static void AddUser()
        {
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Which type of user you want to add ");
                Console.WriteLine("Option 1 = Agent");
                Console.WriteLine("Option 2 = Customer");
                Console.WriteLine("Option 3 = Exit");
                Console.WriteLine("--------------------------------");

                string ChoiceInput = Console.ReadLine();
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.AdminAddAgent();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.AdminAddCustomer();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        break;
                    }
                    

                }

            } while (true);
            
            
        }

        private static void AdminAddCustomer()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {


                    string UserNameInput = UserNameInputFromUser("Username");
                    string PasswordInput = PasswordFromUser();
                    int RoleId = 3;
                    try
                    {
                        SqlCommand cm = new SqlCommand($"insert into Vishal_Authentication  (username,password,RoleId,isactive) values('{UserNameInput}', '{PasswordInput}','{RoleId}','No')", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("User Created");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try another username or password");
                    }

            }
        }

        private static void AdminAddAgent()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                try
                {
                    // Creating Connection  


                    // writing sql query  



                    string UserNameInput = UserNameInputFromUser("Username");
                    string PasswordInput = PasswordFromUser();
                    int RoleId = 2;
                    try
                    {
                        SqlCommand cm = new SqlCommand($"insert into Vishal_Authentication  (username,password,RoleId,isactive) values('{UserNameInput}', '{PasswordInput}','{RoleId}','No')", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("User Created");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try another username or password");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
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
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.RaiseComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.ResolveComplaint();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Program.AddPayment();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        break;
                    }

                }
            } while (true);
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
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    if(ChoiceInput == null || ChoiceInput == "")
                    {
                        continue;
                    }
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.PaymentPendingReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.AgentEfficiencyReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Program.CustomerProfitLossReport();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        break;
                    }

                }
            } while (true);
        }

        private static void CustomerProfitLossReport()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                
                SqlCommand cm = new SqlCommand($"Execute Vishal_CustomerProfitLossReport", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                Program.RedirectingTime();
                // Iterating Data  
                Console.Write("{0,-15}", "CustomerId");
                Console.Write("{0,-25}", "CustomerTotalPayment");
                Console.Write("{0,-25}", "OperatorTotalExpense");
                Console.Write("{0,-25}", "Profit/Loss");


                Console.WriteLine();
                Console.WriteLine();

                while (sdr.Read())
                {
                    Console.Write("{0,-15}", sdr["CustomerId"]);
                    Console.Write("{0,-25}", sdr["CustomerTotalPayment"]);
                    Console.Write("{0,-25}", sdr["OperatorTotalExpense"]);
                    Console.Write("{0,-25}", sdr["Profit/Loss"]);
                    

                    Console.WriteLine();
                }
            }
        }

        private static void AgentEfficiencyReport()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                SqlCommand cm = new SqlCommand($"Execute AgentEfficiency", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                Program.RedirectingTime();
                // Iterating Data  
                Console.Write("{0,-15}", "Areaname");
                Console.Write("{0,-25}", "TotalComplaints");
                Console.Write("{0,-25}", "ComplaintResolveByAgent");
                Console.Write("{0,-25}", "Efficiency");

                Console.WriteLine();

                while (sdr.Read())
                {
                    Console.Write("{0,-15}", sdr["Areaname"]);
                    Console.Write("{0,-25}", sdr["TotalComplaints"]);
                    Console.Write("{0,-25}", sdr["ComplaintResolveByAgent"]);
                    Console.Write("{0,-25}", sdr["Efficiency"]);
 
                    Console.WriteLine();
                }
            }
        }

        private static void PaymentPendingReport()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                int? YearInput = NumberWithNullableInputFromUser("Year");
                string CustomerIDInput = UserNameInputFromUser("CustomerId (like 1,2,3... or pradip,nikhil...)");
                string AgentIdIDInput = UserNameInputFromUser("CustomerId (like 1,2,3... or pradip,nikhil...)");
                SqlCommand cm = new SqlCommand($"Execute Vishal_PaymentPendingReportYearWise {YearInput},'{CustomerIDInput}','{AgentIdIDInput}'", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                Program.RedirectingTime();
                // Iterating Data  
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

                while (sdr.Read())
                {
                    Console.Write("{0,-15}", sdr["CustomerName"]);
                    Console.Write("{0,-10}", sdr["Year"]);
                    Console.Write("{0,-10}", sdr["monthId"]);
                    Console.Write("{0,-15}", sdr["PaymentStatus"]);
                    Console.Write("{0,-15}", sdr["AreaName"]);
                    Console.Write("{0,-15}", sdr["AgentName"]);
                    Console.Write("{0,-25}", sdr["DateOfConnection"]);
                    Console.Write("{0,-10}", sdr["TotalComplaint"]);

                    Console.WriteLine();
                }
            }
        }

        private static void AddPayment()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                int? PaymentMethodidInput = null;
                int YearInput;
                do
                {
                    YearInput = NumberInputFromUser("Year");
                    if(YearInput > DateTime.Now.Year || YearInput < 1900)
                    {
                        Console.WriteLine("Invalid input");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                    
                int MonthIdInput = NumberInputFromUser("MonthIdInput (like 1-January,2-February..)");
                int CustomerIdInput = NumberInputFromUser("CustomerId");
                string StatusInput = UserNameInputFromUser("Payment Status");
                if(StatusInput == "Paid" || StatusInput == "paid")
                {
                    PaymentMethodidInput = NumberInputFromUser("Payment Method id (1-Google pay,2-Phone pay,3-Cash)");
                }
                 
                try
                {
                    SqlCommand cm = new SqlCommand($"execute Vishal_InsertIntoPayments '{YearInput}', '{MonthIdInput}','{CustomerIdInput}'," +
                        $"'{StatusInput}','{PaymentMethodidInput}'", con);
                    con.Open();
                    // Executing the SQL query  
                    int i = cm.ExecuteNonQuery();

                    // Iterating Data  
                    if (i >= 1)
                    {
                        Console.WriteLine("Payment Added");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something goes wrong...");
                }

            }
        }

        private static void ResolveComplaint()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {

                int ComplaintIdInput = NumberInputFromUser("ComplaintId");
                Console.WriteLine("Enter Multiple Expenses with id and cost in xml format");
                string MultipleExpenseTypeInput = Console.ReadLine();
                int AgentIdInput = NumberInputFromUser("AgentId");
                try
                {
                    SqlCommand cm = new SqlCommand($"execute Vishal_CompanitMultipleExpense '{ComplaintIdInput}', '{MultipleExpenseTypeInput}','{AgentIdInput}'", con);
                    con.Open();
                    // Executing the SQL query  
                    int i = cm.ExecuteNonQuery();

                    // Iterating Data  
                    if (i >= 1)
                    {
                        Console.WriteLine("Complaint Resolved");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something goes wrong...");
                }
            }
        }

        private static void RaiseComplaint()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                

                    int CustomerIdInput = NumberInputFromUser("CustomerId");
                    string DescriptionInput = UserNameInputFromUser("Description");
                    try
                    {
                        SqlCommand cm = new SqlCommand($"execute Vishal_RaiseComplaint '{CustomerIdInput}', '{DescriptionInput}'", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("Complaint Raised");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong Customer Id");
                    }

            }
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
                if (Program.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        Program.AddCustomer();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '2')
                    {
                        Program.AddPackage();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '3')
                    {
                        Program.AddAgent();
                        Console.WriteLine();
                    }
                    if (ChoiceInput2 == '4')
                    {
                        Program.AddArea();
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
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                

                    string AreaNameInput = UserNameInputFromUser("Area Name");
                    int AgentIdInput = NumberInputFromUser("AgentId");
                    try
                    {
                        SqlCommand cm = new SqlCommand($"insert into Vishal_Areas  (areaname,agentid) values('{AreaNameInput}', '{AgentIdInput}')", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("Area Created");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try another AgentId");
                    }

            }
        }

        private static void AddAgent()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                try
                {
                    // Creating Connection  


                    // writing sql query  


                    
                    string FirstNameInput = UserNameInputFromUser("FirstName");
                    string LastNameInput = UserNameInputFromUser("LastName");
                    string UserNameInput = UserNameInputFromUser("Username");
                    string PasswordInput = PasswordFromUser();
                    try
                    {
                        SqlCommand cm = new SqlCommand($"execute Vishal_InsertIntoUsersReferenceWithAgent 2,'{FirstNameInput}','{LastNameInput}','{UserNameInput}','{PasswordInput}'", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("Agent Created");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try Next Time");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
            }
        }

        private static void AddPackage()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
                try
                {
                    // Creating Connection  


                    // writing sql query  



                    int PlanCostInput = NumberInputFromUser("Plan Cost");
                    int CustomerIdInput = NumberInputFromUser("CustomerId");
                    try
                    {
                        SqlCommand cm = new SqlCommand($"insert into Vishal_Plans  (plancost,customerid) values('{PlanCostInput}', '{CustomerIdInput}')", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Console.WriteLine("Plan Added");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong.\n" + e);
                }
            }
        }

        private static void AddCustomer()
        {
            using (SqlConnection con = new SqlConnection("Data Source=PC-227\\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa"))
            {
               

                    string FirstNameInput = UserNameInputFromUser("FirstName");
                    string LastNameInput = UserNameInputFromUser("LastName");
                    string DateOfBirthInput = DateInputFromUser("Date Of Birth");
                    string DateOfConnectionInput = DateInputFromUser("Date Of Connection");
                    Plan.DisplayPlan();
                    int PlanIdInput = NumberInputFromUser("Plan Id");
                    Area.DisplayArea();
                    int AreaIdInput = NumberInputFromUser("AreaId");
                    string UserNameInput = UserNameInputFromUser("Username");
                    string PasswordInput = PasswordFromUser();
                    try
                    {
                        SqlCommand cm = new SqlCommand($"execute Vishal_InsertIntoUsersWithReference 3,'{FirstNameInput}','{LastNameInput}','{DateOfBirthInput}', " +
                            $"'{DateOfConnectionInput}','{PlanIdInput}', '{AreaIdInput}','{UserNameInput}','{PasswordInput}'", con);
                        con.Open();
                        // Executing the SQL query  
                        int i = cm.ExecuteNonQuery();

                        // Iterating Data  
                        if (i >= 1)
                        {
                            Customer1.DisplayCustomerDetails();
                            Console.WriteLine("Customer Created");
                        
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try another AreadId");
                    }

            }
        }

        
        internal static string UserNameInputFromUser(string Input)
        {
            do
            {
                Console.WriteLine($"Enter a {Input}");
                string NameInput = Console.ReadLine();

                if (UserInputValidation(NameInput))
                {
                    return NameInput;

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        internal static string PasswordFromUser()
        {
            do
            {
                Console.WriteLine("Enter a Password");
                string PasswordInput = Console.ReadLine();
                if (PasswordInputValidation(PasswordInput))
                {
                    return PasswordInput;

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        internal static int Role()
        {
            do
            {
                Console.WriteLine("Enter 1 for Admin , 2 for Agent or 3 for Customer");
                string Input = Console.ReadLine();
                if (ChoiceInputValidation(Input))
                {
                    int Role1 = int.Parse(Input);
                    return Role1;

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        public static bool ChoiceInputValidation(string Input)
        {
            if (Input == null || Input == "")
            {
                return false;
            }
            foreach (char c in Input)
            {
                if ( c >= '0' && c <= '9')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool PasswordInputValidation(string Input)
        {
            if (Input == null)
            {
                return false;
            }
            if (Input == "")
            {
                return false;
            }
            foreach (char c in Input)
            {
                if (c >= 'a' && c <= 'z' || c >= 'a' && c <= 'z'|| c >= '0' && c <= '9')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool UserInputValidation(string Input)
        {
            if (Input == null)
            {
                return false;
            }
            if(Input == "")
            {
                return false;
            }
            foreach (char c in Input)
            {
                if (c >= 'a' || c <= 'z' || c >= 'a' || c <= 'z' || c == ' ')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        internal static int NumberInputFromUser(string Input)
        {
            do
            {
                Console.WriteLine($"Enter a {Input}");
                string NameInput = Console.ReadLine();

                if (ChoiceInputValidation(NameInput))
                {
                    return int.Parse(NameInput);

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        internal static int NumberWithNullableInputFromUser(string Input)
        {
            do
            {
                bool flag = false;
                Console.WriteLine($"Enter a {Input}");
                string NameInput = Console.ReadLine();

                foreach (char c in NameInput)
                {
                    if (c >= '0' && c <= '9')
                    {

                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                {
                    if (ChoiceInputValidation(NameInput))
                    {
                        return int.Parse(NameInput);

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        public static bool DateValidation(string date)
        {
            DateTime dateTime = DateTime.Now;
            if (DateTime.TryParse(date, out DateTime newdate))
            {
                if (dateTime.Date >= newdate.Date && dateTime.Year >= newdate.Year)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static string DateInputFromUser(string Input)
        {
            do
            {
                Console.WriteLine($"Enter a {Input}");
                string DateInput = Console.ReadLine();
                bool Result = DateValidation(DateInput);
                if (Result)
                {
                    return DateInput;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

            } while (true);
        }

    }
}
