
namespace Bibliotek
{
    public enum Genre
    {
        Romance,
        Horror,
        Fantasy,
        Mystery,
        Thriller,
        Adventure
    }
    public class Library
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<LoanLog> ActiveLoans { get; set; } = new List<LoanLog>();
        public List<Member> Members { get; set; } = new List<Member>();

        public void AddMember(string id, string name)
        {
            bool idAlreadyExists = false;

            foreach(Member m in Members)
            {
                if(m.MemberId == id)
                {
                    idAlreadyExists = true;
                    break;
                }
            }
            if(idAlreadyExists)
            {
                Console.WriteLine($"A user with the ID: {id} already exixts. Choose a different ID.");
            }
            else
            {
                Member newMember = new Member { MemberId = id, Name = name, PenaltyOwed = 0 };
                Members.Add(newMember);
                Console.WriteLine($"System: Success! Member: {name} (ID: {id} has been created.");
            }
                
        }
        public void ShowCatalog()
        {
            Console.WriteLine("\n--- LIBRARY CATALOG ---");
            foreach (Item item in Items)
            {
                string type = "Item";
                if (item is Books) type = "Book";
                if (item is Movies) type = "Movie";
                if (item is Manga) type = "Magazine";

                Console.WriteLine($"[{type}] ID: {item.Id} - Name: {item.Name}");
            }
            Console.WriteLine("---------------------\n");
        }
        public string LoanItem(string itemId, string memberId)
        {
            Item foundItem = null;
            foreach (Item item in Items)
            {
                if(item.Id == itemId)
                {
                    foundItem = item;
                    break;
                }
            }

            if(foundItem == null)
            {
                return "Item Does not exist";
            }

            bool isAlreadyLoaned = false;
            foreach (LoanLog loan in ActiveLoans)
            {
                if(loan.ItemId == itemId)
                {
                    isAlreadyLoaned = true;
                    break;
                }
            }

            if (isAlreadyLoaned)
            {
                return "Item is already loaned";
            }

            LoanLog newLoan = new LoanLog
            {
                ItemId = itemId,
                MemberId = memberId,
                DueDate = DateTime.Now.AddSeconds(25)
            };
            ActiveLoans.Add(newLoan);
            return $"Loan complete! {foundItem.Name} has been loaned";
        }

        public void ReturnItem(string itemId, Member member, bool simulateLate)
        {
            LoanLog activeLoan = null;
            foreach (LoanLog loan in ActiveLoans)
            {
                if(loan.ItemId==itemId && loan.MemberId == member.MemberId)
                {
                    activeLoan = loan;
                    break;
                }
            }

            if(activeLoan == null)
            {
                Console.WriteLine("You have not loaned this item!");
                return;
            }

            if(DateTime.Now > activeLoan.DueDate)
            {
                member.PenaltyOwed += 50;
                Console.WriteLine($"{itemId} returned too late. Penalty: 50kr fine.");
            }
            else
            {
                Console.WriteLine($"{itemId} Returned in time.");
            }
            // Remove loan from list
            ActiveLoans.Remove(activeLoan);
        }
    }
}