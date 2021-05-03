using System;
using System.Collections.Generic;

#nullable disable

namespace QCP.Trading.ProductManagement.DataAccessComponent.DataContext
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }

        public virtual PurchaseOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
