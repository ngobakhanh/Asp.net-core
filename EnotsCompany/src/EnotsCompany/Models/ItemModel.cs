using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference_Item;
using ServiceReference_Supplier;
using ServiceReference_Category;
using ServiceReference_Unit;
using System.ComponentModel.DataAnnotations;

namespace EnotsCompany.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string DescriptionItem { get; set; }
        public string Price { get; set; }
        public int MinQuantity { get; set; }
        public Nullable<double> Discount { get; set; }
        public string ImageItem { get; set; }
        public string MoreImage { get; set; }
        public string ImageUpdate { get; set; }
        public Nullable<int> ParentItem { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Warranty { get; set; }
        public string Note { get; set; }
        public string ShippingFee { get; set; }
        public string FAQ { get; set; }
        public string StatusItem { get; set; }


        public int CategoryId { get; set; }
        public string SupplierId { get; set; }
        public int UnitId { get; set; }
        public ServiceReference_Item.Item[] parentitems { get; set; }
        public ServiceReference_Supplier.Supplier[] suppliers { get; set; }
        public ServiceReference_Category.Category[] categories { get; set; }
        public ServiceReference_Unit.Unit[] units { get; set; }
    }
}
