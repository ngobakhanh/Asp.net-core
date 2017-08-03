using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PurchaseOrderDetailsService" in both code and config file together.
    public class PurchaseOrderDetailsService : IPurchaseOrderDetailsService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createPurchaseOrderDetails(PurchaseOrderDetail pdetail)
        {
            PurchaseOrderDetail _e = ctx.PurchaseOrderDetails.Where(p=>p.PurchaseOrderDetailId==pdetail.PurchaseOrderDetailId).SingleOrDefault();

            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.PurchaseOrderDetails.Add(pdetail);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deletePurchaseOrderDetails(int pdetailId)
        {
            PurchaseOrderDetail p = findPurchaseOrderDetailsById(pdetailId);
            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.SaveChanges();
                return true;
            }
            return false;
            
        }

        public List<PurchaseOrderDetail> findPurchaseOrderDetailbypId(string pId)
        {
            List<PurchaseOrderDetail> e = ctx.PurchaseOrderDetails
                .Include("Item")
                .Where(p => p.PurchaseOrderId == pId)
                .ToList();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
    }

        public PurchaseOrderDetail findPurchaseOrderDetailsById(int pdetailId)
        {
            PurchaseOrderDetail e= ctx.PurchaseOrderDetails
                .Include("Item")
                .Where(p => p.PurchaseOrderDetailId == pdetailId)
                .SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        

        public List<PurchaseOrderDetail> getAllPurchaseOrderDetails()
        {
            List<PurchaseOrderDetail> lst = ctx.PurchaseOrderDetails
                .Include("Item")
                .ToList();
            if (lst == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return lst;
            }
        }

        public bool updatePurchaseOrderDetails(PurchaseOrderDetail pdetail)
        {
            PurchaseOrderDetail p = findPurchaseOrderDetailsById(pdetail.PurchaseOrderDetailId);

            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                p.PurchaseOrderDetailId = pdetail.PurchaseOrderDetailId;
                p.PurchaseOrderId = pdetail.PurchaseOrderId;
                p.ItemId = pdetail.ItemId;
                p.Quantity = pdetail.Quantity;
                p.Price = pdetail.Price;
                p.Discount = pdetail.Discount;
                p.Tax = pdetail.Tax;
                p.LineTotal = pdetail.LineTotal;
                p.UnitId = pdetail.UnitId;
                ctx.SaveChanges();
                return true;
            }
                return false;
            
        }
    }
}
