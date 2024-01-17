using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLToPDFCreator.Models
{
    public partial class OrderLine
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public string? OrderNumber { get; set; }
        public int LineCounter { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public QuantityDetails QuantityDetails { get; set; }
        public CostDetails CostDetails { get; set; }
        public string LineCostExcludingVat { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }
    }
}
