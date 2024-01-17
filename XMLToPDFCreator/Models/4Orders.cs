// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeader
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

using System.Xml.Serialization;

public class OrdersOrderHeaderMessageHeader
{
  private string messageReferenceNrField;
  private string messageVersionNumberField;
  private OrdersOrderHeaderMessageHeaderSupplierDetails supplierDetailsField;
  private OrdersOrderHeaderMessageHeaderCustomerLocation customerLocationField;
  private OrdersOrderHeaderMessageHeaderOrderDetails orderDetailsField;
  private OrdersOrderHeaderMessageHeaderNarratives narrativesField;
  private OrdersOrderHeaderMessageHeaderDeliveryInstructions deliveryInstructionsField;
  private OrdersOrderHeaderMessageHeaderLineDetail[] orderLineDetailsField;
  private OrdersOrderHeaderMessageHeaderOrderTrailer orderTrailerField;

  public string MessageReferenceNr
  {
    get => this.messageReferenceNrField;
    set => this.messageReferenceNrField = value;
  }

  public string MessageVersionNumber
  {
    get => this.messageVersionNumberField;
    set => this.messageVersionNumberField = value;
  }

  public OrdersOrderHeaderMessageHeaderSupplierDetails SupplierDetails
  {
    get => this.supplierDetailsField;
    set => this.supplierDetailsField = value;
  }

  public OrdersOrderHeaderMessageHeaderCustomerLocation CustomerLocation
  {
    get => this.customerLocationField;
    set => this.customerLocationField = value;
  }

  public OrdersOrderHeaderMessageHeaderOrderDetails OrderDetails
  {
    get => this.orderDetailsField;
    set => this.orderDetailsField = value;
  }

  public OrdersOrderHeaderMessageHeaderNarratives Narratives
  {
    get => this.narrativesField;
    set => this.narrativesField = value;
  }

  public OrdersOrderHeaderMessageHeaderDeliveryInstructions DeliveryInstructions
  {
    get => this.deliveryInstructionsField;
    set => this.deliveryInstructionsField = value;
  }

  [XmlArrayItem("LineDetail", IsNullable = false)]
  public OrdersOrderHeaderMessageHeaderLineDetail[] OrderLineDetails
  {
    get => this.orderLineDetailsField;
    set => this.orderLineDetailsField = value;
  }

  public OrdersOrderHeaderMessageHeaderOrderTrailer OrderTrailer
  {
    get => this.orderTrailerField;
    set => this.orderTrailerField = value;
  }
}
