using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWholesalerService" in both code and config file together.
    [ServiceContract]
    public interface IWholesalerService
    {
        [OperationContract]
        List<Wholesaler> getAllWholesaler();
        [OperationContract]
        Wholesaler findWholesalerById(string wId);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createWholesaler(Wholesaler wholesaler);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateWholesaler(Wholesaler wholesaler);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteWholesaler(string wId);
        [OperationContract]
        string getWholesalerId(int countryId);

    }
}
