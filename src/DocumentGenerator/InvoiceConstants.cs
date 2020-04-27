using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentGenerator
{
    public class InvoiceConstants
    {
        public static readonly string NewLine = "\n";
        public static readonly string Dashes = "\\";
        public static readonly string InvoiceNumber = "# INV-";
        public static readonly string PDFExtension= ".pdf";
        public static readonly string From = "From: ";
        public static readonly string To = "To: ";
        public static readonly string BalanceDue = "Balance Due: ";
        public static readonly string InvoiceDate = "Invoice Date";
        public static readonly string Term = "Term: ";
        public static readonly string DueDate = "Due Date: ";
        public static readonly string Item = "Item";
        public static readonly string Number = "#";
        public static readonly string Quantity = "Qty";
        public static readonly string Rate = "Rate";
        public static readonly string Amount = "Amount";
        public static readonly string SubTotal = "SubTotal: ";
        public static readonly string Fee = "Fee({0})";
        public static readonly string Total = "Total";
        public static readonly string DateFormat = "MMM dd, yyyy";
    }
}
