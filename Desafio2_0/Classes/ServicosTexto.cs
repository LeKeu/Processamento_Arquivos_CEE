using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_0.Classes
{
    internal class ServicosTexto
    {
        public static string ReadAll(string nomeArq) => File.ReadAllText(Globals.PATH + nomeArq);

        public static string[] ReadLines(string nomeArq) => File.ReadAllLines(Globals.PATH + nomeArq);

        public static string[] SepararNome(string registro)
        {
            List <string> results = new List <string> ();
            string subTexto = registro.Substring(43);

            string nome = null;
            string nomeCartao = null;
            string senha = null;

            int aux = 0;
            string[] words = subTexto.Split(' ');

            foreach (string palavra in words)
            {
                if (palavra.Length == 1)
                    break;
                nome += palavra + " ";
                aux++;
                //if (Char.IsLetter(palavra))
            }
            results.Add(nome);
            for (int i = aux; i < words.Length; i++)
            {
                if (int.TryParse(words[i], out _))
                {
                    senha += words[i];
                    break;
                }
                else
                {
                    nomeCartao += words[i] + " ";
                }
            }
            results.Add(nomeCartao);
            results.Add(senha.Substring(2));
            results.Add(senha.Substring(0, 2)); // data vencimento

            return results.ToArray();
        }

    }
}
