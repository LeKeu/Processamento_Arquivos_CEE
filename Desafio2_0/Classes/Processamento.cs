using Desafio2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_0.Classes
{
    internal class Processamento
    {
        /*
        Pode ser usada para checar se a conta de um registro de cancelamento ou bloqueio já foi solicitada, comparando
            a conta do registro ocm todas as contas salvas no arq de solicitações.
        Caso a conta a ser bloqueada/cancelada exista no arquivo, ela é salva em um novo arquivo (bloqueios.txt/cancelamentos.txt)
            indicando seu novo status.
        Caso a conta a ser bloqueada/cancelada exista no arquivo, ela não pode ser bloqueada/cancelada
            por nunca ter sido solicitada primeiramente.
        */

        public static void Processamento_Contas(string registro, string arq)
        {
            List<string> objetos = SepararTexto(registro);
            string[] contas_Sol = ServicosTexto.ReadLines_Sol("solicitacoes.txt");
            string[] contasAux = ServicosTexto.ReadLines_Sol(arq);

            string tipo = objetos[0];
            string data = objetos[1];
            string id_t = objetos[2];
            string conta = objetos[3];

            bool isSol = false;     // checar se a solicitação já existe
            bool isContasAux = false;   //checar se a conta já foi bloq/cance
            bool isContaBloq = false;   // checar se a conta já foi bloq (situação de cancelamento).

            foreach (string c in contas_Sol)
            {
                if (c == conta)
                {
                    isSol = true;

                    if (arq == "cancelamentos.txt") //se for cancelamnto, checar se a conta já foi préviamente cancelada
                    {
                        string[] contasBloq = ServicosTexto.ReadLines_Sol("bloqueios.txt"); 
                        foreach(string cBloq in contasBloq)
                        {
                            if (cBloq == conta)
                                isContaBloq= true;
                        }
                    }

                    foreach (string c1 in contasAux)    //checagem do próprio arquivo recebido para checar a existencia da conta nele
                    {
                        if (c1 == conta)
                            isContasAux = true;
                    }

                    if (!isContasAux && arq == "bloqueios.txt")
                        Armazenamento.Salvar(conta, arq);
                    else if (isContasAux && arq == "bloqueios.txt") {
                        Globals.ISERRO = true;
                        Globals.ERROS.Add(tipo + data + id_t + (new Random()).Next(1000, 9999) + "B     Conta já bloqueada.");

                    }

                    if (!isContasAux && isContaBloq)
                        Armazenamento.Salvar(conta, arq);
                    else if (!isContaBloq && arq == "cancelamentos.txt")
                    {
                        Globals.ISERRO = true;
                        Globals.ERROS.Add(tipo + data + id_t + (new Random()).Next(1000, 9999) + "C     Conta precisa ser bloqueada para seguir com cancelamento.");
                    }
                    else if (isContasAux && arq == "cancelamentos.txt") {
                        Globals.ISERRO = true;
                        Globals.ERROS.Add(tipo + data + id_t + (new Random()).Next(1000, 9999) + "C     Conta já cancelada.");
                    }
                }
            }
            if (!isSol && arq == "bloqueios.txt") {
                Globals.ISERRO = true;
                Globals.ERROS.Add(tipo + data + id_t + (new Random()).Next(1000, 9999) + "B     Conta não encontrada.");
            }
            else if (!isSol && arq == "cancelamentos.txt")
            {
                Globals.ISERRO = true;
                Globals.ERROS.Add(tipo + data + id_t + (new Random()).Next(1000, 9999) + "C     Conta não encontrada.");
            }
                

        }

        private static List<string> SepararTexto(string registro)
        {
            List<string> retorno = new List<string>();
            string tipo = registro.Substring(0, 2);
            string data = registro.Substring(2, 8);
            string Id_T = registro.Substring(10, 6);
            string Conta = registro.Substring(20, 12);

            retorno.Add(tipo);
            retorno.Add(data);
            retorno.Add(Id_T);
            retorno.Add(Conta);

            return retorno;
        }

    }
}
