using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfServiceLibrary_EnotsCompany.My_Exception
{
    [DataContract]
    class MyFaultException
    {
        [DataMember]
        public string message;

        [DataMember]
        public string errorCode;

    }
}
