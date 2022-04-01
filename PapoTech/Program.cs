using Newtonsoft.Json;
using PapoTech.Classes;

namespace PapoTech
{    class Program
    {
        static CidadeController repository = new CidadeController();
        static void Main(string[] args)
        {
            Startup Init = new Startup();
            Init.Start();         
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar cidades");
            Console.WriteLine("2- Inserir nova cidade");
            Console.WriteLine("3- Atualizar Cidade");
            Console.WriteLine("4- Excluir Cidade");
            Console.WriteLine("5- Visualizar cidade");
            Console.WriteLine("6- Inserir cidade pelo CEP");
            Console.WriteLine("7- Verificar tempo nas cidades salvas");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper() ;
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static void ListarCidade()
        {
            Console.WriteLine("Listar cidades");
            var lista = repository.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma cidade cadatrada");
                return;
            }
            foreach (var cidade in lista)
            {
                var excluido = cidade.RetornaExcluido();
                Console.WriteLine("#ID {0}-{1}-{2}", cidade.RetornaId(), cidade.RetornaCidade(),cidade.RetornaEstado(), excluido ? "- Cidade excluída. ": "");
            }
        }
        public static void InserirCidade()
        {
            Console.WriteLine("Inserir nova Cidade");
            
            Console.WriteLine("Digite o nome da cidade: ");
            string Cidade = Console.ReadLine();

            Console.WriteLine("Digite o estado: ");
            string Estado = Console.ReadLine();

            Console.WriteLine("Digite o país: ");
            string Pais = Console.ReadLine();

            CidadeBase novaCidade = new CidadeBase(id: repository.ProximoId(), cidade: Cidade, estado: Estado, pais: Pais);

            repository.Insere(novaCidade);

        }
        public static void AtualizarCidade()
        {
            Console.Write("Digite o ID da cidade ");
            int indiceCidade = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Digite o nome da cidade: ");
            string Cidade = Console.ReadLine();

            Console.WriteLine("Digite o estado: ");
            string Estado = Console.ReadLine();

            Console.WriteLine("Digite o país: ");
            string Pais = Console.ReadLine();

            CidadeBase atualizaCidade = new CidadeBase(id: indiceCidade, cidade: Cidade, estado: Estado, pais: Pais);

            repository.Atualiza(indiceCidade, atualizaCidade);
        }
        public static void ExcluirCidade()
        {
            Console.Write("Digite o ID da Cidade: ");
            int indiceCidade = int.Parse(Console.ReadLine());

            repository.Exclui(indiceCidade);
        }

        public static void VisualizarCidade()
        {
            Console.Write("Digite o ID da Cidade: ");
            int indiceCidade = int.Parse(Console.ReadLine());

            CidadeBase Cidade = repository.RetornaPorId(indiceCidade);

            Console.WriteLine(Cidade);
        }
        public static async Task InserirCidadeCepAsync()
        {
            Console.WriteLine("Inserir nova Cidade a partir do CEP BR");

            Console.WriteLine("Digite o Cep da cidade, apenas números: ");
            int Cep = int.Parse(Console.ReadLine());
            string CepString = Cep.ToString().Trim();
            if (CepString.Length == 8)
            {
                ViaCepApiConn BuscaCep = new ViaCepApiConn();
                var Response = await BuscaCep.GetApi(CepString);
                ResponseViaCep Res = JsonConvert.DeserializeObject<ResponseViaCep>(Response.ToString());
                if (Response.ToString().Contains("erro"))
                {
                    Console.WriteLine("Cep inválido");
                }
                else
                {
                    CidadeBase novaCidade = new CidadeBase(id: repository.ProximoId(), cidade: Res.RetornaLocalidade(), estado: Res.RetornaUF(), pais: "br");
                    repository.Insere(novaCidade);
                    Console.WriteLine("Cidade Cadastrada");
                }
            }
            else
            {
                Console.WriteLine("CEP inválido");
            }
        }
        public static async Task VerificaTempoCidade()
        {
            var lista = repository.Lista();
            Console.WriteLine("Tempo nas cidades: ");
            foreach (var cidade in lista)
            {
                TempoConn tempoRepository = new TempoConn();
                var Response = await tempoRepository.GetApi(cidade.RetornaCidade().ToString());
                Root Res = JsonConvert.DeserializeObject<Root>(Response.ToString());
                Console.WriteLine("Cidade: {0} - Céu: {1} -  Temperatura: {2} - Sensação Térmica: {3} - Temperatura Mín: {4} - Temperatura Máx: {5} - Velocidade do Vento: {6}", cidade, Res.weather[0].description, Res.main.temp, Res.main.feels_like, Res.main.temp_min, Res.main.temp_max, Res.wind.speed);                               
            }
        }
    }
}
