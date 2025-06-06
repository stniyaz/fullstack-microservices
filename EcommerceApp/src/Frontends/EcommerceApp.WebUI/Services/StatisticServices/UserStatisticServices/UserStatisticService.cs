
using Newtonsoft.Json;

namespace EcommerceApp.WebUI.Services.StatisticServices.UserStatisticServices;

public class UserStatisticService(HttpClient _httpClient) : IUserStatisticService
{
    public async Task<int> GetUserCountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("http://localhost:5001/Api/Statistics/GetUserCount");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<int>(jsonData);
        return value;
    }
}
