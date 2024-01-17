// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderLineDetailProductDetails
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderLineDetailProductDetails
{
  private string consumerUnitEanField;
  private string supplierProductCodeField;
  private string customerProductCodeField;
  private string supplierProductDescriptionField;
  private string customerProductDescriptionField;

  public string ConsumerUnitEan
  {
    get => this.consumerUnitEanField;
    set => this.consumerUnitEanField = value;
  }

  public string SupplierProductCode
  {
    get => this.supplierProductCodeField;
    set => this.supplierProductCodeField = value;
  }

  public string CustomerProductCode
  {
    get => this.customerProductCodeField;
    set => this.customerProductCodeField = value;
  }

  public string SupplierProductDescription
  {
    get => this.supplierProductDescriptionField;
    set => this.supplierProductDescriptionField = value;
  }

  public string CustomerProductDescription
  {
    get => this.customerProductDescriptionField;
    set => this.customerProductDescriptionField = value;
  }
}
