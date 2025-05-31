namespace EcommerceApp.WebUI.Settings
{
    public class ClientSettings
    {
        public Client EcommerceAppVisitorClient { get; set; }
        public Client EcommerceAppManagerClient { get; set; }
        public Client EcommerceAppAdminClient { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
