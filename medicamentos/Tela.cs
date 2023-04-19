using System.Globalization;

public class Tela
{
    protected Repositorio repositorio;

     public int Quantidade
    {
        get { return repositorio.Lista.Count; }
    }
    public string[] Cabecalho {get; protected set;}

    public Tela(Repositorio repositorio) {
        this.repositorio = repositorio;
        string[] cabecalho = {"Id:"};
        Cabecalho = cabecalho;
    }
    public virtual Entidade RegistrarEntidade()
    {
        Entidade entidade = new Entidade();
        PreencherAtributos(entidade);
        return entidade;
    }

    public void MostrarEntidades()
    {
        Console.Clear();
        string cabecalho = "";
        foreach(string atributo in Cabecalho) {
        cabecalho += (atributo.PadRight(20) + "|");
        }
        Console.WriteLine(cabecalho);
        Console.WriteLine("".PadRight(cabecalho.Length, '-'));
        foreach (Entidade entidade in repositorio.Lista)
        {
            foreach(string atributo in entidade.getAtributos()) {
            Console.Write(atributo.PadRight(20) + "|");
            }
            Console.WriteLine();
        }
    }

    public void AtualizarEntidade()
    { 
        Entidade entidadeAtualizada = ValidarId();
        int id = entidadeAtualizada.Id;
        entidadeAtualizada = entidadeAtualizada.getClass();
        PreencherAtributos(entidadeAtualizada);
        repositorio.EditarRegistro(entidadeAtualizada, id);
    }

    public virtual void PreencherAtributos(Entidade entidade)
    {
        entidade.Atualizar(entidade);
        Console.WriteLine('d');
    }

    public void RemoverEntidade()
    {
        Entidade entidade = ValidarId();
        repositorio.RemoverRegistro(entidade);
    }

    public Entidade ValidarId()
    {
        Entidade amigo;
        while (true)
        {
            MostrarEntidades();
            int indice = ValidarInt("Digite o id ");
            amigo = repositorio.EncontrarRegistro(indice);
            if (amigo == null)
            {
                Console.WriteLine("O id escolhido não existe!");
                Console.ReadLine();
                continue;
            }
            return amigo;
        }
    }
    public void MostrarMenu(string[] menu)
    {
        Console.Clear();
        foreach (string opcao in menu)
        {
            Console.WriteLine(opcao);
        }

        Console.Write("Digite a opção desejada: ");
    }

    protected int ValidarInt(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string valor = Console.ReadLine();
            int numero;
            if (Int32.TryParse(valor, out numero))
            {
                return numero;
            }
            Console.WriteLine("Digite apenas um número inteiro!");
            Console.ReadLine();
        }
    }

    protected DateTime ValidarData(string mensagem)
    {
        DateTime data;
        while (true)
        {
            Console.Write(mensagem);
            string dataInput = Console.ReadLine();
            if (
                DateTime.TryParseExact(
                    dataInput,
                    "dd/MM/yyyy",
                    new CultureInfo("pt-BR"),
                    DateTimeStyles.None,
                    out data
                )
            )
            {
                return data;
            }
            else
            {
                Console.WriteLine("Digite a data no formato dd/mm/yyyy!");
                Console.ReadLine();
            }
        }
    }
}
