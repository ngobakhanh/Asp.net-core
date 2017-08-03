using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISupplierService" in both code and config file together.
    [ServiceContract]
    public interface ISupplierService
    {
        [OperationContract]
        List<Supplier> getAllSupplier();


        //[OperationContract]
        //List<Vw_Invoice> getInvoiceBySupplierId(string SupplierId);

        [OperationContract]
        Supplier findSupplierById(string supId);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createSupplier(Supplier sup);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateSupplier(Supplier sup);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteSupplier(string supId);
        [OperationContract]
        string getSupplierId(int countryId);
    }
}
