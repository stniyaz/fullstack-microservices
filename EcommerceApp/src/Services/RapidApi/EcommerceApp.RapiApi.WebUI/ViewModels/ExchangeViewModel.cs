namespace EcommerceApp.RapiApi.WebUI.ViewModels;

public class ExchangeViewModel
{

    public class Rootobject
    {
        public bool success { get; set; }
        public long timestamp { get; set; }
        public string date { get; set; }
        public string _base { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public float AZN { get; set; }
    }

}
