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
        public static bool IsValid_NomeArq(string text) => 
            (text.Substring(0, 4) == "CARD" && int.TryParse(text.Substring(4, 4), out _) 
            && int.TryParse(text.Substring(8, 2), out _) && int.TryParse(text.Substring(10, 2), out _) 
            && text.Substring(text.Length - 3) == ".IN") ? true : false;

        public static bool IsValid_Header(Header h, string data_Name) => 
            (h.Data == data_Name && h.Tipo == "00" && h.Tamanho == 16) ? true : false;

        public static bool IsValid_Solicitacao(Solicitacao s, string data_Name) => 
            (s.Data == data_Name && int.TryParse(s.Id, out _) && int.TryParse(s.Agencia, out _) 
            && int.TryParse(s.Conta, out _) && long.TryParse(s.Cpf, out _) && s.Nome.Length <= 40 
            && s.NomeCartao.Length <= 40 && int.TryParse(s.DiaVencimento, out _) && s.Senha.Length == 8) ? true : false;

        public static bool IsValid_Bloqueio(Bloqueio b, string data_Name) => 
            (b.Data == data_Name && int.TryParse(b.Id_T, out _) && int.TryParse(b.Agencia, out _) 
            && int.TryParse(b.Conta, out _) && (int.TryParse(b.Motivo, out _)) && int.TryParse(b.Id_O, out _)) ? true : false;

        public static bool IsValid_Cancelamento(Cancelamento c, string data_Name) =>
            (c.Data == data_Name && int.TryParse(c.Id_T, out _) && int.TryParse(c.Agencia, out _)
            && int.TryParse(c.Conta, out _) && (int.TryParse(c.Motivo, out _)) && int.TryParse(c.Id_O, out _)) ? true : false;

        public static bool IsValid_Trailler(Trailler t, string data_Name, int linhas, int auxLinhas) => 
            (t.Data == data_Name && int.Parse(t.Tot_Registros) == linhas && int.Parse(t.Tot_Registros) == auxLinhas) ? true : false;

    }
}
