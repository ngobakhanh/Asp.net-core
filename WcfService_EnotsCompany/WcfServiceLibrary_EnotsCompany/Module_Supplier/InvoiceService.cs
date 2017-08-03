using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InvoiceService" in both code and config file together.
    public class InvoiceService : IInvoiceService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createInvoice(Invoice f)
        {
            Invoice _e = ctx.Invoices.Where(c => c.InvoiceId == f.InvoiceId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Invoices.Add(f);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Invoice> findByWholesalerId(string wholesalerId)
        {
            var query = (from a in ctx.Invoices
                         join b in ctx.PurchaseOrders
                         on a.PurchaseOrderId equals b.PurchaseOrderId
                         where b.WholesalerId == wholesalerId
                         select a).ToList();
            return query;

        }
      

        public string getInvoiceId(string purchaseId)
        {
            int maxId = 0;
            try
            {
                maxId = int.Parse(ctx.Invoices.Max(p => p.InvoiceId.Substring(2)));
                
            }
            catch (Exception ex)
            {
                maxId = -1;
            }
            string cCode = purchaseId.Substring(0, 2);
            string invoiceId = "";

            if (maxId < 0)
            {
                invoiceId = cCode + "0001";
            }
            else if (maxId >= 0 && maxId < 9)
            {
                invoiceId = cCode + "000" + (maxId + 1);
            }
            else if (maxId >= 9 && maxId < 99)
            {
                invoiceId = cCode + "00" + (maxId + 1);
            }
            else if (maxId >= 99 && maxId < 999)
            {
                invoiceId = cCode + "0" + (maxId + 1);
            }
            else if (maxId >= 999 && maxId < 9999)
            {
                invoiceId = cCode + (maxId + 1);
            }

            return invoiceId;
        }

        public List<Invoice> findInvoicebyDate(DateTime date)
        {
            List<Invoice> lst = ctx.Invoices.Where(c => c.InvoiceDate.Value.ToShortDateString() == date.ToShortDateString()).ToList();
            if (lst == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return lst;
            }
        }

        public List<Invoice> findInvoicebyEmployeeId(int empId)
        {
            List<Invoice> lst = ctx.Invoices.Where(c => c.EmloyeeID == empId).ToList();
            if (lst == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return lst;
            }
        }

        public Invoice findInvoicebyId(string id)
        {
            Invoice e= ctx.Invoices.Where(c => c.InvoiceId == id).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Invoice> findInvoicebyPurchaseId(string id)
        {
            List<Invoice> lst = ctx.Invoices.Where(c => c.PurchaseOrderId ==id).ToList();
            if (lst == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return lst;
            }
        }

        public List<Invoice> getAllInvoice()
        {
            List<Invoice> lst = ctx.Invoices
                .Include("PurchaseOrder")
                .Include("Employee")
                .Include("PaymentMethod")
                .Include("Supplier")
                .Include("Wholesaler")
                .ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateInvoice(Invoice f)
        {
            Invoice oldInv = findInvoicebyId(f.InvoiceId);
            if (oldInv == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                
                oldInv.InvoiceId = f.InvoiceId;
                oldInv.PurchaseOrderId = f.PurchaseOrderId;
                oldInv.EmloyeeID = f.EmloyeeID;
                oldInv.SupplierId = f.SupplierId;
                oldInv.WholesalerId = f.WholesalerId;
                oldInv.InvoiceDate = f.InvoiceDate;
                oldInv.PaymentMethodId = f.PaymentMethodId;
                oldInv.CreditCardNumber = f.CreditCardNumber;
                oldInv.CardType = f.CardType;
                oldInv.ExpDate = f.ExpDate;
                oldInv.FromBankNo = f.FromBankNo;
                oldInv.ToBankNo = f.ToBankNo;
                oldInv.InitialPayment = f.InitialPayment;
                oldInv.Note = f.Note;
                oldInv.ShipmentMethod = f.ShipmentMethod;
                oldInv.ShipAddress = f.ShipAddress;
                oldInv.ShipFee = f.ShipFee;
                oldInv.Total = f.Total;
                oldInv.Status = f.Status;
                oldInv.PaypalId = f.PaypalId;
                ctx.SaveChanges();
                return true;
            }
                return false;
           
        }

        public List<Invoice> getAllInvoiceBySupplierId(string supplierId)
        {
            List<Invoice> lst = ctx.Invoices
                .Include("PurchaseOrder")
                .Include("Employee")
                .Include("PaymentMethod")
                .Include("Supplier")
                .Where(i=>i.SupplierId == supplierId)
                .ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }
    }
}
