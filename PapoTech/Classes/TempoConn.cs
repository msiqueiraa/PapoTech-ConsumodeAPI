using PapoTech.Interfaces;

namespace PapoTech.Classes
{
    internal class TempoConn : IRepositoryApi
    {
        static readonly HttpClient client = new();
        string ArquivoJson = @"C:\Users\Matheus\OneDrive\Documentos\KeyApiWheather.json";
        
        
        public  async Task<string> GetApi(string Cidade)
        {       
                try
                {
                    string ApiKey = LerApiKey.LerArquivoJson(ArquivoJson);
                    HttpResponseMessage response = await client.GetAsync(string.Format("https://api.openweathermap.org/data/2.5/weather?q={0},&appid={1}&units=metric&lang=pt_br", Cidade, ApiKey).Trim());
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    return "erro";
                }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Message :{0} ", e.Message);
                    return e.Message;
                }
            
        }
    }
}
