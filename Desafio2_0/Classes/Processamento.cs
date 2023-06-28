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
            string[] contas = ServicosTexto.ReadLines_Sol("solicitacoes.txt");
            bool isSol = false;
            foreach (string c in contas)
            {
                if (c == conta)
                {
                    isSol = true;
                    Armazenamento.Salvar(conta, arq);
                }
            }
            if (!isSol)
                Console.WriteLine("-----\nConta não existe - " + arq + "\nSolicite a conta "+conta+"\n-----\n");
        }
    }
}
