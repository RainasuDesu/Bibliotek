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
       public List<Item> Works { get; set; } = new List<Item>();

       public string Bio { get; set; }
    }
}
