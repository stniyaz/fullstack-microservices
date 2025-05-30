namespace EcommerceApp.WebUI.Settings
{
    public class ClientSettings
    {
        public Client EcommerceAppVisitorId { get; set; }
        public Client EcommerceAppManagerId { get; set; }
        public Client EcommerceAppAdminId { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
