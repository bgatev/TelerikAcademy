namespace App.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    using App.Models;

    [ServiceContract]
    public interface IUsers
    {

        [OperationContract]
        [WebGet(UriTemplate = "")]
        ICollection<User> GetUsers();

        [OperationContract]
        ICollection<User> GetUsersPaged(int page);

        [OperationContract]
        WCFUser GetUserDetailsById(string id);
    }

    [DataContract]
    public class WCFUser
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Losses { get; set; }

        [DataMember]
        public int Rank { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public int Wins { get; set; }
    }
}
