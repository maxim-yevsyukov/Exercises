using System;
using System.Collections.Generic;

namespace DatabaseCRUD_EF.Models
{
    public partial class Person
    {
        public Person()
        {
            Orders = new HashSet<Order>();
        }

        public int PersonId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }

        public override string ToString()
        {
            return $"PersonId: {PersonId}, NameFirst: '{NameFirst}', NameLast: '{NameLast}'";
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
