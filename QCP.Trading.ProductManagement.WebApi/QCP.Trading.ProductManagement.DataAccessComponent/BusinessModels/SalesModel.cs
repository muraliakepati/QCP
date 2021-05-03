using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QCP.Trading.ProductManagement.DataAccessComponent.BusinessModels
{
    public class SalesModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string CustomerCountry { get; set; }
        public double OrderAmount { get; set; }
    }
}
