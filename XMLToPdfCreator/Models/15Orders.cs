﻿// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderLineDetailCostDetails
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderLineDetailCostDetails
{
  private string costPriceExcludingVatField;
  private string costUnitOfMeasureField;

  public string CostPriceExcludingVat
  {
    get => this.costPriceExcludingVatField;
    set => this.costPriceExcludingVatField = value;
  }

  public string CostUnitOfMeasure
  {
    get => this.costUnitOfMeasureField;
    set => this.costUnitOfMeasureField = value;
  }
}
