using Desafio2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2_0.Classes
{
    internal class ServicosChecagem
    {
        // Checar se o nome do arquivo é valido
        public static bool IsValid_Name(string text) => (text.Substring(0, 4) == "CARD" && int.TryParse(text.Substring(4, 4), out _)
                && int.TryParse(text.Substring(8, 2), out _) && int.TryParse(text.Substring(10, 2), out _) 
            && text.Substring(text.Length - 3) == ".IN") ? true : false;


        // Checar se o header é válido (00, data, tamanho)
        public static bool IsValid_Header(Header header, string data_Name) => 
            (header.Data == data_Name && header.Tipo == "00" && header.Tamanho == 16) ? true : false;

        public static void isValid_Solicitacao(Solicitacao solicitacao, string data_Name)
        {
            string erro = null;

        }
        





        /*
        public static bool IsValidDetails(string text)
        {
            string card = text.Substring(0, 4);

            string ano = text.Substring(4, 4);

            string mes = text.Substring(8, 2);

            string dia = text.Substring(10, 2);

            string sequencia = text.Substring(12).Remove(3);
            return true;
        }
        */
    }
}
