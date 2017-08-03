using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace WcfServiceLibrary_EnotsCompany.Module_RSS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRSSService" in both code and config file together.
    [ServiceContract]
    public interface IRSSService
    {
        [OperationContract]
        [WebGet]
        Rss20FeedFormatter ViewProducts();
    }
}
