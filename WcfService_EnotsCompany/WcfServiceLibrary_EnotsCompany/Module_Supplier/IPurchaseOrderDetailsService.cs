using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
using System.Transactions;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPurchaseOrderDetailsService" in both code and config file together.
    [ServiceContract]
    public interface IPurchaseOrderDetailsService
    {
        [OperationContract]
        List<PurchaseOrderDetail> getAllPurchaseOrderDetails();

        [OperationContract]
        List<PurchaseOrderDetail> findPurchaseOrderDetailbypId(string pId);

        [OperationContract]
        PurchaseOrderDetail findPurchaseOrderDetailsById(int pdetailId);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createPurchaseOrderDetails(PurchaseOrderDetail pdetail);
        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updatePurchaseOrderDetails(PurchaseOrderDetail pdetail);
        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deletePurchaseOrderDetails(int pdetailId);

       
    }
}
