using ReserveProject.Domain.Aggregates.CustomerAggregate;
using ReserveProject.Domain.Aggregates.PaymentTermAggregate;
using ReserveProject.Domain.Aggregates.SalesPersonAggregate;
using ReserveProject.Domain.DTOs.Invoice;
using ReserveProject.Domain.Enums;
using ReserveProject.Domain.Exceptions.Abstract;
using ReserveProject.Domain.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveProject.Domain.Aggregates.InvoiceAggregate
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public InvoiceStatus Status { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int PaymentTermId { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public int SalesPersonId { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public decimal UnTaxedAmount { get; set; }
        public decimal TaxAmmount { get; set; }
        public decimal Total { get; set; }
        public virtual List<InvoiceLine> InvoiceLines { get; set; }

        public Invoice()
        {
            InvoiceLines = new List<InvoiceLine>();
        }

        public static Invoice Create(string invoiceNumber, int customerId, PaymentTerm paymentTerm, DateTimeOffset startDate, int salesPersonId, IEnumerable<InvoiceLineDTO> invoiceLines)
        {
            var invoice = new Invoice()
            {
                InvoiceNumber = invoiceNumber,
                Status = InvoiceStatus.Draft,
                CustomerId = customerId,
                PaymentTerm = paymentTerm,
                StartDate = startDate,
                SalesPersonId = salesPersonId
            };
            invoice.DueDate = invoice.StartDate.AddDays(invoice.PaymentTerm.DaysCount);

            foreach (var line in invoiceLines)
                invoice.InvoiceLines.Add(InvoiceLine.Create(line.Product, line.Description, line.Quantity, line.Price));

            invoice.CalculateValues();

            return invoice;
        }

        public void Update(int customerId, int paymentTermId, DateTimeOffset startDate, int salesPersonId)
        {
            if (Status == InvoiceStatus.Open || Status == InvoiceStatus.Paid)
                throw new DomainException($"{InvoiceNumber} Invoice data cannot be updated");
            CustomerId = customerId;
            PaymentTermId = paymentTermId;
            StartDate = startDate;
            SalesPersonId = salesPersonId;
            DueDate = CalculateDueDate();
        }

        public void AddInvoiceLine(InvoiceLineDTO invoiceLine)
        {
            if (Status == InvoiceStatus.Open || Status == InvoiceStatus.Paid)
                throw new DomainException($"{InvoiceNumber} Invoice data cannot be updated");
            var line = InvoiceLine.Create(invoiceLine.Product, invoiceLine.Description, invoiceLine.Quantity, invoiceLine.Price);
            InvoiceLines.Add(line);

            CalculateValues();
        }

        public void DeleteInvoiceLine(int invoiceLineId)
        {
            if (Status == InvoiceStatus.Open || Status == InvoiceStatus.Paid)
                throw new DomainException($"{InvoiceNumber} Invoice data cannot be updated");
            var invoiceLine = InvoiceLines.SingleOrDefault(x => x.Id == invoiceLineId);
            InvoiceLines.Remove(invoiceLine);

            invoiceLine.Delete();
            CalculateValues();

        }

        public void Validate()
        {
            Status = InvoiceStatus.Open;
        }

        private void CalculateValues()
        {
            UnTaxedAmount = InvoiceLines.Sum(x => x.SubTotal);
            TaxAmmount = InvoiceLines.Sum(x => x.TaxAmmount);
            Total = UnTaxedAmount + TaxAmmount;
        }

        public override void Delete()
        {
            base.Delete();
        }

        private DateTimeOffset CalculateDueDate() =>
            StartDate.AddDays(PaymentTerm.DaysCount);


    }
}
