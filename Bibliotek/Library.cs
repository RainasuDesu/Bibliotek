
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

        public Library()
        {
            // --- Manga ---

            Creator ohba = new Creator { Name = "Tsugumi Ohba" };
            Items.Add(new Manga { Id = "M1", Name = "Death Note", ItemCreator = ohba, Volume = 1 });

            Creator isayama = new Creator { Name = "Hajime Isayama" };
            Items.Add(new Manga { Id = "M2", Name = "Attack on Titan", ItemCreator = isayama, Volume = 1 });

            Creator akutami = new Creator { Name = "Gege Akutami" };
            Items.Add(new Manga { Id = "M3", Name = "Jujutsu Kaisen", ItemCreator = akutami, Volume = 1 });

            // --- Books ---

            Creator rowling = new Creator { Name = "J.K. Rowling" };
            Items.Add(new Books { Id = "B1", Name = "Harry Potter and the Philosopher's Stone", ItemCreator = rowling, Pages = 223 });
            Items.Add(new Books { Id = "B2", Name = "Harry Potter and the Chamber of Secrets", ItemCreator = rowling, Pages = 251 });
            Items.Add(new Books { Id = "B3", Name = "Harry Potter and the Prisoner of Azkaban", ItemCreator = rowling, Pages = 480 });

            Creator golding = new Creator { Name = "William Golding" };
            Items.Add(new Books { Id = "B5", Name = "Flugornas herre", ItemCreator = golding, Pages = 208 });

            Creator dashner = new Creator { Name = "James Dashner" };
            Items.Add(new Books { Id = "B6", Name = "The Maze Runner", ItemCreator = dashner, Pages = 375 });

            // --- Movies ---

            Creator columbia = new Creator { Name = "Columbia Pictures" };
            Items.Add(new Movies { Id = "F1", Name = "Spider-Man", ItemCreator = columbia, Duration = new TimeSpan(2, 1, 0) }); // Tobey Maguire
            Items.Add(new Movies { Id = "F2", Name = "Spider-Man 2", ItemCreator = columbia, Duration = new TimeSpan(2, 7, 0) }); // Tobey Maguire

            Creator sonyAnimation = new Creator { Name = "Sony Pictures Animation" };
            Items.Add(new Movies { Id = "F3", Name = "Spider-Man: Into the Spider-Verse", ItemCreator = sonyAnimation, Duration = new TimeSpan(1, 56, 0) });

        }

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
                Console.WriteLine($"System: Success! Member: {name} (ID: {id}) has been created.");
            }
                
        }
        public void ShowCatalog()
        {
            Console.WriteLine("\n--- LIBRARY CATALOG ---");
            foreach (Item item in Items)
            {
                string type = "Item";
                string extraInfo = "";

                if (item is Books bookItem) 
                { 
                    type = "Book"; 
                    extraInfo = $" | Pages: {bookItem.Pages}"; 
                }
                else if (item is Movies movieItem) 
                { 
                    type = "Movie"; 
                    extraInfo = $" | Duration: {movieItem.Duration.Hours}h {movieItem.Duration.Minutes}m"; 
                }
                else if (item is Manga mangaItem) 
                { 
                    type = "Manga"; 
                    extraInfo = $" | Volume: {mangaItem.Volume}"; 
                }

                Console.WriteLine($"[{type}] ID: {item.Id} - Name: {item.Name} | Creator: {item.ItemCreator.Name}{extraInfo}");
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

        public void ReturnItem(string itemId, Member member)
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