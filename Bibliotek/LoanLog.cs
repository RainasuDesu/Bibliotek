using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class LoanLog
    {
        public string ItemId { get; set; }
        public string MemberId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
