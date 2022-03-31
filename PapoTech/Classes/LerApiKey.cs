using Newtonsoft.Json;

namespace PapoTech.Classes
{
    public static class LerApiKey
    {       
        public static string LerArquivoJson(string arquivo)
        {
            using (StreamReader LerJson = new StreamReader(arquivo))
            {
                string json = LerJson.ReadToEnd();
                ApiKeyModel Key = JsonConvert.DeserializeObject<ApiKeyModel>(json);
                return Key.RetornaKey().ToString();
            }
        }
    }
}
