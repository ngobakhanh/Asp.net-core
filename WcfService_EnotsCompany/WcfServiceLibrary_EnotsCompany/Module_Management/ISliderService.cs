using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISliderService" in both code and config file together.
    [ServiceContract]
    public interface ISliderService
    {
        [OperationContract]
        List<Slider> getAllSlider();
        [OperationContract]
        Slider findSliderById(int sliderId);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createSlider(Slider slider);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateSlider(Slider slider);


        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteSlider(int sliderId);
    }
}
