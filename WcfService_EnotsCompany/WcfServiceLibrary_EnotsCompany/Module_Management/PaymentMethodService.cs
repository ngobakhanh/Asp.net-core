using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaymentMethodService" in both code and config file together.
    public class PaymentMethodService : IPaymentMethodService
    {
        B2BEntities ctx = new B2BEntities();

        public bool createPaymentMethod(PaymentMethod payMethod)
        {
            PaymentMethod _e = ctx.PaymentMethods.Where(c => c.PaymentMethodId == payMethod.PaymentMethodId).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.PaymentMethods.Add(payMethod);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deletePaymentMethod(int payId)
        {
            PaymentMethod _e = findPaymentMethodById(payId);
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.PaymentMethods.Remove(_e);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public PaymentMethod findPaymentMethodById(int payId)
        {
            PaymentMethod ee= ctx.PaymentMethods.Where(p => p.PaymentMethodId == payId).SingleOrDefault();
            if (ee == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return ee;
            }
        }

        public List<PaymentMethod> findPaymentMethodByName(string payName)
        {
            List<PaymentMethod> ee= ctx.PaymentMethods.Where(p => p.Name.Contains(payName)).ToList();
            if (ee == null)
            {
                throw new FaultException(new FaultReason("name not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return ee;
            }
        }

        public List<PaymentMethod> getAllPaymentMethod()
        {
            List<PaymentMethod> lst = ctx.PaymentMethods.ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updatePaymentMethod(PaymentMethod pay)
        {
            PaymentMethod p = findPaymentMethodById(pay.PaymentMethodId);
            if (p == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
               
                p.PaymentMethodId = pay.PaymentMethodId;
                p.Name = pay.Name;
                ctx.SaveChanges();
                return true;
            }
                return false;            
        }
    }
}
