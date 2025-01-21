using System;

namespace Calculadora
{
    internal class Program
    {
        public class Operacoes
        {
            public (int, int) PerguntasDoisNumeros()
            {
                Console.WriteLine("Digite o primeiro número:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o segundo número:");
                int num2 = int.Parse(Console.ReadLine());

                return (num1, num2); // Retorna os dois números
            }

            // Método para operações que pedem um número
            public int PerguntaUmNumero()
            {
                Console.WriteLine("Digite um número:");
                return int.Parse(Console.ReadLine());
            }
        }

        public static void Main(string[] args)
        {
            Operacoes operacoes = new Operacoes(); 
            int i = 0;

            while (i == 0)
            {
                Console.WriteLine("Qual operação deseja fazer?");
                Console.WriteLine("1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Raiz Quadrada");
                Console.WriteLine("6 - Sair\n");

                int operacao = int.Parse(Console.ReadLine());
                if (operacao == 6)
                {
                    Console.WriteLine("Saindo da calculadora...");
                    break;
                }

                int resultado;
                int num1, num2;

                switch (operacao)
                {
                    case 1:
                        (num1, num2) = operacoes.PerguntasDoisNumeros(); 
                        resultado = num1 + num2;
                        Console.WriteLine($"O resultado de {num1} + {num2} é {resultado}");
                        break;

                    case 2:
                        (num1, num2) = operacoes.PerguntasDoisNumeros();
                        resultado = num1 - num2;
                        Console.WriteLine($"O resultado de {num1} - {num2} é {resultado}");
                        break;

                    case 3:
                        (num1, num2) = operacoes.PerguntasDoisNumeros();
                        resultado = num1 * num2;
                        Console.WriteLine($"O resultado de {num1} * {num2} é {resultado}");
                        break;

                    case 4:
                        (num1, num2) = operacoes.PerguntasDoisNumeros();
                        if (num2 == 0)
                        {
                            Console.WriteLine("Não é possível dividir por zero.");
                        }
                        else
                        {
                            resultado = num1 / num2;
                            Console.WriteLine($"O resultado de {num1} / {num2} é {resultado}");
                        }
                        break;


                        case 5: // Raiz Quadrada
                        num1 = operacoes.PerguntaUmNumero();
                        if (num1 < 0)
                        {
                            Console.WriteLine("Não é possível calcular a raiz quadrada de um número negativo.");
                        }
                        else
                        {
                            double raiz = Math.Sqrt(num1); // Usando Math.Sqrt para calcular a raiz quadrada
                            Console.WriteLine($"A raiz quadrada de {num1} é {raiz}");
                        }
                        break;

                    default:
                        Console.WriteLine("Operação inválida.");
                        break;
                }
            }
        }
    }
}
