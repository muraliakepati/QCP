namespace QCP.Trading.ProductManagement.DataAccessComponent.BusinessModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool? IsDiscontinued { get; set; }
        public string Country { get; set; }
        public long Orders { get; set; }
        public double? OrdersValue { get; set; }
    }
}
