using PapoTech.Interfaces;


namespace PapoTech.Classes
{
    public class ViaCepApiConn: IRepositoryApi
    {
        static readonly HttpClient client = new();           
       public async Task<String> GetApi(string Cep)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/",Cep).Trim());
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
    

