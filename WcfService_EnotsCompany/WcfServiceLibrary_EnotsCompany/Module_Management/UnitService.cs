using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UnitService" in both code and config file together.
    public class UnitService : IUnitService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createUnit(Unit unit)
        {
            Unit _e = ctx.Units.Where(c => c.UnitId == unit.UnitId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Units.Add(unit);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteUnit(int unitId)
        {
            Unit u = findUnitById(unitId);
            if (u == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                u.UnitStatus = "Disable";
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Unit findUnitById(int unitId)
        {
            Unit e = ctx.Units.Where(c => c.UnitId ==unitId).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Unit> getAllUnit()
        {
            List<Unit> lst = ctx.Units.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateUnit(Unit unit)
        {
            Unit u = findUnitById(unit.UnitId);
            if (u == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {                
                u.UnitId = unit.UnitId;
                u.UnitName = unit.UnitName;
                u.UnitStatus = unit.UnitStatus;
                ctx.SaveChanges();
                return true;
            }
                return false;            
        }
    }
}
