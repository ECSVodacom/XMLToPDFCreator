using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Text;
using XMLToPDFCreator.Models;
using Microsoft.Extensions.Configuration;

namespace XMLToPDFCreator.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class XMLToPDFController : ControllerBase
    {
        private readonly ILogger<XMLToPDFController> _logger;
        private readonly IConfiguration _configuration;

        public XMLToPDFController(ILogger<XMLToPDFController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost(Name = "XMLToPDF")]
        [Consumes("application/xml")]
        public ActionResult Post(Orders testModel)
        {
            Document document = new Document();
            document.DefaultPageSetup.Orientation = Orientation.Landscape;
            Section section1 = document.AddSection();
            section1.AddParagraph("Customer Purchase Order Copy Generated from EDI interface");
            section1.AddParagraph();
            section1.AddParagraph();
            section1.AddParagraph("Customer Name: " + testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPointName ?? "|CustomerDeliveryPoint Missing|" + " - " + testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPoint ?? "|CustomerDeliveryPointName Missing|");
            section1.AddParagraph();
            section1.AddParagraph("Customer EAN Number: " + testModel.Order.Header.Receiver ?? "|Receiver Missing|" + " - " + testModel.Order.Header.MessageHeader.SupplierDetails.VendorName ?? "|VendorName Missing|");
            section1.AddParagraph();
            //string str1 = testModel.Order.Header.MessageHeader.Narratives.Narrative.NarrativeText ?? "";
            Section section2 = section1;
            string[] strArray = new string[10];
            strArray[0] = "Order Date: ";
            var xelement2 = testModel.Order;
            string str2;
            if (xelement2 == null)
            {
                str2 = (string)null;
            }
            else
            {
                var xelement3 = testModel.Order.Header;
                if (xelement3 == null)
                {
                    str2 = (string)null;
                }
                else
                {
                    var xelement4 = testModel.Order.Header.MessageHeader;
                    if (xelement4 == null)
                    {
                        str2 = (string)null;
                    }
                    else
                    {
                        var xelement5 = testModel.Order.Header.MessageHeader.OrderDetails;
                        if (xelement5 == null)
                        {
                            str2 = (string)null;
                        }
                        else
                        {
                            var xelement6 = testModel.Order.Header.MessageHeader.OrderDetails.OrderDate;
                            if (xelement6 == null)
                            {
                                str2 = (string)null;
                            }
                            else
                            {
                                string str3 = xelement6.ToString();
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
            {
                str2 = "|OrderDate Missing|";
            }
            strArray[1] = str2;
            strArray[2] = "\r\nPO Number: ";
            strArray[3] = testModel.Order.Header.MessageHeader.OrderDetails.CustomerOrderNumber ?? "|CustomerOrderNumber Missing|";
            strArray[4] = "\r\nOrder Total: ";
            strArray[5] = testModel.Order.Header.MessageHeader.OrderTrailer.OrderTotalExclDiscExclVat ?? "|OrderTotalExclDiscExclVat Missing|";
            strArray[6] = "\r\nDelivery Date: ";
            var xelement7 = testModel.Order;
            string str4;
            if (xelement7 == null)
            {
                str4 = (string)null;
            }
            else
            {
                var xelement8 = testModel.Order.Header;
                if (xelement8 == null)
                {
                    str4 = (string)null;
                }
                else
                {
                    var xelement9 = testModel.Order.Header.MessageHeader;
                    if (xelement9 == null)
                    {
                        str4 = (string)null;
                    }
                    else
                    {
                        var xelement10 = testModel.Order.Header.MessageHeader.DeliveryInstructions;
                        if (xelement10 == null)
                        {
                            str4 = (string)null;
                        }
                        else
                        {
                            var xelement11 = testModel.Order.Header.MessageHeader.DeliveryInstructions.EarliestDeliveryDate;
                            if (xelement11 == null)
                            {
                                str4 = (string)null;
                            }
                            else
                            {
                                string str5 = xelement11.ToString();
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
            //strArray[9] = !string.IsNullOrEmpty(str1) ? "Special Instruction: " + str1 : "";
            string paragraphText1 = string.Concat(strArray);
            section2.AddParagraph(paragraphText1);
            section1.AddParagraph();
            Table table = XMLToPDFController.CreateTable(section1);
            XMLToPDFController.SetColumns(table);
            XMLToPDFController.SetTableHeaders(table);

            var lineDetails = new List<LineDetail>();

            foreach (var ol in testModel.Order.Header.MessageHeader.OrderLineDetails?.LineDetail)
            {
                lineDetails.Add(new LineDetail
                {
                    LineCounter = ol.LineCounter,
                    ProductDetails = new ProductDetails
                    {
                        ConsumerUnitEan = ol.ProductDetails.ConsumerUnitEan,
                        SupplierProductCode = ol.ProductDetails.SupplierProductCode,
                        CustomerProductCode = ol.ProductDetails.CustomerProductCode,
                        SupplierProductDescription = ol.ProductDetails.SupplierProductDescription
                    },
                    QuantityDetails = new QuantityDetails
                    {
                        NumberOfOrderUnits = ol.QuantityDetails.NumberOfOrderUnits,
                        UnitOfMeasure = ol.QuantityDetails.UnitOfMeasure
                    },

                    CostDetails = new CostDetails
                    {
                        CostPriceExcludingVat = ol.CostDetails.CostPriceExcludingVat
                    },
                    LineCostExcludingVat = ol.LineCostExcludingVat == null ? string.Empty : ol.LineCostExcludingVat
                });

                Row row1 = table.Rows.AddRow();
                row1.HeightRule = RowHeightRule.AtLeast;
                row1.Height = (Unit)20;
                row1.Format.Font.Size = (Unit)8;
                row1.Cells[0].AddParagraph(ol.LineCounter.ToString() ?? "");
                row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[1].AddParagraph(ol.ProductDetails.SupplierProductCode ?? "");
                row1.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[2].AddParagraph(ol.ProductDetails.ConsumerUnitEan ?? "");
                row1.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[3].AddParagraph(ol.ProductDetails.SupplierProductDescription ?? "|Supplier Product Description Missing|");
                row1.Cells[3].Format.Font.Size = (Unit)7;
                row1.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[4].AddParagraph(ol.QuantityDetails.UnitOfMeasure ?? "");
                row1.Cells[4].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[5].AddParagraph(ol.QuantityDetails.NumberOfOrderUnits ?? "");
                row1.Cells[5].Format.Alignment = ParagraphAlignment.Center;
                row1.Cells[5].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[6].AddParagraph(ol.CostDetails.CostPriceExcludingVat ?? "");
                row1.Cells[6].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[6].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[7].AddParagraph(ol.LineCostExcludingVat ?? "");
                row1.Cells[7].Format.Alignment = ParagraphAlignment.Right;
                row1.Cells[7].VerticalAlignment = VerticalAlignment.Center;

            }

            string ordNo = testModel.Order.Header.MessageHeader.OrderDetails.CustomerOrderNumber ?? "";
            int indexCharLength = 1;
            char indexChar = '#';
            int substringStartIndex = ordNo.IndexOf(indexChar) + indexCharLength;
            int length = ordNo.Length - substringStartIndex;
            string orderNumber = ordNo.Substring(substringStartIndex, length);
            
            PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(false);
            documentRenderer.Document = document;
            documentRenderer.RenderDocument();
            string str6 = testModel.Order.Header.MessageHeader.SupplierDetails.VendorName ?? "";
            string str7 = testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPointName ?? "";
            string str8 = testModel.Order.Header.Receiver;
            string str9 = testModel.Order.Header.Sender;
            string str10 = testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPoint ?? "";
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("yyyyMMdd");
            string str11 = orderNumber + "-" + formattedDate + "." + str9 + "." + str8 + ".pdf";
            string base64String;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                documentRenderer.PdfDocument.Save((Stream)memoryStream);
                base64String = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }

            var bizLinkEndPoint = _configuration.GetValue<string>("Settings:BizLinkEndPoint");


            string ordernumber = testModel.Order.Header.MessageHeader.OrderDetails.CustomerOrderNumber;

            byte[] buffer = Convert.FromBase64String(base64String);
            HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(bizLinkEndPoint +"?from=" + str9 + "&to" + str8 + "&filename=ORDER-" + str11 + "&to="+str8)) as HttpWebRequest;
            httpWebRequest.ContentType = "application/pdf";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = (long)buffer.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();
            using (StreamReader streamReader = new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream()))
            
                return Ok();
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
            //table.Borders.Color = Color.Empty;
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
            //row.Shading.Color = Color.Empty;
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
