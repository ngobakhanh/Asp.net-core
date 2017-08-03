using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        
        B2BEntities ctx = new B2BEntities();

        public bool createEmployee(Employee e)
        {
            Employee _e = ctx.Employees.Where(c => c.EmployeeId == e.EmployeeId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Employees.Add(e);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteEmployee(int id)
        {
            Employee _e = ctx.Employees.Where(c => c.EmployeeId == id).SingleOrDefault();
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                _e.StatusEmp = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Employee findEmployeebyId(int id)
        {
            Employee e = ctx.Employees.Where(c => c.EmployeeId == id).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Employee> findEmployeebyName(string name)
        {
            List<Employee> ee = ctx.Employees.Where(c => c.Fullname.Contains(name)).ToList();
            if (ee == null)
            {
                throw new FaultException(new FaultReason("name not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return ee;
            }
        }

        public List<Employee> getAllEmployee()
        {
            List<Employee> lst = ctx.Employees.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateEmployee(Employee e)
        {
            Employee ee = ctx.Employees.Where(c => c.EmployeeId == e.EmployeeId).SingleOrDefault();
            if (ee == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            { 
               
                ee.EmployeeId = e.EmployeeId;
                ee.Fullname = e.Fullname;
                ee.Email = e.Email;
                ee.AddressEmp = e.AddressEmp;
                ee.Phone = e.Phone;
                ee.StatusEmp = e.StatusEmp;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
