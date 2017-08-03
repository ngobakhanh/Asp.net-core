﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference_Item
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Item", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Item : object
    {
        
        private System.DateTime AddedDateField;
        
        private ServiceReference_Item.Category CategoryField;
        
        private int CategoryIdField;
        
        private string DescriptionItemField;
        
        private System.Nullable<double> DiscountField;
        
        private string FAQField;
        
        private string ImageItemField;
        
        private int ItemIdField;
        
        private string ItemNameField;
        
        private int MinQuantityField;
        
        private string MoreImageField;
        
        private string NoteField;
        
        private System.Nullable<int> ParentItemField;
        
        private string PriceField;
        
        private System.Nullable<int> QuantityField;
        
        private string ShippingFeeField;
        
        private string StatusItemField;
        
        private ServiceReference_Item.Supplier SupplierField;
        
        private string SupplierIdField;
        
        private ServiceReference_Item.Unit UnitField;
        
        private int UnitIdField;
        
        private string UnitpriceField;
        
        private string WarrantyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime AddedDate
        {
            get
            {
                return this.AddedDateField;
            }
            set
            {
                this.AddedDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference_Item.Category Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                this.CategoryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId
        {
            get
            {
                return this.CategoryIdField;
            }
            set
            {
                this.CategoryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DescriptionItem
        {
            get
            {
                return this.DescriptionItemField;
            }
            set
            {
                this.DescriptionItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> Discount
        {
            get
            {
                return this.DiscountField;
            }
            set
            {
                this.DiscountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FAQ
        {
            get
            {
                return this.FAQField;
            }
            set
            {
                this.FAQField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageItem
        {
            get
            {
                return this.ImageItemField;
            }
            set
            {
                this.ImageItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemId
        {
            get
            {
                return this.ItemIdField;
            }
            set
            {
                this.ItemIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ItemName
        {
            get
            {
                return this.ItemNameField;
            }
            set
            {
                this.ItemNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinQuantity
        {
            get
            {
                return this.MinQuantityField;
            }
            set
            {
                this.MinQuantityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MoreImage
        {
            get
            {
                return this.MoreImageField;
            }
            set
            {
                this.MoreImageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Note
        {
            get
            {
                return this.NoteField;
            }
            set
            {
                this.NoteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ParentItem
        {
            get
            {
                return this.ParentItemField;
            }
            set
            {
                this.ParentItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Quantity
        {
            get
            {
                return this.QuantityField;
            }
            set
            {
                this.QuantityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShippingFee
        {
            get
            {
                return this.ShippingFeeField;
            }
            set
            {
                this.ShippingFeeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusItem
        {
            get
            {
                return this.StatusItemField;
            }
            set
            {
                this.StatusItemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference_Item.Supplier Supplier
        {
            get
            {
                return this.SupplierField;
            }
            set
            {
                this.SupplierField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SupplierId
        {
            get
            {
                return this.SupplierIdField;
            }
            set
            {
                this.SupplierIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference_Item.Unit Unit
        {
            get
            {
                return this.UnitField;
            }
            set
            {
                this.UnitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UnitId
        {
            get
            {
                return this.UnitIdField;
            }
            set
            {
                this.UnitIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Unitprice
        {
            get
            {
                return this.UnitpriceField;
            }
            set
            {
                this.UnitpriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Warranty
        {
            get
            {
                return this.WarrantyField;
            }
            set
            {
                this.WarrantyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Category : object
    {
        
        private int CategoryIdField;
        
        private string CategoryNameField;
        
        private string ImageCateField;
        
        private System.Nullable<int> ParentIdField;
        
        private string StatusCateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryId
        {
            get
            {
                return this.CategoryIdField;
            }
            set
            {
                this.CategoryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName
        {
            get
            {
                return this.CategoryNameField;
            }
            set
            {
                this.CategoryNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageCate
        {
            get
            {
                return this.ImageCateField;
            }
            set
            {
                this.ImageCateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ParentId
        {
            get
            {
                return this.ParentIdField;
            }
            set
            {
                this.ParentIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCate
        {
            get
            {
                return this.StatusCateField;
            }
            set
            {
                this.StatusCateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Supplier", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Supplier : object
    {
        
        private string AddressField;
        
        private string AvatarField;
        
        private string BussinessTypeField;
        
        private System.Nullable<int> CategoryIdField;
        
        private string CompanyNameField;
        
        private string CountryField;
        
        private ServiceReference_Item.Country Country1Field;
        
        private System.Nullable<int> CountryIdField;
        
        private string EmailField;
        
        private string MainProductField;
        
        private string NameField;
        
        private string PhoneField;
        
        private string ProvinceField;
        
        private string StatusField;
        
        private string SupplierIdField;
        
        private string TitleField;
        
        private string TotalEmployeesField;
        
        private string WebsiteField;
        
        private System.Nullable<System.DateTime> YearEstablishedField;
        
        private System.Nullable<int> ZipcodeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address
        {
            get
            {
                return this.AddressField;
            }
            set
            {
                this.AddressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Avatar
        {
            get
            {
                return this.AvatarField;
            }
            set
            {
                this.AvatarField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BussinessType
        {
            get
            {
                return this.BussinessTypeField;
            }
            set
            {
                this.BussinessTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> CategoryId
        {
            get
            {
                return this.CategoryIdField;
            }
            set
            {
                this.CategoryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompanyName
        {
            get
            {
                return this.CompanyNameField;
            }
            set
            {
                this.CompanyNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Country
        {
            get
            {
                return this.CountryField;
            }
            set
            {
                this.CountryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference_Item.Country Country1
        {
            get
            {
                return this.Country1Field;
            }
            set
            {
                this.Country1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> CountryId
        {
            get
            {
                return this.CountryIdField;
            }
            set
            {
                this.CountryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MainProduct
        {
            get
            {
                return this.MainProductField;
            }
            set
            {
                this.MainProductField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                this.PhoneField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Province
        {
            get
            {
                return this.ProvinceField;
            }
            set
            {
                this.ProvinceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SupplierId
        {
            get
            {
                return this.SupplierIdField;
            }
            set
            {
                this.SupplierIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TotalEmployees
        {
            get
            {
                return this.TotalEmployeesField;
            }
            set
            {
                this.TotalEmployeesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Website
        {
            get
            {
                return this.WebsiteField;
            }
            set
            {
                this.WebsiteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> YearEstablished
        {
            get
            {
                return this.YearEstablishedField;
            }
            set
            {
                this.YearEstablishedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Zipcode
        {
            get
            {
                return this.ZipcodeField;
            }
            set
            {
                this.ZipcodeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Unit", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Unit : object
    {
        
        private int UnitIdField;
        
        private string UnitNameField;
        
        private string UnitStatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UnitId
        {
            get
            {
                return this.UnitIdField;
            }
            set
            {
                this.UnitIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitName
        {
            get
            {
                return this.UnitNameField;
            }
            set
            {
                this.UnitNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UnitStatus
        {
            get
            {
                return this.UnitStatusField;
            }
            set
            {
                this.UnitStatusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Country", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Country : object
    {
        
        private string CommonNameField;
        
        private string CountryCodeField;
        
        private int CountryIdField;
        
        private string StatusCountryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CommonName
        {
            get
            {
                return this.CommonNameField;
            }
            set
            {
                this.CommonNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryCode
        {
            get
            {
                return this.CountryCodeField;
            }
            set
            {
                this.CountryCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CountryId
        {
            get
            {
                return this.CountryIdField;
            }
            set
            {
                this.CountryIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCountry
        {
            get
            {
                return this.StatusCountryField;
            }
            set
            {
                this.StatusCountryField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
        "on")]
    public partial class MyFaultException : object
    {
        
        private string errorCodeField;
        
        private string messageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string errorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference_Item.IItemService")]
    public interface IItemService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/getAllItem", ReplyAction="http://tempuri.org/IItemService/getAllItemResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> getAllItemAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/sortItembyNameAZ", ReplyAction="http://tempuri.org/IItemService/sortItembyNameAZResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> sortItembyNameAZAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/sortItembyNameZA", ReplyAction="http://tempuri.org/IItemService/sortItembyNameZAResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> sortItembyNameZAAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/findItembyId", ReplyAction="http://tempuri.org/IItemService/findItembyIdResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item> findItembyIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/findItembyName", ReplyAction="http://tempuri.org/IItemService/findItembyNameResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembyNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/findItembySupId", ReplyAction="http://tempuri.org/IItemService/findItembySupIdResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembySupIdAsync(string supId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/findItembyCategoryId", ReplyAction="http://tempuri.org/IItemService/findItembyCategoryIdResponse")]
        System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembyCategoryIdAsync(int categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/createItem", ReplyAction="http://tempuri.org/IItemService/createItemResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Item.MyFaultException), Action="http://tempuri.org/IItemService/createItemMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> createItemAsync(ServiceReference_Item.Item i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/updateItem", ReplyAction="http://tempuri.org/IItemService/updateItemResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Item.MyFaultException), Action="http://tempuri.org/IItemService/updateItemMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> updateItemAsync(ServiceReference_Item.Item i);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IItemService/deleteItem", ReplyAction="http://tempuri.org/IItemService/deleteItemResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Item.MyFaultException), Action="http://tempuri.org/IItemService/deleteItemMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> deleteItemAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public interface IItemServiceChannel : ServiceReference_Item.IItemService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public partial class ItemServiceClient : System.ServiceModel.ClientBase<ServiceReference_Item.IItemService>, ServiceReference_Item.IItemService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ItemServiceClient() : 
                base(ItemServiceClient.GetDefaultBinding(), ItemServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IItemService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ItemServiceClient.GetBindingForEndpoint(endpointConfiguration), ItemServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ItemServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ItemServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ItemServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> getAllItemAsync()
        {
            return base.Channel.getAllItemAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> sortItembyNameAZAsync()
        {
            return base.Channel.sortItembyNameAZAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> sortItembyNameZAAsync()
        {
            return base.Channel.sortItembyNameZAAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item> findItembyIdAsync(int id)
        {
            return base.Channel.findItembyIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembyNameAsync(string name)
        {
            return base.Channel.findItembyNameAsync(name);
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembySupIdAsync(string supId)
        {
            return base.Channel.findItembySupIdAsync(supId);
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Item.Item[]> findItembyCategoryIdAsync(int categoryId)
        {
            return base.Channel.findItembyCategoryIdAsync(categoryId);
        }
        
        public System.Threading.Tasks.Task<bool> createItemAsync(ServiceReference_Item.Item i)
        {
            return base.Channel.createItemAsync(i);
        }
        
        public System.Threading.Tasks.Task<bool> updateItemAsync(ServiceReference_Item.Item i)
        {
            return base.Channel.updateItemAsync(i);
        }
        
        public System.Threading.Tasks.Task<bool> deleteItemAsync(int id)
        {
            return base.Channel.deleteItemAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IItemService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IItemService))
            {
                return new System.ServiceModel.EndpointAddress("http://10.107.14.95/IISHosting/EnotsCompany/ItemService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ItemServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IItemService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ItemServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IItemService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IItemService,
        }
    }
}
