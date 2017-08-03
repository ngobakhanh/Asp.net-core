using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
using System.Transactions;
using System.Data.Entity;

namespace WcfServiceLibrary_EnotsCompany
{
    [ServiceBehavior(TransactionTimeout = "00:00:30")]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PurchaseOrderService" in both code and config file together.
    public class PurchaseOrderService : IPurchaseOrderService
    {
        PurchaseOrderDetailsService pds = new PurchaseOrderDetailsService();
        B2BEntities ctx = new B2BEntities();
        public bool createPurchaseOrder(PurchaseOrder pOrder)
        {
            PurchaseOrder _e = ctx.PurchaseOrders.Where(c => c.PurchaseOrderId == pOrder.PurchaseOrderId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.PurchaseOrders.Add(pOrder);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public string getPurchaseOrderId(string wholesalerId)
        {
            int maxId = 0;
            try
            {
              maxId  = int.Parse(ctx.PurchaseOrders.Max(p => p.PurchaseOrderId.Substring(2)));
            }
            catch (Exception ex)
            {
                maxId = -1;
            }
            string purchaserId = "";
            string cCode = wholesalerId.Substring(0, 2);

            if (maxId < 0)
            {
                purchaserId = cCode + "0001";
            }
            else if (maxId >= 0 && maxId < 9)
            {
                purchaserId = cCode + "000" + (maxId + 1);
            }
            else if (maxId >= 9 && maxId < 99)
            {
                purchaserId = cCode + "00" + (maxId + 1);
            }
            else if (maxId >= 99 && maxId < 999)
            {
                purchaserId = cCode + "0" + (maxId + 1);
            }
            else if (maxId >= 999 && maxId < 9999)
            {
                purchaserId = cCode + (maxId + 1);
            }

            return purchaserId;
        }

        public bool deletePurchaseOrder(string porderId)
        {
            PurchaseOrder p = findPurchaseOrderById(porderId);
            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                p.StatusPurchase = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
           
        }

        public PurchaseOrder findPurchaseOrderById(string porderId)
        {
            PurchaseOrder e = ctx.PurchaseOrders
                .Include("PurchaseOrderDetails")
                .Include("Wholesaler")
                .Where(p => p.PurchaseOrderId == porderId).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
           
        }

        public List<PurchaseOrder> findPurchaseOrderByOdDate(DateTime date)
        {
            List<PurchaseOrder> lst = ctx.PurchaseOrders
                .Include("PurchaseOrderDetails")
                .Include("Wholesaler")
                .Where(c => c.PurchaseOrderDate.Value.ToShortDateString() == date.ToShortDateString())
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

        public List<PurchaseOrder> findPurchaseOrderByWSId(string wsId)
        {
            List<PurchaseOrder> lst = ctx.PurchaseOrders
                .Include("PurchaseOrderDetails")
                .Include("Wholesaler")
                .Where(c => c.WholesalerId == wsId)
                .OrderByDescending(p=>p.ReceivedDate)
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
       
        public List<PurchaseOrder> getAllPurchaseOrder()
        {
            List<PurchaseOrder> lst= ctx.PurchaseOrders
                .Include("PurchaseOrderDetails")
                .Include("Wholesaler")
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

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public bool tranPurcharseOrder(PurchaseOrder purchase, PurchaseOrderDetail purchasedt)
        {
            DbContextTransaction tran = null;
            try
            {
                tran = ctx.Database.BeginTransaction();

                // insert purcharse
                ctx.PurchaseOrders.Add(purchase);
                int res = ctx.SaveChanges();

                //get purchase order

               // PurchaseOrder currentPurcharseOrder = ctx.PurchaseOrders.OrderByDescending(x => x.PurchaseOrderId).Take(0).SingleOrDefault();

                if (res > 0)
                {
                    ctx.PurchaseOrderDetails.Add(purchasedt);
                    ctx.SaveChanges();

                }

                tran.Commit();
                return true; /*"nItems " + purchhasedts.Count;*/
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return false;
            }
        }

        public bool updatePurchaseOrder(PurchaseOrder pOrder)
        {
            PurchaseOrder p = findPurchaseOrderById(pOrder.PurchaseOrderId);
            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";
                throw new FaultException<My_Exception.MyFaultException>(myex);
            }
            else
            {
                p.PurchaseOrderId = pOrder.PurchaseOrderId;
                p.PurchaseOrderDate = pOrder.PurchaseOrderDate;
                p.ReceivedDate = pOrder.ReceivedDate;
                p.WholesalerId = pOrder.WholesalerId;
                p.Comment = pOrder.Comment;
                p.StatusPurchase = pOrder.StatusPurchase;
                p.StatusInquiry = pOrder.StatusInquiry;
                ctx.SaveChanges();
                return true;
            }
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public bool tranUpdatePurcharseOrder(PurchaseOrder purchase, PurchaseOrderDetail purchasedt)
        {
            DbContextTransaction tran = null;
            try
            {
                tran = ctx.Database.BeginTransaction();

                // insert purcharse
                ctx.PurchaseOrders.Add(purchase);
                int res = ctx.SaveChanges();

                //get purchase order

                // PurchaseOrder currentPurcharseOrder = ctx.PurchaseOrders.OrderByDescending(x => x.PurchaseOrderId).Take(0).SingleOrDefault();

                if (res > 0)
                {
                    updatePurchaseOrderDetails(purchasedt);
                }

                tran.Commit();
                return true; /*"nItems " + purchhasedts.Count;*/
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return false;
            }
        }

        public List<PurchaseOrderDetail> findPurchaseOrderDetailbypId(string purchaseId)
        {
            List<PurchaseOrderDetail> e = ctx.PurchaseOrderDetails
                .Include("Item")
                .Where(p => p.PurchaseOrderId == purchaseId)
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
            PurchaseOrderDetail e = ctx.PurchaseOrderDetails
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
