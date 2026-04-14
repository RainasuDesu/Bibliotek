using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Item
    {
        public string Id;
        public string Name { get; set; }
        public Creator Creator { get; set; }
        public int ReleaseYear { get; set; }

        public Item(string id, string name, Creator creator, int releaseYear)
        {
            Id = id;
            Name = name;
            Creator = creator;
            ReleaseYear = releaseYear;
        }

        public string GetId()
        {
            return Id;
        }
    }

}
