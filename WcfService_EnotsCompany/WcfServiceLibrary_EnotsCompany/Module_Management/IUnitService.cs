using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUnitService" in both code and config file together.
    [ServiceContract]
    public interface IUnitService
    {
        [OperationContract]
        List<Unit> getAllUnit();
        [OperationContract]
        Unit findUnitById(int unitId);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createUnit(Unit unit);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateUnit(Unit unit);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteUnit(int unitId);
    } 
}
