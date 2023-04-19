using System;
using System.Collections;

public class TelaRevista : Tela
{
    private TelaFornecedor telaFornecedor;
   

    public TelaRevista(Repositorio repositorio, TelaFornecedor telaFornecedor) : base(repositorio)
    {
        string[] cabecalho = {"Id:","Nome:","Descrição:","Quantidade",
        "Requisições:","Limite:","Fornecedor"};
        Cabecalho = cabecalho;
        this.telaFornecedor = telaFornecedor;
    }

    public void Opcoes()
    {
        string[] opcoes =
        {
            "Tela Fornecedor",
            "0-Sair",
            "1-Registrar Fornecedor",
            "2-Mostrar Fornecedores",
            "3-Atualizar Revistas",
            "4-Remover Revista"
        };
        while (true)
        {
            MostrarMenu(opcoes);
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "0":
                    return;
                case "1":
                    if (telaCaixa.Quantidade > 0)
                    {
                        repositorio.InserirRegistro(RegistrarEntidade());
                        Console.WriteLine("Revista registrada!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Não existe caixas registradas no sistema!");
                        Console.ReadLine();
                    }
                    break;
                case "2":
                    MostrarEntidades();
                    Console.ReadLine();
                    break;
                case "3":
                    if (repositorio.Lista.Count > 0)
                    {
                        if (telaCaixa.Quantidade> 0)
                        {
                            AtualizarEntidade();
                            Console.WriteLine("Revista atualizada!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Não existe caixas registradas no sistema!");
                            Console.ReadLine();
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Não existe revistas registradas no sistema!");
                        Console.ReadLine();
                    }
                    break;
                case "4":
                    if (repositorio.Lista.Count > 0)
                    {
                        RemoverEntidade();
                        Console.WriteLine("Revista removida!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Não existe revistas registradas no sistema!");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Opção não encontrada!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public override Entidade RegistrarEntidade()
    {
        Revista revista = new Revista();
        PreencherAtributos(revista);
        return revista;
    }

    public override void PreencherAtributos(Entidade entidade)
    {
        Revista revista = (Revista) entidade;
        Caixa caixa = (Caixa)telaCaixa.ValidarId();
        revista.CaixaRevista = caixa;
        Console.Write("Digite a coleção da revista: ");
        string colecao = Console.ReadLine();
        revista.Colecao = colecao;
        int numero = ValidarInt("Digite o número da edição da revista: ");
        int ano = ValidarInt("Digite o ano da revista: ");
        revista.Ano = ano;
    }


}
