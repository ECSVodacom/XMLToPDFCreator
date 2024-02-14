using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XMLToPDFCreator.Repository;

namespace XMLToPDFCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XMLPDFEmbedController : ControllerBase
    {

        private readonly ILogger<XMLToPDFController> _logger;
        private readonly IConfiguration _configuration;

        public XMLPDFEmbedController(ILogger<XMLToPDFController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost(Name = "XMLPDFEmbed")]
        [Consumes("application/xml")]

        public ActionResult Post(Orders testModel)
        {
            string xmlString = SerializeToXml(testModel);

            XDocument xdocument = XDocument.Parse(xmlString, LoadOptions.None);
            XElement xelement1 = xdocument.Element((XName)"Orders");
            Document document = new Document();
            document.DefaultPageSetup.Orientation = (Orientation)1;
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
            string str6 = string.Concat(strArray);
            section2.AddParagraph(str6);
            section1.AddParagraph();
            Table table = XMLPDFEmbedController.CreateTable(section1);
            XMLPDFEmbedController.SetColumns(table);
            XMLPDFEmbedController.SetTableHeaders(table);
            foreach (XElement descendant in xelement1?.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"MessageHeader")?.Element((XName)"OrderLineDetails")?.Descendants((XName)"LineDetail"))
            {
                Row row1 = table.Rows.AddRow();
                row1.HeightRule = (RowHeightRule)0;
                row1.Height = 20;
                row1.Format.Font.Size = 8;
                row1.Cells[0].AddParagraph(descendant.Element((XName)"LineCounter")?.Value);
                row1.Cells[0].Format.Alignment = (ParagraphAlignment)1;
                row1.Cells[0].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[1].AddParagraph((descendant.Element((XName)"ProductDetails")?.Element((XName)"SupplierProductCode")?.Value ?? descendant.Element((XName)"ProductDetails")?.Element((XName)"CustomerProductCode")?.Value) ?? "");
                row1.Cells[1].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[2].AddParagraph(descendant.Element((XName)"ProductDetails")?.Element((XName)"ConsumerUnitEan")?.Value);
                row1.Cells[2].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[3].AddParagraph(descendant.Element((XName)"ProductDetails")?.Element((XName)"SupplierProductDescription")?.Value);
                row1.Cells[3].Format.Font.Size = 7;
                row1.Cells[3].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[4].AddParagraph(descendant.Element((XName)"QuantityDetails")?.Element((XName)"UnitOfMeasure")?.Value);
                row1.Cells[4].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[5].AddParagraph(descendant.Element((XName)"QuantityDetails")?.Element((XName)"NumberOfOrderUnits")?.Value);
                row1.Cells[5].Format.Alignment = (ParagraphAlignment)1;
                row1.Cells[5].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[6].AddParagraph(descendant.Element((XName)"CostDetails")?.Element((XName)"CostPriceExcludingVat")?.Value);
                row1.Cells[6].Format.Alignment = (ParagraphAlignment)2;
                row1.Cells[6].VerticalAlignment = (VerticalAlignment)1;
                row1.Cells[7].AddParagraph(descendant.Element((XName)"LineCostExcludingVat")?.Value);
                row1.Cells[7].Format.Alignment = (ParagraphAlignment)1;
                row1.Cells[7].VerticalAlignment = (VerticalAlignment)1;
                //string str7 = descendant.Element((XName)"LineNarratives")?.Element((XName)"LineNarrative")?.Element((XName)"LineNarrativeText")?.Value;
                //if (!string.IsNullOrEmpty(str7))
                //{
                //    row1.Borders.Bottom.Color = Color.FromRgb((byte)211, (byte)211, (byte)211);
                //    row1.Borders.Bottom.Style = (BorderStyle)2;
                //    Row row2 = table.Rows.AddRow();
                //    row2.Format.Font.Size = 7;
                //    row2.Cells[0].AddParagraph(str7);
                //    row2.Cells[0].Format.Alignment = (ParagraphAlignment)0;
                //    row2.Cells[0].VerticalAlignment = (VerticalAlignment)1;
                //    row2.Cells[0].MergeRight = 6;
                //}
            }
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(false);
            renderer.Document = document;
            renderer.RenderDocument();

            string ordNo = testModel.Order.Header.MessageHeader.OrderDetails.CustomerOrderNumber ?? "";
            int indexCharLength = 1;
            char indexChar = '#';
            int substringStartIndex = ordNo.IndexOf(indexChar) + indexCharLength;
            int length = ordNo.Length - substringStartIndex;
            string orderNumber = ordNo.Substring(substringStartIndex, length);

            string str7 = testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPointName ?? "";
            string str8 = testModel.Order.Header.Receiver;
            string str9 = testModel.Order.Header.Sender;
            string str10 = testModel.Order.Header.MessageHeader.CustomerLocation.CustomerDeliveryPoint ?? "";
            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("yyyyMMdd");
            string str11 = orderNumber + "-" + formattedDate + "." + str9 + "." + str8 + ".xml";

            string base64 = XMLPDFEmbedController.ConvertPdfPageToBase64(renderer);
            xelement1.Element((XName)"FileInformation").Add((object)new XElement((XName)"FileContent", (object)base64));

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage()
            {
                Content = (HttpContent)new StringContent(xdocument.ToString(), Encoding.UTF8, "application/xml")
            };
            httpResponseMessage.Headers.Add("From", xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"Sender")?.Value);
            httpResponseMessage.Headers.Add("To", xelement1.Element((XName)"Order")?.Element((XName)"Header")?.Element((XName)"Receiver")?.Value);

            var content = httpResponseMessage.Content.ReadAsStringAsync();

            return Ok(content);

        }
        static string SerializeToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        static string RemoveSquareBrackets(string xmlString)
        {
            XDocument xDocument = XDocument.Parse(xmlString);

            foreach (var element in xDocument.Descendants())
            {
                // Remove square brackets from the element name
                element.Name = element.Name.LocalName.Replace("[", "").Replace("]", "");
            }

            return xDocument.ToString();
        }
        private static string ConvertPdfPageToBase64(PdfDocumentRenderer renderer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                renderer.PdfDocument.Save((Stream)memoryStream);
                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }

        private static Table CreateTable(Section section)
        {

            Table table = section.AddTable();
            table.Style = "Table";
            table.Borders.Color = Color.Empty;

            table.Borders.Width =0.25;
            table.Borders.Left.Width = 0.25;
            table.Borders.Right.Width = 0.25;
            table.Rows.LeftIndent = 0.25;
            return table;
        }

        private static void SetColumns(Table table)
        {
            table.AddColumn(40).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(80).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(80).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(300).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(40).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(60).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(60).Format.Alignment = (ParagraphAlignment)0;
            table.AddColumn(60).Format.Alignment = (ParagraphAlignment)0;
        }

        private static void SetTableHeaders(Table table)
        {
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = (ParagraphAlignment)1;
            row.VerticalAlignment = (VerticalAlignment)1;
            row.Shading.Color = Color.Empty;
            row.Cells[0].AddParagraph("Line Item");
            row.Cells[0].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[1].AddParagraph("Product Code");
            row.Cells[1].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[2].AddParagraph("Barcode");
            row.Cells[2].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[3].AddParagraph("Product Description");
            row.Cells[3].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[4].AddParagraph("UOM");
            row.Cells[4].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[5].AddParagraph("Qty");
            row.Cells[5].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[6].AddParagraph("Price");
            row.Cells[6].Format.Alignment = (ParagraphAlignment)1;
            row.Cells[7].AddParagraph("Total Cost");
            row.Cells[7].Format.Alignment = (ParagraphAlignment)1;
        }
    }
}
