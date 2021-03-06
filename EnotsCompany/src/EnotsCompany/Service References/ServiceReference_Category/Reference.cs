﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference_Category
{
    using System.Runtime.Serialization;
    
    
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference_Category.ICategoryService")]
    public interface ICategoryService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/getAllCategory", ReplyAction="http://tempuri.org/ICategoryService/getAllCategoryResponse")]
        System.Threading.Tasks.Task<ServiceReference_Category.Category[]> getAllCategoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/findCategorybyId", ReplyAction="http://tempuri.org/ICategoryService/findCategorybyIdResponse")]
        System.Threading.Tasks.Task<ServiceReference_Category.Category> findCategorybyIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/findCategorybyName", ReplyAction="http://tempuri.org/ICategoryService/findCategorybyNameResponse")]
        System.Threading.Tasks.Task<ServiceReference_Category.Category[]> findCategorybyNameAsync(string nameCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/createCategory", ReplyAction="http://tempuri.org/ICategoryService/createCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Category.MyFaultException), Action="http://tempuri.org/ICategoryService/createCategoryMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> createCategoryAsync(ServiceReference_Category.Category c);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/updateCategory", ReplyAction="http://tempuri.org/ICategoryService/updateCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Category.MyFaultException), Action="http://tempuri.org/ICategoryService/updateCategoryMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> updateCategoryAsync(ServiceReference_Category.Category c);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategoryService/deleteCategory", ReplyAction="http://tempuri.org/ICategoryService/deleteCategoryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Category.MyFaultException), Action="http://tempuri.org/ICategoryService/deleteCategoryMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> deleteCategoryAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public interface ICategoryServiceChannel : ServiceReference_Category.ICategoryService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public partial class CategoryServiceClient : System.ServiceModel.ClientBase<ServiceReference_Category.ICategoryService>, ServiceReference_Category.ICategoryService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CategoryServiceClient() : 
                base(CategoryServiceClient.GetDefaultBinding(), CategoryServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICategoryService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategoryServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CategoryServiceClient.GetBindingForEndpoint(endpointConfiguration), CategoryServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategoryServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CategoryServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategoryServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CategoryServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Category.Category[]> getAllCategoryAsync()
        {
            return base.Channel.getAllCategoryAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Category.Category> findCategorybyIdAsync(int id)
        {
            return base.Channel.findCategorybyIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Category.Category[]> findCategorybyNameAsync(string nameCategory)
        {
            return base.Channel.findCategorybyNameAsync(nameCategory);
        }
        
        public System.Threading.Tasks.Task<bool> createCategoryAsync(ServiceReference_Category.Category c)
        {
            return base.Channel.createCategoryAsync(c);
        }
        
        public System.Threading.Tasks.Task<bool> updateCategoryAsync(ServiceReference_Category.Category c)
        {
            return base.Channel.updateCategoryAsync(c);
        }
        
        public System.Threading.Tasks.Task<bool> deleteCategoryAsync(int id)
        {
            return base.Channel.deleteCategoryAsync(id);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategoryService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategoryService))
            {
                return new System.ServiceModel.EndpointAddress("http://10.107.14.95/IISHosting/EnotsCompany/CategoryService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CategoryServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICategoryService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CategoryServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICategoryService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ICategoryService,
        }
    }
}
