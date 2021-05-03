using System;
using System.Collections.Generic;

#nullable disable

namespace QCP.Trading.ProductManagement.DataAccessComponent.DataContext
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
