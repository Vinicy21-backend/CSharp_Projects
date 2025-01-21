using System;
using Sistema_Bancario.Classes;
using System.Collections.Generic;
using System.ComponentModel.Design;


namespace Sistema_Bancario
{

    class Program
    {
        static List<Conta> listaConta = new List<Conta>();
        static void Main(string[] args)
        {
            Menu menu = new Menu();
           
            string opcaoUsuario = menu.MenuPrincipal();
            

            while (opcaoUsuario.ToUpper() != "X")
             {
                
                switch (opcaoUsuario)
                {
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                      
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        throw new InvalidOperationException("Invalid");
                        break;
                }

                opcaoUsuario = menu.MenuPrincipal();
                
            }
            Console.WriteLine("Obrigado por utilizar nosso sistema!");
            Console.ReadKey();

        }

        private static string Menu()
        {
            throw new NotImplementedException();
        }

        
    }
}