using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeedbackService" in both code and config file together.
    [ServiceContract]
    public interface IFeedbackService
    {
        [OperationContract]
        List<Feedback> getAllFeedback();

        [OperationContract]
        Feedback findFeedbackbyId(int id);

        [OperationContract]
        List<Feedback> findFeedbackbySubject(string subject);

        [OperationContract]
        List<Feedback> findFeedbackbySalerId(string salerid);

        [OperationContract]
        List<Feedback> findFeedbackbySupId(string supId);

        [OperationContract]
        List<Feedback> findFeedbackbyItemId(int Id);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]

        bool createFeedback(Feedback f);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]

        bool updateFeedback(Feedback f);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]

        bool deleteFeedback(int id);
    }
}
