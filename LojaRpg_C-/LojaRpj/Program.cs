//TEM QUE COLOCAR O NOME DE TODO MUNDO AQUI
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ENUM
public enum Raridade
{
    Comum,
    Raro,
    Epico,
    Lendario
}

// CLASSE BASE
public abstract class ItemRPG
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public Raridade Raridade { get; set; }

    private decimal preco;
    public decimal Preco
    {
        get => preco;
        set
        {
            if (value < 0)
                throw new Exception("Preço não pode ser negativo.");
            preco = value;
        }
    }

    private int quantidade;
    public int Quantidade
    {
        get => quantidade;
        set
        {
            if (value < 0)
                throw new Exception("Quantidade não pode ser negativa.");
            quantidade = value;
        }
    }

    public ItemRPG(int id, string nome, decimal preco, int quantidade, Raridade raridade)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
        Raridade = raridade;
    }

    public abstract string Tipo();
}

// CLASSES FILHA
public class Arma : ItemRPG
{
    public int Dano { get; set; }

    public Arma(int id, string nome, decimal preco, int quantidade, int dano, Raridade raridade)
        : base(id, nome, preco, quantidade, raridade)
    {
        Dano = dano;
    }

    public override string Tipo() => "Arma";
}

public class Pocao : ItemRPG
{
    public string Efeito { get; set; }

    public Pocao(int id, string nome, decimal preco, int quantidade, string efeito, Raridade raridade)
        : base(id, nome, preco, quantidade, raridade)
    {
        Efeito = efeito;
    }

    public override string Tipo() => "Poção";
}

public class Armadura : ItemRPG
{
    public int Defesa { get; set; }

    public Armadura(int id, string nome, decimal preco, int quantidade, int defesa, Raridade raridade)
        : base(id, nome, preco, quantidade, raridade)
    {
        Defesa = defesa;
    }

    public override string Tipo() => "Armadura";
}

// VENDA
public class Venda
{
    public int IdItem { get; set; }
    public string NomeItem { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime Data { get; set; }

    public Venda(int idItem, string nomeItem, int quantidade, decimal valorTotal)
    {
        IdItem = idItem;
        NomeItem = nomeItem;
        Quantidade = quantidade;
        ValorTotal = valorTotal;
        Data = DateTime.Now;
    }
}

// SERVICE
public class LojaService
{
    private List<ItemRPG> estoque = new List<ItemRPG>();
    private List<Venda> vendas = new List<Venda>();
    private const string Senha = "1234";

    public LojaService()
    {
        estoque.Add(new Arma(1, "Espada", 50, 10, 25, Raridade.Comum));
        estoque.Add(new Arma(2, "Espada de Diamante", 300, 2, 55, Raridade.Raro));
        estoque.Add(new Pocao(3, "Poção de Invisibilidade", 50, 10, "Invisível", Raridade.Raro));
        estoque.Add(new Pocao(4, "Poção Divina", 250, 5, "Cura total", Raridade.Epico));
        estoque.Add(new Armadura(5, "Armadura de Madeira", 100, 20, 20, Raridade.Comum));
        estoque.Add(new Armadura(6, "Armadura de Dragão", 700, 2, 80, Raridade.Lendario));
    }

    public void AdicionarItem(ItemRPG item) => estoque.Add(item);

    public void AtualizarPreco(int id, decimal novoPreco)
    {
        var item = estoque.FirstOrDefault(i => i.Id == id);
        if (item == null) throw new Exception("Item não encontrado.");
        item.Preco = novoPreco;
    }

    public void ReporEstoque(int id, int quantidade)
    {
        var item = estoque.FirstOrDefault(i => i.Id == id);
        if (item == null) throw new Exception("Item não encontrado.");
        item.Quantidade += quantidade;
    }

    // MENU ESTOQUE
    public void AcessarEstoque()
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("\n-- GESTÃO DO ESTOQUE --");
            foreach (var item in estoque)
                Console.WriteLine($"\n ID: {item.Id} | Item: {item.Nome} | Valor: {item.Preco:C}| Raridade: {item.Raridade} | Qtd: {item.Quantidade}");

            Console.WriteLine("\n1 - Cadastrar item");
            Console.WriteLine("2 - Atualizar preço");
            Console.WriteLine("3 - Repor estoque");
            Console.WriteLine("0 - Voltar");

            if (!int.TryParse(Console.ReadLine(), out opcao))
                continue;

            try
            {
                switch (opcao)
                {
                    case 1: CadastrarItemMenu(); break;
                    case 2: AtualizarPrecoMenu(); break;
                    case 3: ReporEstoqueMenu(); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        } while (opcao != 0);
    }

    private void CadastrarItemMenu()
    {
        Console.WriteLine("\n1 - Arma\n2 - Poção\n3 - Armadura");
        int tipo = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        Console.Write("Quantidade: ");
        int qtd = int.Parse(Console.ReadLine());

        int novoId = estoque.Max(i => i.Id) + 1;
        ItemRPG item;

        switch (tipo)
        {
            case 1:
                Console.Write("Dano: ");
                item = new Arma(novoId, nome, preco, qtd, int.Parse(Console.ReadLine()), Raridade.Comum);
                break;
            case 2:
                Console.Write("Efeito: ");
                item = new Pocao(novoId, nome, preco, qtd, Console.ReadLine(), Raridade.Comum);
                break;
            case 3:
                Console.Write("Defesa: ");
                item = new Armadura(novoId, nome, preco, qtd, int.Parse(Console.ReadLine()), Raridade.Comum);
                break;
            default: throw new Exception("Tipo inválido.");
        }

        AdicionarItem(item);
        Console.WriteLine("Item cadastrado!");
    }

    private void AtualizarPrecoMenu()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Novo preço: ");
        decimal novoPreco = decimal.Parse(Console.ReadLine());
        AtualizarPreco(id, novoPreco);
        Console.WriteLine("Preço atualizado com sucesso!");
    }

    private void ReporEstoqueMenu()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Quantidade: ");
        int qtd = int.Parse(Console.ReadLine());
        ReporEstoque(id, qtd);
        Console.WriteLine("Estoque atualizado!");
    }

    // VENDAS
    public void AcessarVendas()
    {
        Console.Clear();
        Console.WriteLine("\n-- BEM VINDO(A) A LOJA DA DONINHA ENCANTADA --");
        Console.WriteLine("\nDigite o nome do item ou '1' para ver nosso catálogo:");
        string entrada = Console.ReadLine();
        Console.Clear();

        var lista = entrada == "1"
            ? estoque.Where(i => i.Quantidade > 0).ToList()
            : estoque.Where(i => i.Nome.ToLower().Contains(entrada.ToLower())).ToList();

        if (!lista.Any())
            throw new Exception("Item não encontrado.");

        for (int i = 0; i < lista.Count; i++)
            Console.WriteLine($"{i + 1} - {lista[i].Nome} - {lista[i].Preco:C}");

        Console.WriteLine("\nDigite do Id do item que deseja: ");
        int id = int.Parse(Console.ReadLine());

        var item = estoque.FirstOrDefault(i => i.Id == id);
        Console.WriteLine("-- Detalhes do item: --");
        Console.WriteLine($"Item: {item.Nome} ");
        Console.WriteLine($"Tipo: {item.Tipo()}");
        Console.WriteLine($"Valor: {item.Preco:C}");

        int qtd;
        while (true)
        {
            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out qtd) || qtd <= 0 || qtd > item.Quantidade)
            {
                Console.WriteLine("Quantidade inválida.");
                continue;
            }
            break;
        }

        decimal total = qtd * item.Preco;
        Console.WriteLine($"\nTotal: {total:C}");
        Console.Write("\nConfirmar compra: (S/N): ");

        if (Console.ReadLine().ToUpper() != "S")
            return;

        item.Quantidade -= qtd;
        vendas.Add(new Venda(item.Id, item.Nome, qtd, total));
        Console.WriteLine("\nCompra realizada!");
        Console.WriteLine("1 - Menu | 0 - Sair");

        if (Console.ReadLine() == "0")
            Environment.Exit(0);
    }

    // RELATÓRIOS
    public void AcessarRelatorios()
    {
        Console.Clear();
        Console.Write("Senha: ");
        if (Console.ReadLine() != Senha) return;

        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("\n1 - Estoque");
            Console.WriteLine("2 - Vendas");
            Console.WriteLine("3 - Caixa");
            Console.WriteLine("4 - Mais Vendidos");
            Console.WriteLine("0 - Voltar");

            if (!int.TryParse(Console.ReadLine(), out op))
                continue;

            Console.Clear();

            switch (op)
            {
                case 1: RelatorioEstoque(); break;
                case 2: RelatorioVendas(); break;
                case 3: FechamentoCaixa(); break;
                case 4: ItensMaisVendidos(); break;
            }

            if (op != 0)
            {
                Console.WriteLine("\nPressione ENTER para voltar");
                Console.ReadLine();
            }
        } while (op != 0);
    }

    private void RelatorioEstoque()
    {
        var lista = estoque
            .Where(i => i.Quantidade > 0)
            .OrderByDescending(i => i.Preco)
            .ToList();

        Console.WriteLine("-- RELATÓRIO DE ESTOQUE ---");
        foreach (var i in lista)
            Console.WriteLine($" Item: {i.Nome} | Quantidade: {i.Quantidade}");
    }

    private void RelatorioVendas()
    {
        var lista = vendas.OrderByDescending(v => v.Data);

        Console.WriteLine("-- RELATÓRIO DE VENDAS --");
        if (!lista.Any())
        {
            Console.WriteLine("\nNenhuma venda foi realizada ainda.");
            return;
        }

        foreach (var v in lista)
            Console.WriteLine($"{v.NomeItem} | {v.Quantidade} | {v.ValorTotal} | {v.Data}");
    }

    private void FechamentoCaixa()
    {
        Console.WriteLine("-- FECHAMENTO DE CAIXA --");
        if (!vendas.Any())
        {
            Console.WriteLine("Nenhuma venda foi realizada ainda.");
            return;
        }

        var total = vendas.Sum(v => v.ValorTotal);
        Console.WriteLine($"\nTotal em caixa: {total:C}");
    }

    private void ItensMaisVendidos()
    {
        var ranking = vendas
            .GroupBy(v => v.NomeItem)
            .Select(grupo => new
            {
                Item = grupo.Key,
                Total = grupo.Sum(v => v.Quantidade)
            })
            .OrderByDescending(x => x.Total);

        Console.WriteLine("\n--- MAIS VENDIDOS ---");
        if (!ranking.Any())
        {
            Console.WriteLine("Nenhum item foi vendido ainda.");
            return;
        }

        foreach (var r in ranking)
            Console.WriteLine($"{r.Item} - {r.Total}");
    }
}

// MAIN
class Program
{
    static void Main()
    {
        var loja = new LojaService();
        int op;

        do
        {
            Console.Clear();
            Console.WriteLine("-- MENU --");
            Console.WriteLine("1 - Loja");
            Console.WriteLine("2 - Estoque");
            Console.WriteLine("3 - Relatórios");
            Console.WriteLine("0 - Sair");

            if (!int.TryParse(Console.ReadLine(), out op))
                continue;

            try
            {
                switch (op)
                {
                    case 1: loja.AcessarVendas(); break;
                    case 2: loja.AcessarEstoque(); break;
                    case 3: loja.AcessarRelatorios(); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.ReadLine();
            }
        } while (op != 0);
    }
}