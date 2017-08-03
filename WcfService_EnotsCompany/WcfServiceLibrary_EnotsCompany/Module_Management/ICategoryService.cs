using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICategoryService" in both code and config file together.
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        List<Category> getAllCategory();
     
        [OperationContract]
        Category findCategorybyId(int id);

        [OperationContract]
        List<Category> findCategorybyName(string nameCategory);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createCategory(Category c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateCategory(Category c);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteCategory(int id);
    }
}
