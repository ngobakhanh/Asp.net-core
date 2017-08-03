using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInvoiceService" in both code and config file together.
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        List<Invoice> getAllInvoice();

        [OperationContract]
        List<Invoice> getAllInvoiceBySupplierId(string supplierId);

        [OperationContract]
        Invoice findInvoicebyId(string id);

        [OperationContract]
        List<Invoice> findInvoicebyPurchaseId(string id);

        [OperationContract]
        List<Invoice> findInvoicebyEmployeeId(int empId);
        [OperationContract]
        List<Invoice> findByWholesalerId(string wholesalerId);

        [OperationContract]
        List<Invoice> findInvoicebyDate(DateTime date);
        [OperationContract]
        string getInvoiceId(string purchaseId);



        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createInvoice(Invoice f);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateInvoice(Invoice f);

        //[OperationContract]
        //bool deleteInvoice(string id);
    }
}
