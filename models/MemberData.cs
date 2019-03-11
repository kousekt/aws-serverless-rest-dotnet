using System;

namespace Models
{
    public class MemberData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return String.Format("Id {0}, First {1}, Last {2}, Title {3}, Age {4}",
                Id, FirstName, LastName, Title, Age);
        }
    }
}