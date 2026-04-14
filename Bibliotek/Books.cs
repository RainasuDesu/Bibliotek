using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class Books : Item
    {

        public string Description { get; set; }
        public int Pages { get; set; }

        public Books(string id, string name, Creator creator, int releaseYear, string description, int pages)
            : base(id, name, creator, releaseYear)
        {
            Description = description;
            Pages = pages;
        }
    }
}

