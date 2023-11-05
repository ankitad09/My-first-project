using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuClass;
namespace travel_agency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ans;
            do
            {
                Menu.ShowMain();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter: yes/no");
                Console.WriteLine("Do you want to continue:");
                ans = Console.ReadLine()?.ToLower();
                try
                {

                    if (ans != "yes" && ans != "no")
                    {
                        throw new InvalidOperationException("Invalid input. Please enter 'yes' or 'no'.");
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    ans = "yes";
                }
            } while (ans == "yes");

            if (ans == "no")
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            Console.ReadLine();


        }
    }
}
