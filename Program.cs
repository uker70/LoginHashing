using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            //menu for login or create user
            Console.WriteLine("1. Login\n2. Create User");
            int loginOrCreateChoice = MenuChoose(1, 2);

            //write the username
            Console.WriteLine("Username");
            string username = Console.ReadLine();

            //loop for 5 tries to login
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Password");
                string password = Console.ReadLine();

                //1 is login and 2 is create user
                if (loginOrCreateChoice == 1)
                {
                    //verifies login and checks if it logged in
                    bool loginSucces = Login.VerifyLogin(username, password);
                    if (loginSucces)
                    {
                        Console.WriteLine("\nLogging in");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nWrong username or password, try again");
                    }
                }
                //creates new user
                else if (loginOrCreateChoice == 2)
                {
                    Login.CreateUser(username, password);
                    Console.WriteLine("\nUser has been created");
                    break;
                }

                //the amount of times you can try to login
                if (i == 4)
                {
                    Console.WriteLine("Too many tries, locking access");
                    Thread.Sleep(5000);
                }
            }


            Console.WriteLine("\nEnter to exit");
            Console.ReadKey(true);
        }

        //menu to select login or create user
        private static int MenuChoose(int numbOne, int numbTwo)
        {
            int input = 0;
            while (input < numbOne || input > numbTwo)
            {
                try
                {
                    Console.Write("\nChoose: ");
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                { }
            }

            return input;
        }
    }
}
