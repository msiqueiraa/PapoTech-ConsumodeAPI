using Newtonsoft.Json;
using PapoTech.Classes;

namespace PapoTech
{    class Program
    {
        static CidadeRepository repository = new CidadeRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario!= "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarCidade();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "2":
                        InserirCidade();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "3":
                        AtualizarCidade();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "4":
                        ExcluirCidade();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "5":
                        VisualizarCidade();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "6":
                        InserirCidadeCep();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;

                    default:
                        Console.WriteLine("Opção selecionada inválida");
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                }
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar cidades");
            Console.WriteLine("2- Inserir nova cidade");
            Console.WriteLine("3- Atualizar Cidade");
            Console.WriteLine("4- Excluir Cidade");
            Console.WriteLine("5- Visualizar cidade");
            Console.WriteLine("6- Inserir cidade pelo CEP");
            Console.WriteLine("6- Executar script");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper() ;
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarCidade()
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
        private static void InserirCidade()
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
        private static void AtualizarCidade()
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
        private static void ExcluirCidade()
        {
            Console.Write("Digite o ID da Cidade: ");
            int indiceCidade = int.Parse(Console.ReadLine());

            repository.Exclui(indiceCidade);
        }

        private static void VisualizarCidade()
        {
            Console.Write("Digite o ID da série: ");
            int indiceCidade = int.Parse(Console.ReadLine());

            CidadeBase Cidade = repository.RetornaPorId(indiceCidade);

            Console.WriteLine(Cidade);
        }
        private static void InserirCidadeCep()
        {
            Console.WriteLine("Inserir nova Cidade a partir do CEP BR");

            Console.WriteLine("Digite o Cep da cidade, apenas números: ");
            int Cep = int.Parse(Console.ReadLine());
            string CepString = Cep.ToString();
            if(CepString.Length==8)
            {
                ViaCepApiRepository BuscaCep = new ViaCepApiRepository();
                var Response = BuscaCep.GetApi(CepString);               
                ResponseViaCep Res = JsonConvert.DeserializeObject<ResponseViaCep>(Response.ToString());
                CidadeBase novaCidade = new CidadeBase(id: repository.ProximoId(), cidade: Res.RetornaLocalidade(), estado: Res.RetornaUF(), pais: "br");
                repository.Insere(novaCidade);
            }
            Console.WriteLine("CEP inválido");

        }
    }
}
