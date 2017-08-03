using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentMethodService" in both code and config file together.
    [ServiceContract]
    public interface IPaymentMethodService
    {
        [OperationContract]
        List<PaymentMethod> getAllPaymentMethod();
        [OperationContract]
        List<PaymentMethod> findPaymentMethodByName(string payName);
        [OperationContract]
        PaymentMethod findPaymentMethodById(int payId);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createPaymentMethod(PaymentMethod pay);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updatePaymentMethod(PaymentMethod pay);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deletePaymentMethod(int payId);
    }
}
