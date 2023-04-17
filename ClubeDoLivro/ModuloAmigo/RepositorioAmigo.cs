using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ModuloAmigo
{
    internal class RepositorioAmigo
    {
        public int ContadorDeAmigo = 1;
        public ArrayList listaNomesAmigo = new ArrayList();
        public ArrayList ListaResponsavelAmigo = new ArrayList();
        public ArrayList ListaNumeroAmigo = new ArrayList();
        public ArrayList ListaEnderecoAmigo = new ArrayList();
        public ArrayList listaIdsAmigo = new ArrayList();
        public void GravarAmigo(int id, string tipoOperacao, string nome, string nomeResponsavel, int numeroTelefone, string endereco)
        {

            if (tipoOperacao == "EDITAR")
            {
                int posicao = listaIdsAmigo.IndexOf(id);

                listaNomesAmigo[posicao] = nome;
                ListaResponsavelAmigo[posicao] = nomeResponsavel;
                ListaNumeroAmigo[posicao] = numeroTelefone;
                ListaEnderecoAmigo[posicao] = endereco;


            }
            else if (tipoOperacao == "INSERIR")
            {
                listaIdsAmigo.Add(id);
                listaNomesAmigo.Add(nome);
                ListaResponsavelAmigo.Add(nomeResponsavel);
                ListaNumeroAmigo.Add(numeroTelefone);
                ListaEnderecoAmigo.Add(endereco);
            }
        }
        public bool VerificarSeHaAmigos()
        {
            if (listaIdsAmigo.Count <= 0)
                return false;
            else
                return true;
        }
        public int EncontrarAmigo()
        {
            int idSelecionado = 0;
            bool idInvalido;
            do
            {

                Console.WriteLine("Digite o Id do Amigo que deseja encontrar: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = listaIdsAmigo.Contains(idSelecionado) == false;

                if (idInvalido)
                    Program.ApresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);


            } while (idInvalido);

            return idSelecionado;
        }
        public void ExcluirAmigo()
        {
            Program.MostrarCabecalho("Cadastro de Amigo", "Excluindo Amigo: ");

            if (VerificarSeHaAmigos() == false)
            {
                Program.ApresentarMensagem("Não há nenhum amigo registrado!", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine();

                int idSelecionado = EncontrarAmigo();

                int posicao = listaIdsAmigo.IndexOf(idSelecionado);

                listaNomesAmigo.RemoveAt(posicao);
                ListaResponsavelAmigo.RemoveAt(posicao);
                ListaNumeroAmigo.RemoveAt(posicao);
                ListaEnderecoAmigo.RemoveAt(posicao);
                listaIdsAmigo.RemoveAt(posicao);

                Program.ApresentarMensagem("Amigo Excluido com sucesso!", ConsoleColor.Green);

            }
        }

    }
}
