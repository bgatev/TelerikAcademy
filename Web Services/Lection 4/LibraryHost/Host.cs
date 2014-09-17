namespace LibraryHost
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    public class Host
    {
        public static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:53336/Library");
            ServiceHost selfHost = new ServiceHost(typeof(Library.Library), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                Console.WriteLine("The service is started at endpoint " + serviceAddress);

                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
