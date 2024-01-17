// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeaderMessageHeaderSupplierDetails
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersOrderHeaderMessageHeaderSupplierDetails
{
  private string supplierOrderPointField;
  private string supplierAccountingPointField;
  private string vendorNameField;
  private string vendorNumberField;

  public string SupplierOrderPoint
  {
    get => this.supplierOrderPointField;
    set => this.supplierOrderPointField = value;
  }

  public string SupplierAccountingPoint
  {
    get => this.supplierAccountingPointField;
    set => this.supplierAccountingPointField = value;
  }

  public string VendorName
  {
    get => this.vendorNameField;
    set => this.vendorNameField = value;
  }

  public string VendorNumber
  {
    get => this.vendorNumberField;
    set => this.vendorNumberField = value;
  }
}
