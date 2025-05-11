using AracKiralama.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AppUserService
{
    private readonly HttpClient _httpClient;

    public AppUserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://84.247.20.87:32793/");  // API'nin temel adresini belirtiyoruz
    }

    // Yeni bir kullanýcý kaydetme
    public async Task CreateAppUserAsync(AppUser appUser)
    {
        var response = await _httpClient.PostAsJsonAsync("api/AppUser", appUser);  // API endpoint'i
        response.EnsureSuccessStatusCode();  // Baþarý kontrolü
    }

    // Tüm kullanýcýlarý listeleme
    public async Task<List<AppUser>> GetAppUsersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<AppUser>>("api/AppUser");
        return response;
    }
}
