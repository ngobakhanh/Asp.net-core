using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnotsCompany.Models
{
    public class WholesalerModel
    {
        public string WholesalerId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressWS { get; set; }
        public int CountryId { get; set; }
        public string Website { get; set; }
        public string StatusWS { get; set; }
        public int ContactPersonId { get; set; }
        public string CompanyName { get; set; }
        public string CEmail { get; set; }
        public string CPhone { get; set; }
        public string StatusCP { get; set; }


        public ServiceReference_Country.Country[] coutries { get; set; }

        public ServiceReference_Wholesaler.Wholesaler[] wholesalers { get; set; }


        public ServiceReference_Wholesaler.Wholesaler salerbyId { get; set; }

        public ServiceReference_PurchaseOrder.PurchaseOrder[] pOdersbyWSId { get; set; }
        public ServiceReference_PurchaseOrderDetail.PurchaseOrderDetail[] pOderDetail { get; set; }

        public ServiceReference_Invoice.Invoice[] getInvoicebyWSId { get; set; }

        //change password

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
