using System;


namespace Sistema_Bancario.classes;

public class Menu
{
    public string MenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao banco digital");
            Console.WriteLine();
            Console.WriteLine("Credito de 2x o seu Saldo");
            Console.WriteLine();
            

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("Informe a opção desejada ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar as contas criadas");
            Console.WriteLine("2 - Inserir uma nova conta");
            Console.WriteLine("3 - Transferir ");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            Console.WriteLine();

            return opcao;
        }
}
