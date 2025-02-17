using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class FigmaService
{
    private readonly HttpClient _httpClient;
    private readonly string _figmaToken = "figd_2nIxDgX4iRxyiIKMnpO1pAs5occXXy0vdzp3NsA1"; // Cambia por tu token de Figma
    private readonly string _fileId = "ew6P8nTdCPdhgHFjwKG2CY"; // Cambia por el ID de tu archivo Figma

    public FigmaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _figmaToken);
    }

    public async Task<string> GetFigmaDataAsync()
    {
        string url = $"https://api.figma.com/v1/files/{_fileId}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return $"Error al obtener datos: {response.StatusCode}";
    }
}
