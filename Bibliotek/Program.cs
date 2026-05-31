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
            Library library = new Library();

            //This variable checks the current account being used
            Member currentMember = null;
            bool insideLibrary = true;

            while (insideLibrary)
            {
                //Create account
                if (currentMember == null)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to our library!\nPlease follow the instructions to create an account.");

                    Console.Write("1. Please write your name: ");
                    string userName = Console.ReadLine();

                    Console.Write("2. Please write an ID: ");
                    string userId = Console.ReadLine();

                    library.AddMember(userId, userName);

                    foreach (Member m in library.Members)
                    {
                        if (m.MemberId == userId)
                        {
                            currentMember = m;
                            break;
                        }
                    }

                    Console.WriteLine("\nPress Enter to continue to the main menu.");
                    Console.ReadLine();
                }


                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine($"  Logged in as: {currentMember.Name} (ID: {currentMember.MemberId})");
                Console.WriteLine($"  Fines: {currentMember.PenaltyOwed} kr");
                Console.WriteLine("========================================");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View Catalog");
                Console.WriteLine("2. Loan an Item");
                Console.WriteLine("3. Switch/Create new account");
                Console.WriteLine("4. My Loans & Returns"); 
                Console.WriteLine("5. Leave the library"); // Close the program
                Console.WriteLine("----------------------------------------");

                int actionInput;

                while (true)
                {
                    string testActionInput = Console.ReadLine();
                    if (int.TryParse(testActionInput, out actionInput))
                    {
                        break;
                    }
                    Console.WriteLine("Please write a number and not a letter! Try again.");
                }
                switch (actionInput)
                {
                    case 1: // Shows what the library has.
                        Console.Clear();
                        library.ShowCatalog();
                        // Could add a search engine here.
                        // To filter for specific categories or creators.
                        Console.WriteLine("\nPress Enter to return to menu.");
                        Console.ReadLine();
                        break;
                    case 2: // Loan a item from the library
                        Console.Clear();
                        library.ShowCatalog();
                        Console.Write("Enter the ID of the item you want to loan: ");
                        string itemToLoan = Console.ReadLine();

                        string resultMessage = library.LoanItem(itemToLoan, currentMember.MemberId);
                        Console.WriteLine(resultMessage);
                        Console.ReadLine();
                        break;
                    case 3: //Create or Switch account.
                        Console.Clear();
                        Console.WriteLine("---Account Management---");
                        Console.WriteLine("1. Create a brand new account");
                        Console.WriteLine("2. Log in to an existing account");
                        Console.Write("Choose (1-2): ");

                        int subChoice;

                        while (true)
                        {
                            string testSubChoice = Console.ReadLine();
                            if (int.TryParse(testSubChoice, out subChoice))
                            {
                                break;
                            }
                            Console.WriteLine("Please write a number (1 or 2) and not a letter! Try again.");
                        }

                        if (subChoice == 1)
                        {
                            currentMember = null;
                            Console.WriteLine("Logged out. Ready to create a new account.");
                        }
                        else if (subChoice == 2)
                        {
                            Console.Write("Enter your Member ID to log in: ");
                            string loginId = Console.ReadLine();

                            Member foundMember = null;
                            foreach (Member m in library.Members)
                            {
                                if (m.MemberId == loginId)
                                {
                                    foundMember = m;
                                    break;
                                }
                            }

                            if (foundMember != null)
                            {
                                currentMember = foundMember;
                                Console.WriteLine($"Welcome back, {currentMember.Name}");
                            }
                            else
                            {
                                Console.WriteLine("Fel: No member found with that ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. That number is not in this menu.");
                        }

                        Console.WriteLine("\nPress Enter to continue");
                        Console.ReadLine();
                        break;
                    case 4: // Checks your active loans and lets u return them
                        Console.Clear();
                        Console.WriteLine("---My Active Loans---");
                        bool hasLoans = false;

                        foreach (LoanLog loan in library.ActiveLoans)
                        {
                            if (loan.MemberId == currentMember.MemberId)
                            {
                                // shows ID for item and the due date for such item
                                Console.WriteLine($"- Item ID: {loan.ItemId} | Return Date: {loan.DueDate.ToLongTimeString()}");
                                hasLoans = true;
                            }
                        }

                        if (!hasLoans)
                        {
                            Console.WriteLine("You currently have no active loans.");
                            Console.WriteLine("\nPress Enter to return to menu.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\n----------------------------------------");
                            Console.WriteLine("What would you like to do?");
                            Console.WriteLine("1. Return an item");
                            Console.WriteLine("2. Go back to main menu");
                            Console.Write("Choose (1-2): ");

                            int returnChoice;

                            while (true)
                            {
                                string testReturnChoice = Console.ReadLine();
                                if (int.TryParse(testReturnChoice, out returnChoice))
                                {
                                    break;
                                }
                                Console.WriteLine("Please write a number (1 or 2) and not a letter! Try again.");
                            }


                            if (returnChoice == 1)
                            {
                                Console.Write("\nEnter the Item ID of the item you want to return: ");
                                string itemToReturn = Console.ReadLine();

                                library.ReturnItem(itemToReturn, currentMember);
                                Console.WriteLine("\nPress Enter to continue.");
                                Console.ReadLine();
                            }
                            else if (returnChoice == 2)
                            {
                                Console.WriteLine("Returning to main menu.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid option. That number is not in this menu.");
                                Console.WriteLine("\nPress Enter to continue.");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Thank you for visiting the library! Goodbye!");
                        insideLibrary = false;
                        break;
                }
            }
        }
    }
}