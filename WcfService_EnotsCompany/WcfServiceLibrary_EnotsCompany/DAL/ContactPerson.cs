//////////////////
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

    public partial class ContactPerson
    {
        public int ContactPersonId { get; set; }
        public string WholesalerId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StatusCP { get; set; }

        [IgnoreDataMember]
        public virtual Wholesaler Wholesaler { get; set; }
    }
}