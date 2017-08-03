﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference_Slider
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Slider", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.DAL")]
    public partial class Slider : object
    {
        
        private string ImageSliderField;
        
        private System.Nullable<bool> IsActiveField;
        
        private int SliderIdField;
        
        private string URLField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageSlider
        {
            get
            {
                return this.ImageSliderField;
            }
            set
            {
                this.ImageSliderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsActive
        {
            get
            {
                return this.IsActiveField;
            }
            set
            {
                this.IsActiveField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SliderId
        {
            get
            {
                return this.SliderIdField;
            }
            set
            {
                this.SliderIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string URL
        {
            get
            {
                return this.URLField;
            }
            set
            {
                this.URLField = value;
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference_Slider.ISliderService")]
    public interface ISliderService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISliderService/getAllSlider", ReplyAction="http://tempuri.org/ISliderService/getAllSliderResponse")]
        System.Threading.Tasks.Task<ServiceReference_Slider.Slider[]> getAllSliderAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISliderService/findSliderById", ReplyAction="http://tempuri.org/ISliderService/findSliderByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference_Slider.Slider> findSliderByIdAsync(int sliderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISliderService/createSlider", ReplyAction="http://tempuri.org/ISliderService/createSliderResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Slider.MyFaultException), Action="http://tempuri.org/ISliderService/createSliderMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> createSliderAsync(ServiceReference_Slider.Slider slider);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISliderService/updateSlider", ReplyAction="http://tempuri.org/ISliderService/updateSliderResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Slider.MyFaultException), Action="http://tempuri.org/ISliderService/updateSliderMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> updateSliderAsync(ServiceReference_Slider.Slider slider);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISliderService/deleteSlider", ReplyAction="http://tempuri.org/ISliderService/deleteSliderResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ServiceReference_Slider.MyFaultException), Action="http://tempuri.org/ISliderService/deleteSliderMyFaultExceptionFault", Name="MyFaultException", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary_EnotsCompany.My_Excepti" +
            "on")]
        System.Threading.Tasks.Task<bool> deleteSliderAsync(int sliderId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public interface ISliderServiceChannel : ServiceReference_Slider.ISliderService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.4.0.0")]
    public partial class SliderServiceClient : System.ServiceModel.ClientBase<ServiceReference_Slider.ISliderService>, ServiceReference_Slider.ISliderService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SliderServiceClient() : 
                base(SliderServiceClient.GetDefaultBinding(), SliderServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ISliderService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SliderServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SliderServiceClient.GetBindingForEndpoint(endpointConfiguration), SliderServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SliderServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SliderServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SliderServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SliderServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SliderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Slider.Slider[]> getAllSliderAsync()
        {
            return base.Channel.getAllSliderAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference_Slider.Slider> findSliderByIdAsync(int sliderId)
        {
            return base.Channel.findSliderByIdAsync(sliderId);
        }
        
        public System.Threading.Tasks.Task<bool> createSliderAsync(ServiceReference_Slider.Slider slider)
        {
            return base.Channel.createSliderAsync(slider);
        }
        
        public System.Threading.Tasks.Task<bool> updateSliderAsync(ServiceReference_Slider.Slider slider)
        {
            return base.Channel.updateSliderAsync(slider);
        }
        
        public System.Threading.Tasks.Task<bool> deleteSliderAsync(int sliderId)
        {
            return base.Channel.deleteSliderAsync(sliderId);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISliderService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISliderService))
            {
                return new System.ServiceModel.EndpointAddress("http://10.107.14.95/IISHosting/EnotsCompany/SliderService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SliderServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ISliderService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SliderServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ISliderService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ISliderService,
        }
    }
}
