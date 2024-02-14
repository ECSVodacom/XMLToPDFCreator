using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLToPDFCreator.Models
{
    public partial class OrderHeader
    {
        public OrderHeader()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string Sender { get; set; } = null!;


        public string Receiver { get; set; } = null!;
        public string? DeliveryPoint { get; set; }
        public DateTime DateReceived { get; set; }
        public string? Status { get; set; }
        public string? ResponseDocNumber { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string SupplierOrderPoint { get; set; } = null!;


        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
