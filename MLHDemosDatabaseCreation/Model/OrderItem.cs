using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLHDemosDatabaseCreation.Model
{

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        // this is how you specify a Foreign key 
        public virtual Product Product { get; set; }
    }
}
