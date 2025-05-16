using System;
using System.IO;

namespace TextEditor;

class Program
{
    static void Main(string[] args)
    {
        Menu();

    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Seja bem-vindo ao editor de texto!");
        Console.WriteLine("Escolha uma das opções abaixo:");
        Console.WriteLine("1 - Abrir um arquivo");
        Console.WriteLine("2 - Editar um novo arquivo");
        Console.WriteLine("0 - Sair do Programa");

        short opcao = short.Parse(Console.ReadLine());
        switch (opcao)
        {
            case 1: Abrir(); break;
            case 2: Editar(); break;
            case 0: System.Environment.Exit(0); break;
            default: Console.WriteLine("Opção inválida!"); break;
        }

    }
    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("Digite o caminho do arquivo que deseja abrir:");
        var path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            string texto = file.ReadToEnd();
            Console.WriteLine(texto);
        }
        Console.WriteLine("");
        Console.ReadLine();
        Menu();


    }

    static void Editar()
    {
        Console.Clear();
        Console.WriteLine("Digite o texto que deseja editar:");
        Console.WriteLine("Pressione ESC para sair");
        Console.WriteLine("---------------------------------");
        string texto = "";
        do
        {
            texto += Console.ReadLine();
            texto += Environment.NewLine;
        }

        while (Console.ReadKey().Key != ConsoleKey.Escape);
        Salvar(texto);

    }
    static void Salvar(string texto)
    {
        Console.Clear();
        Console.WriteLine("Qual o Caminho do arquivo:");
        var path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.WriteLine(texto);
        }
        Console.WriteLine($"Arquivo {path} salvo com sucesso!");
        Console.ReadLine();
        Menu();
    }


}
