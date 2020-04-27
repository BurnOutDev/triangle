using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentGenerator
{
    public static class ParagraphExtension
    {
        public static Paragraph AddEmptyLines(this Paragraph paragraph, int times = 1)
        {
            for (int i = 0; i < times; i++)
                paragraph.Add(InvoiceConstants.NewLine);
            return paragraph;
        }

    }
}
