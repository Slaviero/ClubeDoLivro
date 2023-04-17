using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ModuloCaixa;

namespace ClubeDoLivro.ModuloRevistas
{
    internal class RepositorioRevistas
    {
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        public int ContadorDeRevistas = 1;

        public ArrayList ListaTitulosRevista = new ArrayList();
        public ArrayList ListaAnoDaRevista = new ArrayList();
        public ArrayList CaixaDaRevista = new ArrayList();
        public ArrayList listaIdsRevista = new ArrayList();

        public void GravarRevista(int id, string tipoOperacao, string titulo, int ano, int idCaixa)
        {


            if (tipoOperacao == "INSERIR")
            {
                ListaTitulosRevista.Add(titulo);
                ListaAnoDaRevista.Add(ano);
                listaIdsRevista.Add(id);
                CaixaDaRevista.Add(idCaixa);
            }
            else if (tipoOperacao == "EDITAR")
            {
                int posicao = listaIdsRevista.IndexOf(id);

                ListaTitulosRevista[posicao] = titulo;
                ListaAnoDaRevista[posicao] = ano;
                CaixaDaRevista[posicao] = idCaixa;
            }
        }

        public bool VerificarIdCompativel(int idParametro)
        {
            if (repositorioCaixa.listaIdsCaixa.Contains(idParametro))
            {
                return true;
            }
            else
            {
                Program.ApresentarMensagem("O ID não corresponde com nenhuma caixa existente. Insira um novo id.", ConsoleColor.Red);

                return false;
            }
        }
        public bool VerificarSeHaRevistas()
        {
            if(listaIdsRevista.Count <= 0)
                return false;
            else 
                return true;
        }
        public int EncontrarRevista()
        {
            int idSelecionado = 0;
            bool idInvalido;
            do
            {

                Console.WriteLine("Digite o Id da Revista que deseja encontrar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsRevista.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);


            } while (idInvalido);

            return idSelecionado;
        }
        public void ExcluirRevista()
        {
            Program.MostrarCabecalho("Cadastro de Caixas", "Excluindo Caixas: ");

            if (VerificarSeHaRevistas() == false)
            {
                Program.ApresentarMensagem("Não há nenhuma caixa registrada!", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine();

                int idSelecionado = EncontrarRevista();

                int posicao = listaIdsRevista.IndexOf(idSelecionado);

                listaIdsRevista.RemoveAt(posicao);
                CaixaDaRevista.RemoveAt(posicao);
                ListaAnoDaRevista.RemoveAt(posicao);
                ListaTitulosRevista.RemoveAt(posicao);
                Program.ApresentarMensagem("Caixa Excluida com sucesso!", ConsoleColor.Green);

            }
        }

    }
}
