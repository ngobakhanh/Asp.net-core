using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnotsCompany.Models
{
    public class InvoiceModel
    {
        public float Total { get; set; }
        public float ProfitMonth { get; set; }
        public float Saletotal { get; set; }
        public int FAQ { get; set; }

        public List<ServiceReference_Invoice.Invoice> LastInvoices { get; set; }
        public List<ServiceReference_PurchaseOrder.PurchaseOrder> Inquiries { get; set; }
        public List<ServiceReference_Invoice.Invoice> Invoices { get; set; }
    }
}
