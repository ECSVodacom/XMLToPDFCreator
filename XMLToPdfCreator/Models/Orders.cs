// Decompiled with JetBrains decompiler
// Type: Orders
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class Orders
{
  private OrdersFileInformation fileInformationField;
  private OrdersOrder orderField;

  public OrdersFileInformation FileInformation
  {
    get => this.fileInformationField;
    set => this.fileInformationField = value;
  }

  public OrdersOrder Order
  {
    get => this.orderField;
    set => this.orderField = value;
  }
}
