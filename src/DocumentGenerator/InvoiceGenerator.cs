
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentGenerator
{
    public class InvoiceGenerator
    {

        private Document Document { get; set; }
        private InvoiceGenerator()
        {
        }

        public static InvoiceGenerator InitializeDocument(string path, string name)
        {
            var instance = new InvoiceGenerator();
            var fileName = instance.ConstructName(path, name);
            var writer = new PdfWriter(fileName);
            var pdf = new PdfDocument(writer);
            instance.Document = new Document(pdf, PageSize.A4);
            instance.Document.SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                    .SetFontSize(12);

            return instance;
        }

        public void CreateInvoice(Invoice invoice)
        {
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            ConstructHeader(invoice.Name, invoice.Id, invoice.Total.ToString(), invoice.Currency);

            ConstructPersonalInformations(invoice.SellerName, invoice.SellerCountry, invoice.SellerEmail,
                invoice.BuyerName, invoice.BuyerCountry, invoice.BuyerEmail);

            ConstructInvoiceTerms(invoice.Term, invoice.InvoiceDate, invoice.DueDate, bold);

            ConstructGrid(invoice.Products);

            AddFooter(invoice.SubTotal.ToString(), invoice.Fee.ToString(), invoice.Total.ToString(), invoice.Total.ToString());

            Document.Close();
        }

        private void ConstructHeader(string name, string invoiceId, string amount, string currency)
        {
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            var paragraph =
                new Paragraph()
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetMultipliedLeading(1)
                    .Add(new Text(name)
                            .SetFont(bold)
                            .SetFontSize(24))
                    .AddEmptyLines()
                    .Add(new Text(InvoiceConstants.InvoiceNumber + invoiceId)
                             .SetFont(bold)
                             .SetFontSize(14))
                    .AddEmptyLines(2)
                    .Add(new Text(InvoiceConstants.BalanceDue)
                            .SetFontSize(12))
                    .AddEmptyLines()
                    .Add(new Text(currency + amount)
                            .SetFontSize(16));

            Document.Add(paragraph);
        }

        private void ConstructPersonalInformations(string sellerName, string sellerCountry, string sellerEmail, string buyerName, string buyerCountry, string buyerEmail)
        {
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD);

            Table table = new Table(new UnitValue[]{
                new UnitValue(UnitValue.PERCENT, 50),
                new UnitValue(UnitValue.PERCENT, 50)})
                    .SetWidth(UnitValue.CreatePercentValue(100));
            table.AddCell(ConstructPersonalInformation(InvoiceConstants.From,
                    sellerName,
                    sellerCountry,
                    sellerEmail,
                    bold));
            table.AddCell(ConstructPersonalInformation(InvoiceConstants.To,
                    buyerName,
                    buyerCountry,
                    buyerEmail,
                    bold));

            Document.Add(table);
        }

        private Cell ConstructPersonalInformation(string role, string name, string country, string email, PdfFont bold)
        {
            Paragraph p = new Paragraph()
                    .SetMultipliedLeading(1.0f)
                    .Add(role)
                    .SetFont(bold)
                    .AddEmptyLines()
                    .Add(name)
                    .SetFont(bold)
                    .AddEmptyLines()
                    .Add(country)
                    .AddEmptyLines()
                    .Add(email)
                    .AddEmptyLines();

            Cell cell = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetPaddingBottom(50)
                    .Add(p);

            return cell;
        }

        private void ConstructInvoiceTerms(string term, DateTimeOffset invoiceDate, DateTimeOffset dueDate, PdfFont font)
        {
            Table table = new Table(new UnitValue[]{
                new UnitValue(UnitValue.PERCENT, 50),
                new UnitValue(UnitValue.PERCENT, 50)});
            table
                .SetWidth(UnitValue.CreatePercentValue(40))
                .SetHorizontalAlignment(HorizontalAlignment.RIGHT);

            table
                .AddCell(CreateCell(InvoiceConstants.InvoiceDate, font))
                .AddCell(CreateCell(ConvertDate(invoiceDate, InvoiceConstants.DateFormat)))
                .AddCell(CreateCell(InvoiceConstants.Term, font))
                .AddCell(CreateCell(term))
                .AddCell(CreateCell(InvoiceConstants.DueDate, font))
                .AddCell(CreateCell(ConvertDate(dueDate, InvoiceConstants.DateFormat)));

            Document.Add(table);
        }

        private void ConstructGrid(IEnumerable<Product> products)
        {
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont oblique = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

            var white = new DeviceRgb(255, 255, 255);
            Table table = new Table(new UnitValue[]{
                new UnitValue(UnitValue.PERCENT, 12.5f),
                new UnitValue(UnitValue.PERCENT, 40.0f),
                new UnitValue(UnitValue.PERCENT, 12.5f),
                new UnitValue(UnitValue.PERCENT, 17.5f),
                new UnitValue(UnitValue.PERCENT, 17.5f)});
            table
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetMarginTop(10).SetMarginBottom(10)
                .AddHeaderCell(CreateCell(InvoiceConstants.Number, bold)
                                .SetFontColor(white))
                .AddHeaderCell(CreateCell(InvoiceConstants.Item, bold)
                                .SetFontColor(white))
                .AddHeaderCell(CreateCell(InvoiceConstants.Quantity, bold)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontColor(white))
                .AddHeaderCell(CreateCell(InvoiceConstants.Rate, bold)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontColor(white))
                .AddHeaderCell(CreateCell(InvoiceConstants.Amount, bold)
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontColor(white));

            var black = new DeviceRgb(0, 0, 0);
            table
                .GetHeader()
                .SetBackgroundColor(black);

            foreach (var product in products)
            {
                table
                    .AddCell(CreateCell(product.Id.ToString()))
                    .AddCell(CreateCell(product.Name))
                    .AddCell(CreateCell(product.Quantity.ToString())
                                .SetTextAlignment(TextAlignment.RIGHT))
                    .AddCell(CreateCell(product.Rate.ToString())
                                .SetTextAlignment(TextAlignment.RIGHT))
                    .AddCell(CreateCell(product.Amount.ToString())
                                .SetTextAlignment(TextAlignment.RIGHT));
            }

            table.SetMarginBottom(50);

            Document.Add(table);
        }

        private void AddFooter(string subTotal, string fee, string total, string amountDue)
        {
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            Table table = new Table(new UnitValue[]{
                new UnitValue(UnitValue.PERCENT, 50),
                new UnitValue(UnitValue.PERCENT, 50)});

            table
                .SetHorizontalAlignment(HorizontalAlignment.RIGHT)
                .SetWidth(UnitValue.CreatePercentValue(50));

            table
                .AddCell(CreateCell(InvoiceConstants.SubTotal))
                .AddCell(CreateCell(subTotal))
                .AddCell(CreateCell(string.Format(InvoiceConstants.Fee, fee)))
                .AddCell(CreateCell(fee))
                .AddCell(CreateCell(InvoiceConstants.Total))
                .AddCell(CreateCell(total))
                .AddCell(CreateCell(InvoiceConstants.BalanceDue, bold))
                .AddCell(CreateCell(amountDue, bold))
                .SetTextAlignment(TextAlignment.RIGHT);

            Document.Add(table);
        }

        private string ConvertDate(DateTimeOffset d, string newFormat) => d.ToString(newFormat);

        private Cell CreateCell(params string[] texts)
        {
            var paragraph = new Paragraph();
            foreach (string text in texts)
                paragraph
                    .Add(text);
            return new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .Add(paragraph);
        }

        private Cell CreateCell(string text, PdfFont font)
        {
            return new Cell()
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph(text)
                    .SetFont(font)
                    .SetMultipliedLeading(1));
        }

        private string ConstructName(string path, string name) =>
            path + InvoiceConstants.Dashes + name + InvoiceConstants.PDFExtension;
    }
}

