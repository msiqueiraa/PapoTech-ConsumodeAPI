using Newtonsoft.Json;


namespace PapoTech.Classes
{
    internal class ResponseViaCep
    {
        [JsonProperty(PropertyName = "cep")]
        private string Cep { get ; set ; }

        [JsonProperty(PropertyName = "logradouro")]
        private string Logradouro { get ; set ; }

        [JsonProperty(PropertyName = "complemento")]
        private string Complemento { get ; set ; }

        [JsonProperty(PropertyName = "bairro")]
        private string Bairro { get ; set; }

        [JsonProperty(PropertyName = "localidade")]
        private string Localidade { get ; set ; }

        [JsonProperty(PropertyName = "uf")]
        private string UF { get ; set ; }

        [JsonProperty(PropertyName = "ibge")]
        private string IBGE { get ; set ; }

        [JsonProperty(PropertyName = "gia")]
        private string GIA { get ; set ; }

        [JsonProperty(PropertyName = "ddd")]
        private int DDD { get ; set ; }

        [JsonProperty(PropertyName = "siafi")]
        private string SIAFE { get; set ; }

        public ResponseViaCep(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, int ddd, string siafe)
        {
            this.Cep = cep;
            this.Logradouro=logradouro;
            this.Complemento = complemento;
            this.Bairro=bairro;
            this.Localidade=localidade;
            this.UF=uf;
            this.IBGE=ibge;
            this.GIA=gia;
            this.DDD = ddd;
            this.SIAFE = siafe;
        }
        public string RetornaCep()
        {
            return this.Cep;
        }
        public string RetornaLogradouro()
        {
            return this.Logradouro;
        }
        public string RetornaComplemento()
        {
            return this.Complemento;
        }
        public string RetornaBairro()
        {
            return this.Bairro;
        }
        public string RetornaLocalidade()
        {
            return this.Localidade;
        }
        public string RetornaUF()
        {
            return this.UF;
        }
        public string RetornaIBGE()
        {
            return this.IBGE;
        }
        public string RetornaGIA()
        {
            return this.GIA;
        }
        public int RetornaDDD()
        {
            return this.DDD;
        }
        public string RetornaSIAFI()
        {
            return this.SIAFE;
        }
    }

}
