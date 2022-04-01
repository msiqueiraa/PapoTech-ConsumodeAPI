using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapoTech.Classes
{
    public class Startup
    {
        public void Start()
        {
            string opcaoUsuario = Program.ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Program.ListarCidade();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "2":
                        Program.InserirCidade();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "3":
                        Program.AtualizarCidade();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "4":
                        Program.ExcluirCidade();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "5":
                        Program.VisualizarCidade();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "6":
                        Program.InserirCidadeCepAsync().ConfigureAwait(false);
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "7":
                        Program.VerificaTempoCidade().ConfigureAwait(false);
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                    default:
                        Console.WriteLine("Opção selecionada inválida");
                        opcaoUsuario = Program.ObterOpcaoUsuario();
                        break;
                }
            }
        }
    }
}
  