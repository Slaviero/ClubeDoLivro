using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ModuloCaixa
{

    public class RepositorioCaixa
    {
        public int ContadorDeCaixas = 1;

        public  ArrayList ListaCoresDaCaixa = new ArrayList();
        public  ArrayList ListaEtiquetasDaCaixa = new ArrayList();
        public  ArrayList listaIdsCaixa = new ArrayList();

        public Caixa caixa = new Caixa();

        public int EncontrarCaixa()
        {
            int idSelecionado = 0;
            bool idInvalido;
            do
            {

                Console.WriteLine("Digite o Id da Caixa que deseja encontrar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsCaixa.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);


            } while (idInvalido);

            return idSelecionado;
        } 
        public void ExcluirCaixa()
        {
            Program.MostrarCabecalho("Cadastro de Caixas", "Excluindo Caixas: ");

            if (VerificarSeHaCaixa() == false)
            {
                Program.ApresentarMensagem("Não há nenhuma caixa registrada!", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine();

                int idSelecionado = EncontrarCaixa();

                int posicao = listaIdsCaixa.IndexOf(idSelecionado);

                listaIdsCaixa.RemoveAt(posicao);
                ListaCoresDaCaixa.RemoveAt(posicao);
                ListaEtiquetasDaCaixa.RemoveAt(posicao);

                Program.ApresentarMensagem("Caixa Excluida com sucesso!", ConsoleColor.Green);

            }
        }
        public void GravarCaixa(int id, string tipoOperacao, string cor, string etiqueta)
        {

            if (tipoOperacao == "EDITAR")
            {
                int posicao = listaIdsCaixa.IndexOf(id);

                ListaCoresDaCaixa[posicao] = cor;
                ListaEtiquetasDaCaixa[posicao] = etiqueta;

            }
            else if (tipoOperacao == "INSERIR")
            {
                ListaCoresDaCaixa.Add(cor);
                ListaEtiquetasDaCaixa.Add(etiqueta);
                listaIdsCaixa.Add(id);
            }
        }
        public bool VerificarSeHaCaixa()
        {
            if(listaIdsCaixa.Count <= 0)
                return false;
            else 
                return true;
        }
        public string EncontrarCorCaixa(int idInformado)
        {
            string corDaCaixa = ListaCoresDaCaixa[idInformado].ToString();
            return corDaCaixa;
        }
    }
}
