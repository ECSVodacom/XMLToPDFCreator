// Decompiled with JetBrains decompiler
// Type: OrdersOrderHeader
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

using System;

public class OrdersOrderHeader
{
  private string senderField;
  private string receiverField;
  private string interchangeNoField;
  private DateTime dateField;
  private OrdersOrderHeaderMessageHeader messageHeaderField;

  public string Sender
  {
    get => this.senderField;
    set => this.senderField = value;
  }

  public string Receiver
  {
    get => this.receiverField;
    set => this.receiverField = value;
  }

  public string InterchangeNo
  {
    get => this.interchangeNoField;
    set => this.interchangeNoField = value;
  }

  public DateTime Date
  {
    get => this.dateField;
    set => this.dateField = value;
  }

  public OrdersOrderHeaderMessageHeader MessageHeader
  {
    get => this.messageHeaderField;
    set => this.messageHeaderField = value;
  }
}
