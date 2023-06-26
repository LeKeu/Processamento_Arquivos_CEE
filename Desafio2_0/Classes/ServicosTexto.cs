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

    }
}
