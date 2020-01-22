using System;
using System.Collections.Generic;

namespace DatabaseCRUD_EF.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public DateTime OrderDateTime { get; set; }

        public virtual Person Person { get; set; }
    }
}
