
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot(ElementName = "Orders")]
public class Orders
{
    [XmlElement(ElementName = "FileInformation")]
    public FileInformation? FileInformation { get; set; }

    [XmlElement(ElementName = "Order")]
    public Order Order { get; set; }
}

[XmlRoot(ElementName = "FileInformation")]
public class FileInformation
{
    [XmlElement(ElementName = "FileType")]
    public string FileType { get; set; }
}

[XmlRoot(ElementName = "Order")]
public class Order
{
    [XmlElement(ElementName = "Header")]
    public Header Header { get; set; }
}

[XmlRoot(ElementName = "Header")]
public class Header
{
    [XmlElement(ElementName = "Sender")]
    public string Sender { get; set; }

    [XmlElement(ElementName = "Receiver")]
    public string Receiver { get; set; }

    [XmlElement(ElementName = "InterchangeNo")]
    public string InterchangeNo { get; set; }

    [XmlElement(ElementName = "Date")]
    public string Date { get; set; }

    [XmlElement(ElementName = "MessageHeader")]
    public MessageHeader MessageHeader { get; set; } 
}

[XmlRoot(ElementName = "MessageHeader")]
public class MessageHeader
{
    [XmlElement(ElementName = "MessageReferenceNr")]
    public string  MessageReferenceNr { get; set; }

    [XmlElement(ElementName = "SupplierDetails")]
    public SupplierDetails SupplierDetails { get; set; }

    [XmlElement(ElementName = "CustomerLocation")]
    public CustomerLocation CustomerLocation { get; set; }

    [XmlElement(ElementName = "OrderDetails")]
    public OrderDetails OrderDetails { get; set; }

    [XmlElement(ElementName = "Narratives")]
    public Narratives Narratives { get; set; }

    [XmlElement(ElementName = "DeliveryInstructions")]
    public DeliveryInstructions DeliveryInstructions { get; set; }

    [XmlElement(ElementName = "OrderLineDetails")]
    public OrderLineDetails OrderLineDetails { get; set; }

    [XmlElement(ElementName = "OrderTrailer")]
    public OrderTrailer OrderTrailer { get; set; }
}

[XmlRoot(ElementName = "SupplierDetails")]
public class SupplierDetails
{
    [XmlElement(ElementName = "SupplierOrderPoint")]
    public string SupplierOrderPoint { get; set; }

    [XmlElement(ElementName = "VendorName")]
    public string VendorName { get; set; }

    [XmlElement(ElementName = "VendorNumber")]
    public string VendorNumber { get; set; }

    [XmlElement(ElementName = "SupplierAddress")]
    public SupplierAddress SupplierAddress { get; set; }
}

[XmlRoot(ElementName = "SupplierAddress")]
public class SupplierAddress
{
    [XmlElement(ElementName = "SupplierAddress1")]
    public string SupplierAddress1 { get; set; }

    [XmlElement(ElementName = "SupplierAddress3")]
    public string SupplierAddress3 { get; set; }
}

[XmlRoot(ElementName = "CustomerLocation")]
public class CustomerLocation
{
    [XmlElement(ElementName = "CustomerDeliveryPoint")]
    public string CustomerDeliveryPoint { get; set; }

    [XmlElement(ElementName = "CustomerOrderPoint")]
    public string CustomerOrderPoint { get; set; }

    [XmlElement(ElementName = "CustomerDeliveryPointName")]
    public string CustomerDeliveryPointName { get; set; }
}

[XmlRoot(ElementName = "OrderDetails")]
public class OrderDetails
{
    [XmlElement(ElementName = "CustomerOrderNumber")]
    public string CustomerOrderNumber { get; set; }

    [XmlElement(ElementName = "OrderDate")]
    public string OrderDate { get; set; }

    [XmlElement(ElementName = "OrderDetailsTransactionCode")]
    public OrderDetailsTransactionCode OrderDetailsTransactionCode { get; set; }
}

[XmlRoot(ElementName = "OrderDetailsTransactionCode")]
public class OrderDetailsTransactionCode
{
    [XmlElement(ElementName = "TransactionCode")]
    public string TransactionCode { get; set; }
}

[XmlRoot(ElementName = "Narratives")]
public class Narratives
{
    [XmlElement(ElementName = "Narrative")]
    public Narrative Narrative { get; set; }
}

[XmlRoot(ElementName = "ElementName")]
public class Narrative
{
    [XmlElement(ElementName = "NarrativeCounter")]
    public string NarrativeCounter { get; set; }

    [XmlElement(ElementName = "NarrativeText")]
    public string NarrativeText { get; set; }
}

[XmlRoot(ElementName = "DeliveryInstructions")]
public class DeliveryInstructions
{
    [XmlElement(ElementName = "EarliestDeliveryDate")]
    public string EarliestDeliveryDate { get; set; }

    [XmlElement(ElementName = "LatestDeliveryDate")]
    public string LatestDeliveryDate { get; set; }

    [XmlElement(ElementName = "RailDeliveryAddress")]
    public string RailDeliveryAddress { get; set; }
}

[XmlRoot(ElementName = "OrderLineDetails")]
public class OrderLineDetails
{
    [XmlElement("LineDetail")]
    public List<LineDetail> LineDetail { get; set; }
}

[XmlRoot(ElementName = "LineDetail")]
public class LineDetail
{
    [XmlElement(ElementName = "LineCounter")]
    public int LineCounter { get; set; }

    [XmlElement(ElementName = "ProductDetails")]
    public ProductDetails ProductDetails { get; set; }

    [XmlElement(ElementName = "QuantityDetails")]
    public QuantityDetails QuantityDetails { get; set; }

    [XmlElement(ElementName = "CostDetails")]
    public CostDetails CostDetails { get; set; }

    [XmlElement(ElementName = "LineCostExcludingVat")]
    public string LineCostExcludingVat { get; set; }
}



[XmlRoot(ElementName = "ProductDetails")]
public class ProductDetails
{
    [XmlElement(ElementName = "ConsumerUnitEan")]
    public string ConsumerUnitEan { get; set; }

    [XmlElement(ElementName = "SupplierProductCode")]
    public string SupplierProductCode { get; set; }

    [XmlElement(ElementName = "CustomerProductCode")]
    public string CustomerProductCode { get; set; }

    [XmlElement(ElementName = "SupplierProductDescription")]
    public string SupplierProductDescription { get; set; }
}

[XmlRoot(ElementName = "QuantityDetails")]
public class QuantityDetails
{
    [XmlElement(ElementName = "NumberOfOrderUnits")]
    public string NumberOfOrderUnits { get; set; }

    [XmlElement(ElementName = "UnitOfMeasure")]
    public string UnitOfMeasure { get; set; }
}

[XmlRoot(ElementName = "CostDetails")]
public class CostDetails
{
    [XmlElement(ElementName = "CostPriceExcludingVat")]
    public string CostPriceExcludingVat { get; set; }
}

[XmlRoot(ElementName = "OrderTrailer")]
public class OrderTrailer
{
    [XmlElement(ElementName = "OrderTotalExclDiscExclVat")]
    public string OrderTotalExclDiscExclVat { get; set; }

    [XmlElement(ElementName = "TotalDiscount")]
    public string TotalDiscount { get; set; }

    [XmlElement(ElementName = "OrderTotalInclDiscExclVat")]
    public string OrderTotalInclDiscExclVat { get; set; }

    [XmlElement(ElementName = "TotalVatAmount")]
    public string TotalVatAmount { get; set; }

    [XmlElement(ElementName = "TotalOrderValueInclDiscInclVAT")]
    public string TotalOrderValueInclDiscInclVAT { get; set; }
}