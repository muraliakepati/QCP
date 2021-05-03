using System;
using System.Collections.Generic;

#nullable disable

namespace QCP.Trading.ProductManagement.DataAccessComponent.DataContext
{
    public partial class Customer
    {
        public Customer()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
