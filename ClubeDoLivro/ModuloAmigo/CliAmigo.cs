using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ModuloCaixa;

namespace ClubeDoLivro.ModuloAmigo
{
    internal class CliAmigo
    {
        Amigo amigo = new Amigo();
        RepositorioAmigo repositorioAmigo;
        public CliAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
        public void ApresentarMenuDeAmigos()
        {
            Console.Clear();
            Console.WriteLine("\nClube da Leitura 1.0");
            Console.WriteLine();
            Console.WriteLine("\nDigite 1 para Inserir uma nova Amigo");
            Console.WriteLine("\nDigite 2 para Visualizar as Amigos Cadastrados");
            Console.WriteLine("\nDigite 3 para Editar uma Cadastro de Amigo");
            Console.WriteLine("\nDigite 4 para Excluir uma Cadastro de Amigo");
            Console.WriteLine("\nDigite S para sair do sistema");


            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": InserirNovoAmigo(); break;
                case "2": VisualizaAmigo(); break;
                case "3": EditarAmigo(); break;
                case "4": repositorioAmigo.ExcluirAmigo(); break;
                case "S":; break;
                default: Program.OpcaoInvalida(); break;
            }

        }
        public void InserirNovoAmigo()
        {
            Program.MostrarCabecalho("Menu de Amigo", "Inserindo um Novo Amigo: ");

            Console.Write("Digite o Nome do Amigo: ");
            amigo.nome = Console.ReadLine();

            Console.Write("Digite o Nome do Responsavel desse Amigo: ");
            amigo.responsavel = Console.ReadLine();
            
            Console.Write("Insira o endereço: ");
            amigo.endereco = Console.ReadLine();

            Console.Write("Insira um numero de celular: ");
            amigo.numero = Convert.ToInt16(Console.ReadLine());

            repositorioAmigo.GravarAmigo(repositorioAmigo.ContadorDeAmigo, "INSERIR", amigo.nome, amigo.responsavel, amigo.numero, amigo.endereco);

            Program.IncrementarId(repositorioAmigo.ContadorDeAmigo);

            Program.ApresentarMensagem("Amigo inserido com sucesso!", ConsoleColor.Green);
        }
        public void VisualizaAmigo()
        {
            Program.MostrarCabecalho("Menu de Amigos", "Visualizando Amigos: ");

            if (repositorioAmigo.VerificarSeHaAmigos() == false)
            {
                Program.ApresentarMensagem("Nenhum Amigo Cadastrado, sinto muito por você ;-;", ConsoleColor.DarkYellow);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-40}", "Id", "nome", "Responsavel", "Telefone", "Endereco");

                Console.WriteLine("---------------------------------------------------------------------------------------");

                for (int i = 0; i < repositorioAmigo.listaIdsAmigo.Count; i++)
                {
                    Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-40}",
                        repositorioAmigo.listaIdsAmigo[i], repositorioAmigo.listaNomesAmigo[i], repositorioAmigo.ListaResponsavelAmigo[i], repositorioAmigo.ListaNumeroAmigo[i], repositorioAmigo.ListaEnderecoAmigo[i]);
                }

                Console.ReadLine();

                Console.ResetColor();
            }
        }
        public void EditarAmigo()
        {
            Program.MostrarCabecalho("Menu de Amigos", "Editar Amigo existente");

            if (repositorioAmigo.VerificarSeHaAmigos() == false)
            {
                Program.ApresentarMensagem("Não há nenhuma amigo registrado!", ConsoleColor.Red);

            }
            else
            {
                int idSelecionado = repositorioAmigo.EncontrarAmigo();

                Console.Write("Digite o novo Nome do Amigo: ");
                amigo.nome = Console.ReadLine();

                Console.Write("Digite o Nome do Responsavel desse Amigo: ");
                amigo.responsavel = Console.ReadLine();

                Console.Write("Insira o endereço: ");
                amigo.endereco = Console.ReadLine();

                Console.Write("Insira um numero de celular: ");
                amigo.numero = Convert.ToInt16(Console.ReadLine());

                repositorioAmigo.GravarAmigo(idSelecionado, "EDITAR", amigo.nome, amigo.responsavel, amigo.numero, amigo.endereco);

                Program.ApresentarMensagem("Caixa editado com sucesso!", ConsoleColor.Green);

            }
        }

    }
}
