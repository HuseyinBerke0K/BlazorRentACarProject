using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using AracKiralama.Models;
using System.Collections.Generic;

public class UserService
{
    private readonly HttpClient _httpClient;

    // Constructor, HttpClient'ý enjekte eder.
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAppUserAsync(AppUser appUser)
    {
        try
        {
            // RentOfficeId'yi doðru formatta (Guid) gönderdiðinizden emin olun
            appUser.RentOfficeId = Guid.Parse("f8c0852a-3d4c-4b70-de53-670a4a33a58e"); // Geçerli bir GUID örneði
                                                                                       // RentOfficeId örneði

            // Gönderilen JSON verisini kontrol etmek için ekleyebilirsiniz
            var jsonContent = JsonSerializer.Serialize(appUser);
            Console.WriteLine($"Gönderilen JSON: {jsonContent}");  // Ekrana yazdýrýn

            // API'ye POST isteði gönderiyoruz
            var response = await _httpClient.PostAsJsonAsync("http://84.247.20.87:32793/api/AppUser", appUser);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorResponse}");
                throw new HttpRequestException("API istek hatasý: " + errorResponse);
            }

            Console.WriteLine("Kullanýcý baþarýyla kaydedildi.");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Hata: {ex.Message}");
        }
    }

    public async Task<List<RentOffice>> GetRentOfficesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("http://84.247.20.87:32793/api/RentOffice");

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorResponse}");
                throw new HttpRequestException("API istek hatasý: " + errorResponse);
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RentOffice>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<RentOffice>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API Hata: {ex.Message}");
            return new List<RentOffice>();
        }
    }
}
