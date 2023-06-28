// See https://aka.ms/new-console-template for more information
using Desafio2_0.Classes;
using Desafio2_0.Models;

string arq = "CARD20230619001.IN";
string data_arq = arq.Substring(4, 8);

if (ServicosChecagem.IsValid_NomeArq(arq))
{
    List<Solicitacao> SolicitacaoList = new List<Solicitacao>();

    //string arqTeste = ServicosTexto.ReadAll(arq);

    string[] arqLinhas = ServicosTexto.ReadLines(arq);
    int auxLinhas = 0;

    //try
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

                if (ServicosChecagem.IsValid_Header(header, data_arq))
                    Console.WriteLine("header valido legal");

                auxLinhas++;
                break;

            case "01":
                Solicitacao solicitacao = new Solicitacao();

                string[] Aux = ServicosTexto.SepararNome(registro);

                solicitacao.Tipo = tipo;
                solicitacao.Data = registro.Substring(2, 8);
                solicitacao.Id = registro.Substring(10, 6);
                solicitacao.Agencia = registro.Substring(16, 4);
                solicitacao.Conta = registro.Substring(20, 12);
                solicitacao.Cpf = registro.Substring(32, 11);
                solicitacao.Nome = Aux[0];
                solicitacao.NomeCartao = Aux[1];
                solicitacao.Senha = Aux[2];
                solicitacao.DiaVencimento = Aux[3];

                if (ServicosChecagem.IsValid_Solicitacao(solicitacao, data_arq))
                    Console.WriteLine("solicitacao valida nice");
                else Console.WriteLine("nop Sol");

                //SolicitacaoList.Add(solicitacao);
                auxLinhas++;
                break;

            case "02":
                Bloqueio bloqueio = new Bloqueio();
                //02 20230619 000125 0015 000000028001 01 000025
                Console.WriteLine("------------------");

                bloqueio.Tipo = tipo;
                bloqueio.Data = registro.Substring(2, 8);
                bloqueio.Id_T = registro.Substring(10, 6);
                bloqueio.Agencia = registro.Substring(16, 4);
                bloqueio.Conta = registro.Substring(20, 12);
                bloqueio.Motivo = registro.Substring(32, 2);
                bloqueio.Id_O = registro.Substring(34);

                if (ServicosChecagem.IsValid_Bloqueio(bloqueio, data_arq))
                    Console.WriteLine("Bloqueio validow nice");
                else Console.WriteLine("nop Bloq");


                auxLinhas++;
                break;

            case "03":
                Cancelamento cancelamento = new Cancelamento();
                Console.WriteLine("------------------");

                cancelamento.Tipo = tipo;
                cancelamento.Data = registro.Substring(2, 8);
                cancelamento.Id_T = registro.Substring(10, 6);
                cancelamento.Agencia = registro.Substring(16, 4);
                cancelamento.Conta = registro.Substring(20, 12);
                cancelamento.Motivo = registro.Substring(32, 2);
                cancelamento.Id_O = registro.Substring(34);

                if (ServicosChecagem.IsValid_Cancelamento(cancelamento, data_arq))
                    Console.WriteLine("Cancelamento valida nice");
                else Console.WriteLine("nop Canc");


                auxLinhas++;
                break;

            case "99":
                Trailler trailler = new Trailler();

                trailler.Tipo = tipo;
                trailler.Data = registro.Substring(2, 8);
                trailler.Tot_Registros = registro.Substring(10);
                auxLinhas++;

                if (ServicosChecagem.IsValid_Trailler(trailler, data_arq, arqLinhas.Length, auxLinhas))
                    Console.WriteLine("Trailler valida nice");
                else Console.WriteLine("nop trailler");


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




