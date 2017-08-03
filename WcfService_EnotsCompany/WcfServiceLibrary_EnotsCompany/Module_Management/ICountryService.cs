using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICountryService" in both code and config file together.
    [ServiceContract]
    public interface ICountryService
    {
        [OperationContract]
        List<Country> getAllCountry();

        [OperationContract]
        Country findCountrybyId(int id);

        [OperationContract]
        Country findCountrybyCode(string code);

        [OperationContract]
        List<Country> findCountrybyName(string nameCountry);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createCountry(Country c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateCountry(Country c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteCountry(int id);
    }
}
