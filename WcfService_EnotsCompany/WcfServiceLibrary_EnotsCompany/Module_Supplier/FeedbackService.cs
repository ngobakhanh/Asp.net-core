using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FeedbackService" in both code and config file together.
    public class FeedbackService : IFeedbackService
    {
        B2BEntities ctx = new B2BEntities();
        public bool createFeedback(Feedback f)
        {
            Feedback _e = ctx.Feedbacks.Where(c => c.ID == f.ID).SingleOrDefault();
            if (_e != null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1002";
                myex.message = "ID is exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.Feedbacks.Add(f);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public bool deleteFeedback(int id)
        {
            Feedback _e = findFeedbackbyId(id);
            if (_e == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Feedback findFeedbackbyId(int id)
        {
            Feedback e = ctx.Feedbacks.Where(c => c.ID == id).SingleOrDefault();
            if (e == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return e;
            }
        }

        public List<Feedback> findFeedbackbyItemId(int Id)
        {
            List<Feedback> fb = ctx.Feedbacks.Include("Supplier").Include("Item").Include("Wholesaler").Where(c => c.ItemId == Id).ToList();
            if (fb == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return fb;
            }
        }

        public List<Feedback> findFeedbackbySalerId(string salerid)
        {
           
                List<Feedback> fb = ctx.Feedbacks.Include("Supplier").Include("Item").Include("Wholesaler").Where(c => c.WholesalerId == salerid).ToList();
            if (fb == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return fb;
            }
        }

        public List<Feedback> findFeedbackbySubject(string subject)
        {
            List<Feedback> fb = ctx.Feedbacks.Include("Supplier").Include("Item").Include("Wholesaler").Where(c => c.SubjectFB.Contains(subject)).ToList();
            if (fb == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return fb;
            }
        }

        public List<Feedback> findFeedbackbySupId(string supId)
        {
                List<Feedback> fb = ctx.Feedbacks.Include("Supplier").Include("Item").Include("Wholesaler").Where(c => c.WholesalerId == supId).OrderByDescending(f => f.ReceivedDate).ToList();
            if (fb == null)
            {
                throw new FaultException(new FaultReason("id not found"), FaultCode.CreateReceiverFaultCode(new FaultCode("1001")));
            }
            else
            {
                return fb;
            }
        }

        public List<Feedback> getAllFeedback()
        {
            List<Feedback> lst = ctx.Feedbacks.Include("Supplier").Include("Item").Include("Wholesaler").OrderByDescending(f=>f.ReceivedDate).ToList();
            if (lst.Count == 0)
            {
                throw new FaultException("Data not found!!!");
            }
            else
            {
                return lst;
            }
        }

        public bool updateFeedback(Feedback f)
        {
            Feedback fb = findFeedbackbyId(f.ID);
            if (fb == null)
            {
                My_Exception.MyFaultException myex = new My_Exception.MyFaultException();
                myex.errorCode = "1003";
                myex.message = "ID does not exist";

                throw new FaultException<My_Exception.MyFaultException>(myex);

            }
            else
            {
               
                fb.ID = f.ID;
                fb.ItemId = f.ItemId;
                fb.SubjectFB = f.SubjectFB;
                fb.SupplierId = f.SupplierId;
                fb.Message = f.Message;
                fb.ReceivedDate = f.ReceivedDate;
                fb.WholesalerId = f.WholesalerId;
                fb.ReplyId = f.ReplyId;
                ctx.SaveChanges();
                return true;
            }
                return false;
           
        }
    }
}
