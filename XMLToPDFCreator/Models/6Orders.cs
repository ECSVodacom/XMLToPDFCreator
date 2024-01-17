// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderCustomerLocation
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderCustomerLocation
{
  private string customerDeliveryPointField;
  private string customerOrderPointField;
  private string customerDeliveryPointNameField;

  public string CustomerDeliveryPoint
  {
    get => this.customerDeliveryPointField;
    set => this.customerDeliveryPointField = value;
  }

  public string CustomerOrderPoint
  {
    get => this.customerOrderPointField;
    set => this.customerOrderPointField = value;
  }

  public string CustomerDeliveryPointName
  {
    get => this.customerDeliveryPointNameField;
    set => this.customerDeliveryPointNameField = value;
  }
}
