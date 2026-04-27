
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
        public List<Item> Items { get; set; }
        public List<Member> Members { get; set; }

        // Konstruktor
        public Library()
        {
            Items = new List<Item>();
            Members = new List<Member>();
        }

        // Add item to library
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        // Remove item safely (utan bug)
        public void RemoveItem(string id)
        {
            Item itemToRemove = null;

            foreach (Item item in Items)
            {
                if (item.GetId() == id)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        // Loan item
        public Item LoanItem(string itemId, string memberId)
        {
            foreach (Item item in Items)
            {
                if (item.GetId() == itemId)
                {
                    return item;
                }
            }

            return null;
        }

        // Return item (simple version)
        public void ReturnItem(string itemId)
        {
            // Här kan du lägga logik senare
        }

        // Find item by ID
        public string FindItem(string id)
        {
            foreach (Item item in Items)
            {
                if (item.GetId() == id)
                {
                    return item.Name;
                }
            }

            return "Item not found";
        }
        public void AddMember(Member member)
        {
            Members.Add(member);
        }
    }
}