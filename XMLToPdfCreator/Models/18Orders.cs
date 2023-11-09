// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderOrderTrailer
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderOrderTrailer
{
  private string orderTotalExclDiscExclVatField;
  private string totalDiscountField;
  private string orderTotalInclDiscExclVatField;
  private string totalVATAmountField;
  private string totalOrderValueInclDiscInclVATField;

  public string OrderTotalExclDiscExclVat
  {
    get => this.orderTotalExclDiscExclVatField;
    set => this.orderTotalExclDiscExclVatField = value;
  }

  public string TotalDiscount
  {
    get => this.totalDiscountField;
    set => this.totalDiscountField = value;
  }

  public string OrderTotalInclDiscExclVat
  {
    get => this.orderTotalInclDiscExclVatField;
    set => this.orderTotalInclDiscExclVatField = value;
  }

  public string TotalVATAmount
  {
    get => this.totalVATAmountField;
    set => this.totalVATAmountField = value;
  }

  public string TotalOrderValueInclDiscInclVAT
  {
    get => this.totalOrderValueInclDiscInclVATField;
    set => this.totalOrderValueInclDiscInclVATField = value;
  }
}
