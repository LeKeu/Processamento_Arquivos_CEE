using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_0.Classes
{
    internal class Armazenamento
    {
        /*
        Salva a conta em um arquivo separado para checagens futuras.
        */
        public static void Salvar(string conta, string arq)
        {
            bool isSol = false;

            string[] linhas = ServicosTexto.ReadLines_Sol(arq);

            foreach (string line in linhas)
            {
                if (line == conta)
                    isSol = true;
            }

            if (!isSol)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Globals.PATH_SOL, arq), true))
                {
                    outputFile.WriteLine(conta);
                }
            }
            else
            {
                Console.WriteLine("(Armazenamento.cs) Conta "+conta+" já registrada no arquivo "+arq);
            }
            
        }
    }
}
