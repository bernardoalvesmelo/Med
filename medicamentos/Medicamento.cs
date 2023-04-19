using System.Collections;

public class Medicamento : Entidade
{
    static private int id = 0;

    public string Nome{ get; set; }

    public string Descricao { get; set; }
    public int Quantidade { get; set; }

    public ArrayList Requisicoes { get; set; }
    public int Limite { get; set; }
    public Fornecedor MedicamentoFornecedor { get; set; }

    public Medicamento()
    {
        obterId(ref id);
    }

     public override string[] getAtributos() {
        string[] atributos = {(Id + ""), Nome, Descricao, (Quantidade + ""),(Requisicoes.Count + ""),
        MedicamentoFornecedor.Nome};
        return atributos;
    }

    public override void Atualizar(Entidade entidade) {
        Medicamento medicamento = (Medicamento) entidade;
        Nome = medicamento.Nome;
        Descricao = medicamento.Descricao;
        Limite = medicamento.Limite;
        MedicamentoFornecedor = medicamento.MedicamentoFornecedor;
    }

     public override Entidade getClass() {
        return new Medicamento();
    }

}
