using System;
using System.Collections.Generic;

class Tarefa
{
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public Tarefa(string descricao)
    {
        Descricao = descricao;
        Concluida = false;
    }

    public override string ToString()
    {
        return $"{Descricao} - {(Concluida ? "Concluída" : "Pendente")}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Tarefa> tarefas = new List<Tarefa>();
        string opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Tarefas ===");
            Console.WriteLine("1. Adicionar Tarefas");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Remover Tarefa");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": // Adicionar várias tarefas
                    Console.Write("Digite as tarefas separadas por vírgulas: ");
                    string entrada = Console.ReadLine();
                    string[] novasTarefas = entrada.Split(',');

                    foreach (string descricao in novasTarefas)
                    {
                        string tarefaTrim = descricao.Trim();
                        if (!string.IsNullOrWhiteSpace(tarefaTrim))
                        {
                            tarefas.Add(new Tarefa(tarefaTrim));
                        }
                    }
                    Console.WriteLine("Tarefas adicionadas!");
                    break;

                case "2": // Listar tarefas
                    Console.WriteLine("\n=== Suas Tarefas ===");
                    if (tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa adicionada.");
                    }
                    else
                    {
                        for (int i = 0; i < tarefas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tarefas[i]}");
                        }
                    }
                    break;

                case "3": // Marcar tarefa como concluída
                    Console.WriteLine("\n=== Marcar Tarefa como Concluída ===");
                    if (tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa para marcar.");
                    }
                    else
                    {
                        for (int i = 0; i < tarefas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tarefas[i]}");
                        }

                        Console.Write("Digite o número da tarefa para marcar como concluída: ");
                        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tarefas.Count)
                        {
                            tarefas[index - 1].Concluida = true;
                            Console.WriteLine("Tarefa marcada como concluída!");
                        }
                        else
                        {
                            Console.WriteLine("Número inválido.");
                        }
                    }
                    break;

                case "4": // Remover tarefa
                    Console.WriteLine("\n=== Remover Tarefa ===");
                    if (tarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa para remover.");
                    }
                    else
                    {
                        for (int i = 0; i < tarefas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tarefas[i]}");
                        }

                        Console.Write("Digite o número da tarefa para remover: ");
                        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tarefas.Count)
                        {
                            tarefas.RemoveAt(index - 1);
                            Console.WriteLine("Tarefa removida!");
                        }
                        else
                        {
                            Console.WriteLine("Número inválido.");
                        }
                    }
                    break;

                case "0": // Sair
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();

        } while (opcao != "0");
    }
}