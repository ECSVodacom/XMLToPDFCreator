// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderDeliveryInstructions
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

using System;

public class OrdersOrderHeaderMessageHeaderDeliveryInstructions
{
  private DateTime earliestDeliveryDateField;
  private DateTime latestDeliveryDateField;

  public DateTime EarliestDeliveryDate
  {
    get => this.earliestDeliveryDateField;
    set => this.earliestDeliveryDateField = value;
  }

  public DateTime LatestDeliveryDate
  {
    get => this.latestDeliveryDateField;
    set => this.latestDeliveryDateField = value;
  }
}
