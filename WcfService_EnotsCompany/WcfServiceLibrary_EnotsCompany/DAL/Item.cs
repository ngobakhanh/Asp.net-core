//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary_EnotsCompany.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Feedbacks = new HashSet<Feedback>();
            this.Item1 = new HashSet<Item>();
            this.PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string DescriptionItem { get; set; }
        public string Unitprice { get; set; }
        public string Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public int MinQuantity { get; set; }
        public Nullable<double> Discount { get; set; }
        public string ImageItem { get; set; }
        public string MoreImage { get; set; }
        public int CategoryId { get; set; }
        public string SupplierId { get; set; }
        public Nullable<int> ParentItem { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Warranty { get; set; }
        public int UnitId { get; set; }
        public string Note { get; set; }
        public string ShippingFee { get; set; }
        public string FAQ { get; set; }
        public string StatusItem { get; set; }

        public virtual Category Category { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Item1 { get; set; }
        [IgnoreDataMember]
        public virtual Item Item2 { get; set; }
        public virtual Unit Unit { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
