using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IContactPersonService" in both code and config file together.
    [ServiceContract]
    public interface IContactPersonService
    {
        [OperationContract]
        List<ContactPerson> getAllContactPerson();

        [OperationContract]
        ContactPerson findContactPersonbyId(int id);

        [OperationContract]
        List<ContactPerson> findContactPersonbyName(string nameContact);

        [OperationContract]
        ContactPerson findContactPersonbySalerId(string id);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createContactPerson(ContactPerson c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateContactPerson(ContactPerson c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteContactPerson(int id);
    }
}
