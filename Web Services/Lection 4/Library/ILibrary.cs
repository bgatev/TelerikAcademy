namespace Library
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        int ContainsIn(string destination, string source);
    }
}
