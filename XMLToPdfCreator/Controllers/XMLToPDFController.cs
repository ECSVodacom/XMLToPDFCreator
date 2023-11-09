// Decompiled with JetBrains decompiler
// Type: BizXMLEmbedder.Controllers.HomeController
// Assembly: BizXMLEmbedder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7800088-41A1-4B9F-85E1-1E002A8B2721
// Assembly location: C:\Users\balom002\Desktop\PdfCreator_test\bin\BizXMLEmbedder.dll

using Microsoft.AspNetCore.Mvc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace BizXMLEmbedder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XMLToPDFController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Index(HttpRequestMessage testModel)
        {
            XElement xelement1 = XDocument.Parse(testModel.Content.ReadAsStringAsync().Result, LoadOptions.None).Element((XName)"Orders");
            Document document = new Document();
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            Section section1 = document.AddSection();
            section1.AddParagraph("Customer Purchase Order Copy Generated from EDI interface");
            section1.AddParagraph();
            section1.AddParagraph();
            section1.AddParagraph("Customer Name: " + (xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"CustomerLocation")?.Element((XName)"CustomerDeliveryPoint")?.Value ?? "|CustomerDeliveryPoint Missing|") + " - " + (xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"CustomerLocation")?.Element((XName)"CustomerDeliveryPointName")?.Value ?? "|CustomerDeliveryPointName Missing|"));
            section1.AddParagraph();
            section1.AddParagraph((xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"Receiver")?.Value ?? "|Receiver Missing|") + " - " + (xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"SupplierDetails")?.Element((XName)"VendorName")?.Value ?? "|VendorName Missing|"));
            section1.AddParagraph();
            string str1 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"Narratives")?.Element((XName)"Narrative")?.Element((XName)"NarrativeText")?.Value;
            Section section2 = section1;
            string[] strArray = new string[10];
            strArray[0] = "Order Date: ";
            XElement xelement2 = xelement1.Element((XName)"Order");
            string str2;
            if (xelement2 == null)
            {
                str2 = (string)null;
            }
            else
            {
                XElement xelement3 = xelement2.Element((XName)"Header");
                if (xelement3 == null)
                {
                    str2 = (string)null;
                }
                else
                {
                    XElement xelement4 = xelement3.Element((XName)"MessageHeader");
                    if (xelement4 == null)
                    {
                        str2 = (string)null;
                    }
                    else
                    {
                        XElement xelement5 = xelement4.Element((XName)"OrderDetails");
                        if (xelement5 == null)
                        {
                            str2 = (string)null;
                        }
                        else
                        {
                            XElement xelement6 = xelement5.Element((XName)"OrderDate");
                            if (xelement6 == null)
                            {
                                str2 = (string)null;
                            }
                            else
                            {
                                string str3 = xelement6.Value;
                                if (str3 == null)
                                    str2 = (string)null;
                                else
                                    str2 = str3.ToString().Split('T')[0];
                            }
                        }
                    }
                }
            }
            if (str2 == null)
                str2 = "|OrderDate Missing|";
            strArray[1] = str2;
            strArray[2] = "\r\nPO Number: ";
            strArray[3] = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"OrderDetails")?.Element((XName)"CustomerOrderNumber")?.Value ?? "|CustomerOrderNumber Missing|";
            strArray[4] = "\r\nOrder Total: ";
            strArray[5] = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"OrderTrailer")?.Element((XName)"OrderTotalExclDiscExclVat")?.Value ?? "|OrderTotalExclDiscExclVat Missing|";
            strArray[6] = "\r\nDelivery Date: ";
            XElement xelement7 = xelement1.Element((XName)"Order");
            string str4;
            if (xelement7 == null)
            {
                str4 = (string)null;
            }
            else
            {
                XElement xelement8 = xelement7.Element((XName)"Header");
                if (xelement8 == null)
                {
                    str4 = (string)null;
                }
                else
                {
                    XElement xelement9 = xelement8.Element((XName)"MessageHeader");
                    if (xelement9 == null)
                    {
                        str4 = (string)null;
                    }
                    else
                    {
                        XElement xelement10 = xelement9.Element((XName)"DeliveryInstructions");
                        if (xelement10 == null)
                        {
                            str4 = (string)null;
                        }
                        else
                        {
                            XElement xelement11 = xelement10.Element((XName)"EarliestDeliveryDate");
                            if (xelement11 == null)
                            {
                                str4 = (string)null;
                            }
                            else
                            {
                                string str5 = xelement11.Value;
                                if (str5 == null)
                                    str4 = (string)null;
                                else
                                    str4 = str5.ToString().Split('T')[0];
                            }
                        }
                    }
                }
            }
            if (str4 == null)
                str4 = "|EarliestDeliveryDate Missing|";
            strArray[7] = str4;
            strArray[8] = "\r\n";
            strArray[9] = !string.IsNullOrEmpty(str1) ? "Special Instruction: " + str1 : "";
            string paragraphText1 = string.Concat(strArray);
            section2.AddParagraph(paragraphText1);
            section1.AddParagraph();
            Table table = XMLToPDFController.CreateTable(section1);
            XMLToPDFController.SetColumns(table);
            XMLToPDFController.SetTableHeaders(table);
            foreach (XElement descendant in xelement1?.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"OrderLineDetails")?.Descendants((XName)"LineDetail"))
            {
                Row row1 = table.Rows.AddRow();
                row1.HeightRule = RowHeightRule.AtLeast;
                row1.Height = (Unit)20;
                row1.Format.Font.Size = (Unit)8;
                row1.Cells[0].AddParagraph(descendant.Element((XName)"LineCounter")?.Value);
                row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[1].AddParagraph((descendant.Element((XName)"ProductDetails")?.Element((XName)"SupplierProductCode")?.Value ?? descendant.Element((XName)"ProductDetails")?.Element((XName)"CustomerProductCode")?.Value) ?? "");
                row1.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[2].AddParagraph(descendant.Element((XName)"ProductDetails")?.Element((XName)"ConsumerUnitEan")?.Value);
                row1.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[3].AddParagraph(descendant.Element((XName)"ProductDetails")?.Element((XName)"SupplierProductDescription")?.Value);
                row1.Cells[3].Format.Font.Size = (Unit)7;
                row1.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[4].AddParagraph(descendant.Element((XName)"QuantityDetails")?.Element((XName)"UnitOfMeasure")?.Value);
                row1.Cells[4].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[5].AddParagraph(descendant.Element((XName)"QuantityDetails")?.Element((XName)"NumberOfOrderUnits")?.Value);
                row1.Cells[5].Format.Alignment = ParagraphAlignment.Center;
                row1.Cells[5].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[6].AddParagraph(descendant.Element((XName)"CostDetails")?.Element((XName)"CostPriceExcludingVat")?.Value);
                row1.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[6].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[7].AddParagraph(descendant.Element((XName)"LineCostExcludingVat")?.Value);
                row1.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[7].VerticalAlignment = VerticalAlignment.Center;
                string paragraphText2 = descendant.Element((XName)"LineNarratives")?.Element((XName)"LineNarrative")?.Element((XName)"LineNarrativeText")?.Value;
                if (!string.IsNullOrEmpty(paragraphText2))
                {
                    row1.Borders.Bottom.Color = Color.FromRgb((byte)211, (byte)211, (byte)211);
                    row1.Borders.Bottom.Style = BorderStyle.Dot;
                    Row row2 = table.Rows.AddRow();
                    row2.Format.Font.Size = (Unit)7;
                    row2.Cells[0].AddParagraph(paragraphText2);
                    row2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                    row2.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row2.Cells[0].MergeRight = 6;
                }
            }
            PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(false);
            documentRenderer.Document = document;
            documentRenderer.RenderDocument();
            string? str6 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"SupplierDetails")?.Element((XName)"VendorName")?.Value;
            string? str7 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"CustomerLocation")?.Element((XName)"CustomerDeliveryPointName")?.Value;
            string? str8 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"Receiver")?.Value;
            string? str9 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"Sender")?.Value;
            string? str10 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"CustomerLocation")?.Element((XName)"CustomerDeliveryPoint")?.Value;
            string str11 = xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"OrderDetails")?.Element((XName)"CustomerOrderNumber")?.Value + "-" + str6 + "-" + str7 + ".pdf";
            string base64String;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                documentRenderer.PdfDocument.Save((Stream)memoryStream);
                base64String = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            byte[] buffer = Convert.FromBase64String(base64String);
            HttpWebRequest httpWebRequest = WebRequest.Create(new Uri("http://192.168.202.31:9080/msgsrv/http?from=" + str9 + "&filename=MTO-" + str11 + "&to=99999999999")) as HttpWebRequest;
            httpWebRequest.ContentType = "application/pdf";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = (long)buffer.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();
            using (StreamReader streamReader = new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream()))
                return this.Request.CreateResponse<string>(HttpStatusCode.OK, streamReader.ReadToEnd());
        }

        private static byte[] ConvertPdfPageToBase64(PdfDocumentRenderer renderer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                renderer.PdfDocument.Save((Stream)memoryStream);
                return memoryStream.ToArray();
            }
        }

        private static Table CreateTable(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Borders.Color = Color.Empty;
            table.Borders.Width = (Unit)0.25;
            table.Borders.Left.Width = (Unit)0.5;
            table.Borders.Right.Width = (Unit)0.5;
            table.Rows.LeftIndent = (Unit)0;
            return table;
        }

        private static void SetColumns(Table table)
        {
            table.AddColumn((Unit)"1cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"2cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"3cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"13cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"1cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"2cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"2cm").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn((Unit)"2cm").Format.Alignment = ParagraphAlignment.Left;
        }

        private static void SetTableHeaders(Table table)
        {
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Center;
            row.Shading.Color = Color.Empty;
            row.Cells[0].AddParagraph("Line Item");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[1].AddParagraph("Product Code");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("Barcode");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("Product Description");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("UOM");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[5].AddParagraph("Qty");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[6].AddParagraph("Price");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[7].AddParagraph("Line Cost");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
        }
    }
}
