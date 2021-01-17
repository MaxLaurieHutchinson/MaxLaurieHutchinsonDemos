using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLHDemosDatabaseCreation.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime? Created { get; set; }


        // This is how you express a 1 to many relationship 

        public ICollection<OrderItem> Items { get; set; }
    }
}
