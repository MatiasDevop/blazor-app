using System;
using Enums;

namespace ViewModels.Dtos
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}