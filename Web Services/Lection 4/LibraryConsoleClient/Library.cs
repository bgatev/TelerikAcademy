﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.6413
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ILibrary")]
public interface ILibrary
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILibrary/ContainsIn", ReplyAction="http://tempuri.org/ILibrary/ContainsInResponse")]
    int ContainsIn(string destination, string source);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ILibraryChannel : ILibrary, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class LibraryClient : System.ServiceModel.ClientBase<ILibrary>, ILibrary
{
    
    public LibraryClient()
    {
    }
    
    public LibraryClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LibraryClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LibraryClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LibraryClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int ContainsIn(string destination, string source)
    {
        return base.Channel.ContainsIn(destination, source);
    }
}