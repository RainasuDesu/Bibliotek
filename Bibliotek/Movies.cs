using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    internal class Movies : Item
    {

        public TimeSpan MovieLength { get; set; }

        public Movies(string id, string name, Creator creator, int releaseYear, TimeSpan movieLength)
            : base(id, name, creator, releaseYear)
        {
            MovieLength = movieLength;
        }
    }
}
