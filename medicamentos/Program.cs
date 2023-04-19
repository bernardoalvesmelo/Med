public class Program
{
    static public void Main(string[] args)
    {
        Repositorio repositorioPaciente = new Repositorio();
        TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);

        bool continuar = true;
        string[] opcoes =
        {
            "Bem Vindo ao Clube da Leitura!",
            "0-Sair",
            "1-Cadastrar Caixa",
            "2-Cadastrar Revista",
            "3-Cadastrar Amigo",
            "4-Cadastrar Empréstimo"
        };
        while (continuar)
        {
            MostrarMenu(opcoes);
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "0":
                    continuar = false;
                    break;
                case "1":
                    telaPaciente.Opcoes();
                    break;
                case "2":
                    telaPaciente.Opcoes();
                    break;
                case "3":
                    telaPaciente.Opcoes();
                    break;
                case "4":
                    telaPaciente.Opcoes();
                    break;
                default:
                    Console.WriteLine("Opção não encontrada!");
                    Console.ReadLine();
                    continue;
            }
        }
    }

    static void MostrarMenu(string[] menu)
    {
        Console.Clear();
        foreach (string opcao in menu)
        {
            Console.WriteLine(opcao);
        }

        Console.Write("Digite a opção desejada: ");
    }
}
