using System;                     // Importa funcionalidades básicas do sistema, como Console
using System.Collections.Generic; // Importa a classe List<T> para trabalhar com listas

class Program
{
    // Classe Produto representa o objeto que vamos manipular no CRUD
    public class Produto
    {
        public int Id { get; set; } = 0;              // Identificador único do produto
        public string Nome { get; set; } = string.Empty; // Nome do produto (inicializado para evitar nulo)
        public double Preco { get; set; } = 0.0;      // Preço do produto
    }

    // Lista que simula um banco de dados em memória
    static List<Produto> produtos = new List<Produto>();
    // Contador para gerar IDs automáticos
    static int contadorId = 1;

    static void Main(string[] args)
    {
        int opcao; // Variável para armazenar a escolha do usuário
        do
        {
            // Menu principal
            Console.WriteLine("\n=== CRUD de Produtos ===");
            Console.WriteLine("1 - Criar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Atualizar Produto");
            Console.WriteLine("4 - Deletar Produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            // Lê a entrada do usuário e valida se é um número
            string? entradaOpcao = Console.ReadLine();
            if (!int.TryParse(entradaOpcao, out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue; // Volta para o menu
            }

            // Executa a ação escolhida
            switch (opcao)
            {
                case 1:
                    CriarProduto();
                    break;
                case 2:
                    ListarProdutos();
                    break;
                case 3:
                    AtualizarProduto();
                    break;
                case 4:
                    DeletarProduto();
                    break;
            }
        } while (opcao != 0); // Continua até o usuário escolher sair
    }

    // Função para criar um novo produto
    static void CriarProduto()
    {
        Console.Write("Digite o nome do produto: ");
        string? nome = Console.ReadLine(); // Lê o nome
        if (string.IsNullOrWhiteSpace(nome)) // Valida se não está vazio
        {
            Console.WriteLine("Nome inválido!");
            return;
        }

        Console.Write("Digite o preço do produto: ");
        string? entradaPreco = Console.ReadLine(); // Lê o preço
        if (!double.TryParse(entradaPreco, out double preco)) // Valida se é número
        {
            Console.WriteLine("Preço inválido!");
            return;
        }

        // Cria o objeto Produto e adiciona na lista
        Produto novo = new Produto { Id = contadorId++, Nome = nome, Preco = preco };
        produtos.Add(novo);

        Console.WriteLine("Produto criado com sucesso!");
    }

    // Função para listar todos os produtos
    static void ListarProdutos()
    {
        Console.WriteLine("\n--- Lista de Produtos ---");
        if (produtos.Count == 0) // Se não houver produtos
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        // Percorre a lista e mostra cada produto
        foreach (var p in produtos)
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco}");
        }
    }

    // Função para atualizar um produto existente
    static void AtualizarProduto()
    {
        Console.Write("Digite o ID do produto que deseja atualizar: ");
        string? entradaId = Console.ReadLine();
        if (!int.TryParse(entradaId, out int id)) // Valida se é número
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        // Busca o produto pelo ID
        Produto? produto = produtos.Find(p => p.Id == id);
        if (produto != null)
        {
            Console.Write("Novo nome: ");
            string? novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome)) // Atualiza se não for vazio
                produto.Nome = novoNome;

            Console.Write("Novo preço: ");
            string? entradaPreco = Console.ReadLine();
            if (double.TryParse(entradaPreco, out double novoPreco)) // Atualiza se válido
                produto.Preco = novoPreco;

            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    // Função para deletar um produto
    static void DeletarProduto()
    {
        Console.Write("Digite o ID do produto que deseja deletar: ");
        string? entradaId = Console.ReadLine();
        if (!int.TryParse(entradaId, out int id)) // Valida se é número
        {
            Console.WriteLine("ID inválido!");
            return;
        }

        // Busca o produto pelo ID
        Produto? produto = produtos.Find(p => p.Id == id);
        if (produto != null)
        {
            produtos.Remove(produto); // Remove da lista
            Console.WriteLine("Produto deletado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }
}
