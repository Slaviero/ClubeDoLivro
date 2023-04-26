using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ModuloCaixa
{
    internal class CliCaixa
    {

        RepositorioCaixa repositorioCaixa;
        Caixa caixa = new Caixa();
        public CliCaixa(RepositorioCaixa repositorioCaixa) 
        { 
            this.repositorioCaixa = repositorioCaixa;
        }
        public void ApresentarMenuDeCaixas()
        {
            Console.Clear();
            Console.WriteLine("\nClube da Leitura 1.0");
            Console.WriteLine();
            Console.WriteLine("\nDigite 1 para Inserir uma nova Caixa");
            Console.WriteLine("\nDigite 2 para Visualizar as Caixas Cadastradas");
            Console.WriteLine("\nDigite 3 para Editar uma Caixa Cadastrada");
            Console.WriteLine("\nDigite 4 para Excluir uma Caixa Cadastrada");
            Console.WriteLine("\nDigite S para sair do sistema");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": InserirNovaCaixa(); break;
                case "2": VisualizaCaixa(); break;
                case "3": EditarCaixa(); break;
                case "4": repositorioCaixa.ExcluirCaixa(); break;
                case "S": break;
                default: Program.OpcaoInvalida(); break;
            }
        }
        public void InserirNovaCaixa()
        {
            Program.MostrarCabecalho("Menu de Caixas", "Inserindo uma Nova Caixa: ");

            Console.Write("Digite a Cor da Caixa: ");
            caixa.cor = Console.ReadLine();

            Console.Write("Digite o conteúdo da Etiqueta da Caixa: ");
            caixa.etiqueta = Console.ReadLine();
            

            int idCaixa = repositorioCaixa.ContadorDeCaixas;

            repositorioCaixa.GravarCaixa(idCaixa, "INSERIR", caixa.cor, caixa.etiqueta);

            repositorioCaixa.GravarCaixa(idCaixa, "INSERIR", caixa);

            Program.IncrementarId(repositorioCaixa.ContadorDeCaixas);

            Program.ApresentarMensagem("Caixa inserido com sucesso!", ConsoleColor.Green);
        }
        public void VisualizaCaixa()
        {
            Program.MostrarCabecalho("Menu de Caixas", "Visualizando Caixas: ");

            if (repositorioCaixa.VerificarSeHaCaixa() == false)
            {
                Program.ApresentarMensagem("Nenhum Caixa Cadastrada!", ConsoleColor.DarkYellow);
                
            }
            else if(repositorioCaixa.VerificarSeHaCaixa() == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Cor", "Etiqueta");

                Console.WriteLine("---------------------------------------------------------------------------------------");

                for (int i = 0; i < repositorioCaixa.listaIdsCaixa.Count; i++)
                {
                    Console.WriteLine("{0,-10} | {1,-40} | {2,-30}",
                        repositorioCaixa.listaIdsCaixa[i], repositorioCaixa.ListaCoresDaCaixa[i], repositorioCaixa.ListaEtiquetasDaCaixa[i]);
                }

                Console.ResetColor();

                Console.ReadLine();

            }
        }
        public void EditarCaixa()
        {
            Program.MostrarCabecalho("Menu de Caixas", "Editar Caixa existente");

            if (repositorioCaixa.VerificarSeHaCaixa() == false)
            {
                Program.ApresentarMensagem("Não há nenhuma caixa registrada!", ConsoleColor.Red);

            }
            else
            {
                int idSelecionado = repositorioCaixa.EncontrarCaixa();
                
                Console.Write("Digite a nova Cor da Caixa: ");
                caixa.cor = Console.ReadLine();

                Console.Write("Digite o conteúdo da Etiqueta da Caixa: ");
                caixa.etiqueta = Console.ReadLine();

                repositorioCaixa.GravarCaixa(idSelecionado, "EDITAR", caixa.cor, caixa.etiqueta);

                Program.ApresentarMensagem("Caixa editado com sucesso!", ConsoleColor.Green);

            }
        }
    }
}
