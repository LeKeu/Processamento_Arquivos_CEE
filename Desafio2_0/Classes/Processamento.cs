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

        public static void Processamento_Contas(string conta, string arq)
        {
            string[] contas_Sol = ServicosTexto.ReadLines_Sol("solicitacoes.txt");
            string[] contasAux = ServicosTexto.ReadLines_Sol(arq);
            

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
                    else Console.WriteLine("Conta já Bloqueada");

                    if (!isContasAux && isContaBloq)
                        Armazenamento.Salvar(conta, arq);
                    else if (!isContaBloq) Console.WriteLine(conta + "Conta precisa ser bloqueada para prosseguir com o cancelamento.");
                    else Console.WriteLine("Conta já Cancelada");
                }
            }
            if (!isSol && arq == "bloqueios.txt")
                Console.WriteLine("-----\nConta não existe - " + arq + "\nSolicite a conta "+conta+"\n-----\n");
            else if (!isSol && arq == "cancelamentos.txt")
                Console.WriteLine("-----\nConta não existe - " + arq + "\nSolicite a conta " + conta + "\n-----\n");

        }

    }
}
