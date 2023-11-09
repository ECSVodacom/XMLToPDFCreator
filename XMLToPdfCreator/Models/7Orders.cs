// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderOrderDetails
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

using System;

public class OrdersOrderHeaderMessageHeaderOrderDetails
{
  private string customerOrderNumberField;
  private DateTime orderDateField;
  private OrdersOrderHeaderMessageHeaderOrderDetailsOrderDetailsTransactionCode orderDetailsTransactionCodeField;

  public string CustomerOrderNumber
  {
    get => this.customerOrderNumberField;
    set => this.customerOrderNumberField = value;
  }

  public DateTime OrderDate
  {
    get => this.orderDateField;
    set => this.orderDateField = value;
  }

  public OrdersOrderHeaderMessageHeaderOrderDetailsOrderDetailsTransactionCode OrderDetailsTransactionCode
  {
    get => this.orderDetailsTransactionCodeField;
    set => this.orderDetailsTransactionCodeField = value;
  }
}
