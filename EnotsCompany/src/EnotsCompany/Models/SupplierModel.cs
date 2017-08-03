using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnotsCompany.Models
{
    public class SupplierModel
    {
        public string SupplierId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string MainProduct { get; set; }
        public int CategoryId { get; set; }
        public string Website { get; set; }
        public Nullable<int> Zipcode { get; set; }
        public int CountryId { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string BussinessType { get; set; }
        public Nullable<System.DateTime> YearEstablished { get; set; }
        public string TotalEmployees { get; set; }

        public ServiceReference_Country.Country[] countries { get; set; }
        public ServiceReference_Category.Category[] categories { get; set; }

        public List<ServiceReference_Supplier.Supplier> suppliers { get; set; }

        public ServiceReference_Supplier.Supplier supplier { get; set; }
        public List<ServiceReference_Item.Item> items { get; set; }
    }
}
