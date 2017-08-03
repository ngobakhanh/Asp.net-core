using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary_EnotsCompany.DAL;
using System.Transactions;

namespace WcfServiceLibrary_EnotsCompany
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        List<Item> getAllItem();

        [OperationContract]
        List<Item> sortItembyNameAZ();

        [OperationContract]
        List<Item> sortItembyNameZA();

        
        [OperationContract]
        Item findItembyId(int id);

        [OperationContract]
        List<Item> findItembyName(string name);

        [OperationContract]
        List<Item> findItembySupId(string supId);

        [OperationContract]
        List<Item> findItembyCategoryId(int categoryId);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool createItem(Item i);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool updateItem(Item i);

        [OperationContract]
        [FaultContract(typeof(My_Exception.MyFaultException))]
        bool deleteItem(int id);

    }
}
