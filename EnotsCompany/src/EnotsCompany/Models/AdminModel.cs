using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnotsCompany.Models
{
    public class AdminModel
    {
        public ServiceReference_Supplier.Supplier[] Suppliers { get; set; }

        public ServiceReference_Wholesaler.Wholesaler[] Wholesalers { get; set; }

        public ServiceReference_Employee.Employee[] Employees { get; set; }

        public ServiceReference_Invoice.Invoice[] Invoices { get; set; }

        public ServiceReference_Employee.Employee empById { get; set; }

        public ServiceReference_Article.Article[] Articles { get; set; }

    }
}
