﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DayOfTheWeekConsoleClient.DayOfTheWeek {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DayOfTheWeek.IDayOfTheWeek")]
    public interface IDayOfTheWeek {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfTheWeek/GetWeekDay", ReplyAction="http://tempuri.org/IDayOfTheWeek/GetWeekDayResponse")]
        string GetWeekDay(System.DateTime inputDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfTheWeek/GetWeekDay", ReplyAction="http://tempuri.org/IDayOfTheWeek/GetWeekDayResponse")]
        System.Threading.Tasks.Task<string> GetWeekDayAsync(System.DateTime inputDate);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDayOfTheWeekChannel : DayOfTheWeekConsoleClient.DayOfTheWeek.IDayOfTheWeek, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DayOfTheWeekClient : System.ServiceModel.ClientBase<DayOfTheWeekConsoleClient.DayOfTheWeek.IDayOfTheWeek>, DayOfTheWeekConsoleClient.DayOfTheWeek.IDayOfTheWeek {
        
        public DayOfTheWeekClient() {
        }
        
        public DayOfTheWeekClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DayOfTheWeekClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfTheWeekClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfTheWeekClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetWeekDay(System.DateTime inputDate) {
            return base.Channel.GetWeekDay(inputDate);
        }
        
        public System.Threading.Tasks.Task<string> GetWeekDayAsync(System.DateTime inputDate) {
            return base.Channel.GetWeekDayAsync(inputDate);
        }
    }
}