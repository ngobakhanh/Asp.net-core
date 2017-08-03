using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IArticleService" in both code and config file together.
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        List<Article> getAllArticle();

        [OperationContract]
        List<Article> findArticlebyDate(DateTime date);

        [OperationContract]
        Article findArticlebyID(int id);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createArticle(Article a);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateArticle(Article a);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteArticle(int id);
    }
}
