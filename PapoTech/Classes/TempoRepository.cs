using PapoTech.Interfaces;

namespace PapoTech.Classes
{
    internal class TempoRepository : IRepositoryApiTempo
    {
        static readonly HttpClient client = new();
        string ArquivoJson = @"C:\Users\Matheus\OneDrive\Documentos\KeyApiWheather.json";
        
        
        public  async Task<string> GetApi(string Cidade, string Estado, string Pais)
        {       
                try
                {
                    string ApiKey = LerApiKey.LerArquivoJson(ArquivoJson);
                    HttpResponseMessage response = await client.GetAsync(string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},{1},{2}&appid={3}&units=metric&lang=pt_br", Cidade, Estado, Pais, ApiKey).Trim());
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                    }                    
                    return "erro";
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Message :{0} ", e.Message);
                    return e.Message;
                }
            
        }
    }
}
