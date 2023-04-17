using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ModuloCaixa;

namespace ClubeDoLivro.ModuloRevistas
{
    internal class CliRevistas
    {
        RepositorioRevistas repositorioRevistas;
        RepositorioCaixa repositorioCaixa;
        Revistas revistas = new Revistas();
        public CliRevistas(RepositorioCaixa repositorioCaixa, RepositorioRevistas repositorioRevistas)
        {
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioRevistas = repositorioRevistas;

        }
        public void ApresentarMenuDeRevista()
        {
            Console.Clear();
            Console.WriteLine("\nClube da Leitura 1.0");
            Console.WriteLine();
            Console.WriteLine("\nDigite 1 para Inserir uma nova Revista");
            Console.WriteLine("\nDigite 2 para Visualizar as Revista Cadastradas");
            Console.WriteLine("\nDigite 3 para Editar uma Revista Cadastrada");
            Console.WriteLine("\nDigite 4 para Excluir uma Revista Cadastrada");
            Console.WriteLine("\nDigite S para sair do sistema");


            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": InserirNovaRevista(); break;
                case "2": VisualizaRevista(); break;
                case "3": EditarRevsita(); break;
                case "4": repositorioRevistas.ExcluirRevista(); break;
                case "S":; break;
                default: Program.OpcaoInvalida(); break;
            }

        }
        public void InserirNovaRevista()
        {

            Program.MostrarCabecalho("Menu de Revistas", "Inserindo uma Nova Revistas: ");

            if (repositorioCaixa.VerificarSeHaCaixa() == false)
            {
                Program.ApresentarMensagem("Não existe nenhuma caixa cadastrada para guardar revistas. Por favor insira uma caixa.", ConsoleColor.Red);

            }
            else
            {
                Console.Write("Digite o título da revista: ");
                revistas.titulo = Console.ReadLine();

                Console.Write("Digite o ano de lançamento da revista: ");
                revistas.ano = Convert.ToInt16(Console.ReadLine());

                bool idCompativel;
                do
                {
                    Console.WriteLine("Digite o ID da caixa onde essa revistá será guardada: ");
                    revistas.caixa = Convert.ToInt16(Console.ReadLine());

                    idCompativel = repositorioRevistas.VerificarIdCompativel(revistas.caixa);

                    if (idCompativel == false)
                    {
                        repositorioRevistas.GravarRevista(repositorioRevistas.ContadorDeRevistas, "INSERIR", revistas.titulo, revistas.ano, revistas.caixa);

                        Program.IncrementarId(repositorioRevistas.ContadorDeRevistas);

                        Program.ApresentarMensagem("Revista inserido com sucesso!", ConsoleColor.Green);
                    }
                } while (idCompativel == true);
            }
        }
        public void VisualizaRevista()
        {
            Program.MostrarCabecalho("Menu de Revistas", "Visualizando Revistas: ");

            if (repositorioRevistas.VerificarSeHaRevistas() == false)
            {
                Program.ApresentarMensagem("Nenhum Revista Cadastrada!", ConsoleColor.DarkYellow);
            }
            else if (repositorioRevistas.VerificarSeHaRevistas() == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-40}", "Id", "Título", "Ano", "Caixa");

                Console.WriteLine("---------------------------------------------------------------------------------------");
                string corCaixaDaRevista;
                for (int i = 0; i < repositorioRevistas.listaIdsRevista.Count; i++)
                {
                    corCaixaDaRevista = repositorioCaixa.EncontrarCorCaixa(Convert.ToInt16(repositorioRevistas.CaixaDaRevista[i]));
                    
                    Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-40}",
                        repositorioRevistas.listaIdsRevista[i], repositorioRevistas.ListaTitulosRevista[i], repositorioRevistas.ListaAnoDaRevista[i], corCaixaDaRevista);
                }

                Console.ResetColor();

                Console.ReadLine();

            }
        }
        public void EditarRevsita()
        {
            Program.MostrarCabecalho("Menu de Revistas", "Editar Revista existente");

            if (repositorioRevistas.VerificarSeHaRevistas() == false)
            {
                Program.ApresentarMensagem("Não há nenhuma revista registrada!", ConsoleColor.Red);

            }
            else
            {
                int idSelecionado = repositorioRevistas.EncontrarRevista();

                Console.Write("Digite o Novo Titulo da revista: ");
                revistas.titulo = Console.ReadLine();

                Console.Write("Digite o Ano da revista: ");
                revistas.ano = Convert.ToInt16(Console.ReadLine());
                
                bool idCompativel = false;
                do
                {
                    Console.Write("Digite a caixa aonde a revista se encontra: ");
                    revistas.caixa = Convert.ToInt16(Console.ReadLine());

                    idCompativel = repositorioRevistas.VerificarIdCompativel(revistas.caixa);

                    if (idCompativel = true)
                    {
                        repositorioRevistas.GravarRevista(idSelecionado, "EDITAR", revistas.titulo, revistas.ano, revistas.caixa);

                        Program.ApresentarMensagem("Revista editada com sucesso!", ConsoleColor.Green);
                    }
                } while (idCompativel = false);
            }
        }

    }
}
