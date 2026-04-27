using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Member
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Adress { get; set; }
        public bool IsActive { get; set; }

        public Member(string memberId, string name., string adress)
        {
            MemberId = memberId;
            Name = name;
            Adress = adress;
            RegistrationDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddYears(1);
            IsActive = true;
        }
    }
}
