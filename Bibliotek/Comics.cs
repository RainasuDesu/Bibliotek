using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class Comics : Item
    {

        public int Pages { get; set; }

        public Comics(string id, string name, Creator creator, int releaseYear, int pages)
            : base(id, name, creator, releaseYear)
        {
            Pages = pages;
        }
    }
}
