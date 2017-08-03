using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
using System.Transactions;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPurchaseOrderService" in both code and config file together.
    [ServiceContract]
    public interface IPurchaseOrderService
    {
        [OperationContract]
        List<PurchaseOrder> getAllPurchaseOrder();
        [OperationContract]
        PurchaseOrder findPurchaseOrderById(string porderId);

        [OperationContract]
        List<PurchaseOrder> findPurchaseOrderByWSId(string wsId);
        [OperationContract]
        string getPurchaseOrderId(string wholesalerId);

        [OperationContract]
        List<PurchaseOrderDetail> findPurchaseOrderDetailbypId(string purchaseId);
        [OperationContract]
        PurchaseOrderDetail findPurchaseOrderDetailsById(int pdetailId);
        [OperationContract]
        bool updatePurchaseOrderDetails(PurchaseOrderDetail pdetail);

        [OperationContract]
        List<PurchaseOrder> findPurchaseOrderByOdDate(DateTime date);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createPurchaseOrder(PurchaseOrder pOrder);
        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updatePurchaseOrder(PurchaseOrder pOrder);
        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deletePurchaseOrder(string porderId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool tranPurcharseOrder(PurchaseOrder purchase, PurchaseOrderDetail purchasedt);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool tranUpdatePurcharseOrder(PurchaseOrder purchase, PurchaseOrderDetail purchasedt);
        //bool purcharseOrder(PurchaseOrder purchase, List<PurchaseOrderDetail> purchasedts);
    }
}
