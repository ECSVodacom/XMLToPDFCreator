// Decompiled with JetBrains decompiler
// Type: OrdersFileInformation
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

public class OrdersFileInformation
{
  private string fileSizeField;
  private string fileNameField;
  private string fileStoreField;
  private string fileContentField;
  private string fileTypeField;

  public string FileSize
  {
    get => this.fileSizeField;
    set => this.fileSizeField = value;
  }

  public string FileName
  {
    get => this.fileNameField;
    set => this.fileNameField = value;
  }

  public string FileStore
  {
    get => this.fileStoreField;
    set => this.fileStoreField = value;
  }

  public string FileContent
  {
    get => this.fileContentField;
    set => this.fileContentField = value;
  }

  public string FileType
  {
    get => this.fileTypeField;
    set => this.fileTypeField = value;
  }
}
