﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryItWeather.DistanceCalcService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceCalcService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DistanceCalculator", ReplyAction="http://tempuri.org/IService1/DistanceCalculatorResponse")]
        string[] DistanceCalculator(string source, string destination);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DistanceCalculator", ReplyAction="http://tempuri.org/IService1/DistanceCalculatorResponse")]
        System.Threading.Tasks.Task<string[]> DistanceCalculatorAsync(string source, string destination);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TryItWeather.DistanceCalcService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TryItWeather.DistanceCalcService.IService1>, TryItWeather.DistanceCalcService.IService1 {
        
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
        
        public string[] DistanceCalculator(string source, string destination) {
            return base.Channel.DistanceCalculator(source, destination);
        }
        
        public System.Threading.Tasks.Task<string[]> DistanceCalculatorAsync(string source, string destination) {
            return base.Channel.DistanceCalculatorAsync(source, destination);
        }
    }
}
