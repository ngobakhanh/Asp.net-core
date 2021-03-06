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
    
    public partial class Invoice
    {
        public string InvoiceId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string SupplierId { get; set; }
        public string WholesalerId { get; set; }
        public int EmloyeeID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public int PaymentMethodId { get; set; }
        public Nullable<int> CreditCardNumber { get; set; }
        public string CardType { get; set; }
        public Nullable<System.DateTime> ExpDate { get; set; }
        public Nullable<int> FromBankNo { get; set; }
        public Nullable<int> ToBankNo { get; set; }
        public Nullable<double> InitialPayment { get; set; }
        public string Note { get; set; }
        public string ShipmentMethod { get; set; }
        public string ShipAddress { get; set; }
        public Nullable<double> ShipFee { get; set; }
        public string Status { get; set; }
        public Nullable<double> Total { get; set; }
        public string PaypalId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Wholesaler Wholesaler { get; set; }
    }
}
