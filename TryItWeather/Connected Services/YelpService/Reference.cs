﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryItWeather.YelpService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="YelpService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/YelpStoreFinder", ReplyAction="http://tempuri.org/IService1/YelpStoreFinderResponse")]
        string YelpStoreFinder(string PlaceName, string location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/YelpStoreFinder", ReplyAction="http://tempuri.org/IService1/YelpStoreFinderResponse")]
        System.Threading.Tasks.Task<string> YelpStoreFinderAsync(string PlaceName, string location);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryItWeather.YelpService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryItWeather.YelpService.IService1>, TryItWeather.YelpService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string YelpStoreFinder(string PlaceName, string location) {
            return base.Channel.YelpStoreFinder(PlaceName, location);
        }
        
        public System.Threading.Tasks.Task<string> YelpStoreFinderAsync(string PlaceName, string location) {
            return base.Channel.YelpStoreFinderAsync(PlaceName, location);
        }
    }
}
