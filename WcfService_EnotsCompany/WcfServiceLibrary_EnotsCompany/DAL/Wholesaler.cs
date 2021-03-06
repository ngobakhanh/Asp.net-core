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

    public partial class Wholesaler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wholesaler()
        {
            this.ContactPersons = new HashSet<ContactPerson>();
            this.Feedbacks = new HashSet<Feedback>();
            this.Invoices = new HashSet<Invoice>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
        }
    
        public string WholesalerId { get; set; }
        public string Avatar { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressWS { get; set; }
        public int CountryId { get; set; }
        public string Website { get; set; }
        public Nullable<double> Amount { get; set; }
        public string StatusWS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
        public virtual Country Country { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
