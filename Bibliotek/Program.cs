using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bibliotek
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                  Library library = new Library();

                  Console.WriteLine("Hello, welcome to our library!\nPlease follow the intructions to create a account!");

                  Console.WriteLine("1. Please write your name.");
                  string userName = Console.ReadLine();

                  Console.WriteLine("2. Please write a id.");
                  string userId = Console.ReadLine();

                  library.AddMember(userId, userName);
            }
            

            
        }

    }
}