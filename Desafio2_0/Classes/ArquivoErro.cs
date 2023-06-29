using Desafio2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_0.Classes
{
    internal class ArquivoErro
    {
        public static void ERR(string nomeArq, Header header, Trailler trailler)
        {
            string zeros = null;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Globals.PATH_ERR, nomeArq.Replace(".IN", ".ERR")), true))
            {
                outputFile.WriteLine(header.Tipo+header.Data+header.CodRemetente);

                foreach(string erro in Globals.ERROS)
                {
                    outputFile.WriteLine(erro);
                }
                int qntdReg = Globals.ERROS.Count + 2;
                for (int i = 0; i < 8 - qntdReg.ToString().Length; i++)
                {
                    zeros += "0";
                }
                outputFile.WriteLine(trailler.Tipo.ToString()+trailler.Data.ToString()+zeros+qntdReg);
            }
        }
    }
}
