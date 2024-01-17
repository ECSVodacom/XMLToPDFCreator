// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderLineDetail
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderLineDetail
{
  private string lineCounterField;
  private OrdersOrderHeaderMessageHeaderLineDetailProductDetails productDetailsField;
  private OrdersOrderHeaderMessageHeaderLineDetailQuantityDetails quantityDetailsField;
  private OrdersOrderHeaderMessageHeaderLineDetailCostDetails costDetailsField;
  private string lineCostExcludingVatField;
  private string lineCostIncludingVatField;
  private OrdersOrderHeaderMessageHeaderLineDetailLineNarratives lineNarrativesField;

  public string LineCounter
  {
    get => this.lineCounterField;
    set => this.lineCounterField = value;
  }

  public OrdersOrderHeaderMessageHeaderLineDetailProductDetails ProductDetails
  {
    get => this.productDetailsField;
    set => this.productDetailsField = value;
  }

  public OrdersOrderHeaderMessageHeaderLineDetailQuantityDetails QuantityDetails
  {
    get => this.quantityDetailsField;
    set => this.quantityDetailsField = value;
  }

  public OrdersOrderHeaderMessageHeaderLineDetailCostDetails CostDetails
  {
    get => this.costDetailsField;
    set => this.costDetailsField = value;
  }

  public string LineCostExcludingVat
  {
    get => this.lineCostExcludingVatField;
    set => this.lineCostExcludingVatField = value;
  }

  public string LineCostIncludingVat
  {
    get => this.lineCostIncludingVatField;
    set => this.lineCostIncludingVatField = value;
  }

  public OrdersOrderHeaderMessageHeaderLineDetailLineNarratives LineNarratives
  {
    get => this.lineNarrativesField;
    set => this.lineNarrativesField = value;
  }
}
