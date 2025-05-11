using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using AracKiralama.Models;
using System.Collections.Generic;

public class UserService
{
    private readonly HttpClient _httpClient;

    // Constructor, HttpClient'� enjekte eder.
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAppUserAsync(AppUser appUser)
    {
        try
        {
            // RentOfficeId'yi do�ru formatta (Guid) g�nderdi�inizden emin olun
            appUser.RentOfficeId = Guid.Parse("f8c0852a-3d4c-4b70-de53-670a4a33a58e"); // Ge�erli bir GUID �rne�i
                                                                                       // RentOfficeId �rne�i

            // G�nderilen JSON verisini kontrol etmek i�in ekleyebilirsiniz
            var jsonContent = JsonSerializer.Serialize(appUser);
            Console.WriteLine($"G�nderilen JSON: {jsonContent}");  // Ekrana yazd�r�n

            // API'ye POST iste�i g�nderiyoruz
            var response = await _httpClient.PostAsJsonAsync("http://84.247.20.87:32793/api/AppUser", appUser);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorResponse}");
                throw new HttpRequestException("API istek hatas�: " + errorResponse);
            }

            Console.WriteLine("Kullan�c� ba�ar�yla kaydedildi.");
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
                throw new HttpRequestException("API istek hatas�: " + errorResponse);
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
