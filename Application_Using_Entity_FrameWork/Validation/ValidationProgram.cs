using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public class ValidationProgram
    {
        static void Main(string[] args)
        {
        }
        
        public static bool ChoiceInputValidation(string Input)
        {
            if (Input == null || Input == "")
            {
                return false;
            }
            foreach (char c in Input)
            {
                if (c >= '0' && c <= '9')
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
                if (c >= 'a' && c <= 'z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
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
            if (Input == "")
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

        public static string UserNameInputFromUser(string Input)
        {
            do
            {
                Console.WriteLine($"Enter a {Input}");
                string NameInput = Console.ReadLine();

                if (ValidationProgram.UserInputValidation(NameInput))
                {
                    return NameInput;

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        public static string PasswordFromUser()
        {
            do
            {
                Console.WriteLine("Enter a Password");
                string PasswordInput = Console.ReadLine();
                if (ValidationProgram.PasswordInputValidation(PasswordInput))
                {
                    return PasswordInput;

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);
        }

        public static int NumberInputFromUser(string Input)
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

        public static int NumberWithNullableInputFromUser(string Input)
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
                if (flag == false)
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
    }
}
