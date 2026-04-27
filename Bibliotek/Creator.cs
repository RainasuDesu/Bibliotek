using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Creator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDate { get; set; }
        public string Bio { get; set; }

        // Lista med alla verk (books, movies, etc)
        public List<Item> Works { get; set; }

        public Creator(string firstName, string lastName, int birthDate, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Bio = bio;
            Works = new List<Item>();
        }
    }
}
