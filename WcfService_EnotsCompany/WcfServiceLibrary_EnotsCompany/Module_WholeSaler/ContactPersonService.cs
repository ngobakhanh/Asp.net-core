using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContactPersonService" in both code and config file together.
    public class ContactPersonService : IContactPersonService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createContactPerson(ContactPerson cp)
        {
            ContactPerson _e = ctx.ContactPersons.Where(c => c.ContactPersonId == cp.ContactPersonId).SingleOrDefault();

            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.ContactPersons.Add(cp);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteContactPerson(int id)
        {
            ContactPerson itemp = findContactPersonbyId(id);
            if (itemp == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                itemp.StatusCP = "Disable";
                 ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public ContactPerson findContactPersonbyId(int id)
        {
            ContactPerson cp = ctx.ContactPersons.Where(c => c.ContactPersonId == id).SingleOrDefault();
            if (cp == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cp;
            }
        }

        public List<ContactPerson> findContactPersonbyName(string nameContact)
        {
            List<ContactPerson> cp = ctx.ContactPersons.Where(c => c.Fullname.Contains(nameContact)).ToList();
            if (cp == null)
            {
                throw new FaultException(new FaultReason("Data not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cp;
            }
        }

        public ContactPerson findContactPersonbySalerId(string id)
        {

            ContactPerson cp = ctx.ContactPersons.Where(c => c.WholesalerId == id).SingleOrDefault();
            if (cp == null)
            {
                throw new FaultException(new FaultReason("Data not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cp;
            }
        }

        public List<ContactPerson> getAllContactPerson()
        {
            List<ContactPerson>cp= ctx.ContactPersons.ToList();
            if (cp == null)
            {
                throw new FaultException(new FaultReason("Data not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return cp;
            }
        }

        public bool updateContactPerson(ContactPerson c)
        {
            ContactPerson cp = findContactPersonbyId(c.ContactPersonId);

            if (cp == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                cp.ContactPersonId = c.ContactPersonId;
                cp.Fullname = c.Fullname;
                cp.Phone = c.Phone;
                cp.WholesalerId = c.WholesalerId;
                cp.Email = c.Email;
                cp.StatusCP = c.StatusCP;

                ctx.SaveChanges();
                return true;
            }
                return false;
        }
    }
}
