using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> getAllEmployee();

        [OperationContract]
        Employee findEmployeebyId(int id);

        [OperationContract]
        List<Employee> findEmployeebyName(string name);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createEmployee(Employee e);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateEmployee(Employee e);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteEmployee(int id);
    }
}
