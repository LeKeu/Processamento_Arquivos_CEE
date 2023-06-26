// See https://aka.ms/new-console-template for more information
using Desafio2_0.Classes;
using Desafio2_0.Models;

string arq = "CARD20230619001.IN";

if (ServicosChecagem.IsValid_Name(arq))
{
    List<Solicitacao> SolicitacaoList = new List<Solicitacao>();

    string arqTeste = ServicosTexto.ReadAll(arq);

    string[] arqLinhas = ServicosTexto.ReadLines(arq);

    foreach (string registro in arqLinhas)
    {
        string tipo = registro.Substring(0, 2);

        switch (tipo)
        {
            case "00":
                Header header = new Header();

                header.Tipo = tipo;
                header.Data = registro.Substring(2, 8);
                header.CodRemetente = registro.Substring(10);
                header.Tamanho = registro.Length;

                if (ServicosChecagem.IsValid_Header(header, arq.Substring(4, 8)))
                    Console.WriteLine("header legal");

                break;

            case "01":
                Solicitacao solicitacao = new Solicitacao();
                string subTexto = registro.Substring(43);

                string nome = null;
                string nomeCartao = null;
                string coisa = null;

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
                
                for (int i = aux; i < words.Length; i++)
                {
                    if (int.TryParse(words[i], out _))
                    {
                        coisa += words[i];
                        break;
                    }
                    else
                    {
                        nomeCartao += words[i] + " ";
                    }
                }
                
                solicitacao.Tipo = tipo;
                //Console.WriteLine(tipo);
                solicitacao.Data = registro.Substring(2, 8);
                //Console.WriteLine(solicitacao.Data);
                solicitacao.Id = registro.Substring(10, 6);
                //Console.WriteLine(solicitacao.Id);
                solicitacao.Agencia = registro.Substring(16, 4);
                //Console.WriteLine(solicitacao.Agencia);
                solicitacao.Conta = registro.Substring(20, 12);
                //Console.WriteLine(solicitacao.Conta);
                solicitacao.Cpf = registro.Substring(32, 11);
                //Console.WriteLine(solicitacao.Cpf);

                //SolicitacaoList.Add(solicitacao);
                break;

            default:
                Console.WriteLine("hello");
                break;

        }
    }

    

    

    Console.WriteLine();
}
else
{
    Console.WriteLine("ERRO! Checar nome do arquivo!");
}




