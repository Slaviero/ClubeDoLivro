using System.Collections;
using ClubeDoLivro.ModuloAmigo;
using ClubeDoLivro.ModuloCaixa;
using ClubeDoLivro.ModuloRevistas;

namespace ClubeDoLivro
{
    internal class Program
    {
        static RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        static CliAmigo cliAmigo = new CliAmigo(repositorioAmigo);

        static RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        static CliCaixa cliCaixa = new CliCaixa(repositorioCaixa);

        static RepositorioRevistas repositorioRevistas = new RepositorioRevistas();
        static CliRevistas cliRevistas = new CliRevistas(repositorioCaixa, repositorioRevistas);
        static void Main(string[] args)
        {
            string opcao;
            do
            {
                opcao = ApresentarMenuPrincipal();

                switch (opcao)
                {
                    case "1":
                        cliCaixa.ApresentarMenuDeCaixas();
                        break;
                    case "2":
                        cliRevistas.ApresentarMenuDeRevista();
                        break;
                    case "3":
                        ApresentarMenuDeEmprestimo();
                        break;
                    case "4":
                        cliAmigo.ApresentarMenuDeAmigos();
                        break;
                    case "S":; break;
                    default: OpcaoInvalida(); break;
                }
            } while (opcao != "S");
        }
        public static void OpcaoInvalida()
        {
            ApresentarMensagem("Opcão invalido, tente novamente.", ConsoleColor.Red);
        }
        public static void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(mensagem);
            Console.ReadLine();
            Console.ResetColor();
        }
        public static void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine(titulo);

            Console.WriteLine();

            Console.WriteLine(subtitulo);

            Console.WriteLine();
        }
        public static void IncrementarId(int contador)
        {
            contador++;
        }
        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("\nClube da Leitura 1.0");
            Console.WriteLine();
            Console.WriteLine("\nDigite 1 para Acessar o menu de Caixas");
            Console.WriteLine("\nDigite 2 para Acessar o menu de Revistas");
            Console.WriteLine("\nDigite 3 para Acessar o menu de Emprestimos");
            Console.WriteLine("\nDigite 4 para Acessar o menu de Amigos");
            Console.WriteLine("\nDigite S para sair do sistema");


            string opcao = Console.ReadLine();
            return opcao;
        }
        public static void ApresentarMenuDeEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("\nClube da Leitura 1.0");
            Console.WriteLine();
            Console.WriteLine("\nDigite 1 para Inserir uma novo Emprestimo");
            Console.WriteLine("\nDigite 2 para Visualizar os Emprestimos");
            Console.WriteLine("\nDigite 3 para Atualizar um Emprestimo");
            Console.WriteLine("\nDigite S para sair do sistema");


            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":; break;
                case "2":; break;
                case "3":; break;
                case "S":; break;
                default: OpcaoInvalida(); break;
            }
        }
        
    }
}