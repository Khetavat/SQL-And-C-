using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using Database3;
using EntityClass;

namespace Application_Using_Entity_FrameWork
{
    internal class Program
    {
        static void Main()
        {

            Console.Clear();
            do
            {
                Program.Box();
                Authentication.CheckLogin();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Select the following option   ");
                Console.WriteLine("Option 1 = Log In");
                Console.WriteLine("Option 2 = Exist");
                Console.WriteLine("--------------------------------");
                
                    string ChoiceInput = Console.ReadLine();
                if (ValidationProgram.ChoiceInputValidation(ChoiceInput))
                {
                    char ChoiceInput2 = char.Parse(ChoiceInput);
                    if (ChoiceInput2 == '1')
                    {
                        string UserNameInput = ValidationProgram.UserNameInputFromUser("Username");
                        string PasswordInput = ValidationProgram.PasswordFromUser();
                        var List = Authentication.Login(UserNameInput,PasswordInput);

                        foreach (var item in List)
                        {
                            if (item.RoleId == 1)
                            {
                                Console.WriteLine();
                                Authentication.IsActive(UserNameInput, PasswordInput);
                                Console.Clear();
                                AdminProgram.Admin(UserNameInput, PasswordInput, "");
                            }
                            if (item.RoleId == 2)
                            {
                                Console.WriteLine();
                                Authentication.IsActive(UserNameInput, PasswordInput);
                                Console.Clear();
                                AgentProgram.Agent(UserNameInput, PasswordInput, "");
                            }
                            if (item.RoleId == 3)
                            {
                                Console.WriteLine();
                                Authentication.IsActive(UserNameInput, PasswordInput);
                                Console.Clear();
                                CustomerProgram.Customer(UserNameInput, PasswordInput, "",item.ReferenceId);
                            }
                        }
                        

                    }
                    if (ChoiceInput2 == '2')
                    {
                        break;
                    }
                }
            } while (true);
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
            Console.Write("║  "); // your text inside the box
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ║");
            Console.SetCursorPosition(left, top + 2);
            Console.WriteLine("╚" + horizontalLine + "╝");

            Console.ForegroundColor = ConsoleColor.White;

        }

        
    }
}
