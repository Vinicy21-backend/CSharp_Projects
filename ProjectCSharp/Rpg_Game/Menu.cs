using System;
using Rpg_Game.Classes;
using Rpg_Game.Sistemas;

namespace Rpg_Game
{
    public static class Menu
    {
        private static Personagem jogador;
        private static int faseAtual = 1;

        public static void Iniciar()
        {
            Console.WriteLine("=== MENU DO RPG ===");
            Console.WriteLine("1 - Iniciar Nova Partida");
            Console.WriteLine("2 - Carregar Jogo");
            Console.WriteLine("3 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    IniciarNovaPartida();
                    break;
                case "2":
                    CarregarJogo();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Iniciar(); // Volta ao menu
                    break;
            }
        }

        private static void IniciarNovaPartida()
        {
            Console.WriteLine("\nEscolha sua classe:");
            Console.WriteLine("1 - Guerreiro");
            Console.WriteLine("2 - Mago");
            
            string classe = Console.ReadLine();
            jogador = classe == "1" ? new Guerreiro("Herói") : new Mago("Mago");

            Console.WriteLine($"\nBem-vindo, {jogador.Nome}!");
            GerenciarFases();
        }

        private static void CarregarJogo()
        {
            Console.WriteLine("\nCarregando jogo...");
            // Lógica para carregar dados salvos (ex: faseAtual, jogador.XP, etc.)
            // Aqui você pode implementar um sistema de serialização posteriormente
            GerenciarFases();
        }

        private static void GerenciarFases()
        {
            while (faseAtual <= 3) // Supondo 3 fases
            {
                Console.WriteLine($"\n--- Fase Atual: {faseAtual} ---");
                Console.WriteLine("1 - Iniciar Fase");
                Console.WriteLine("2 - Ver Status");
                Console.WriteLine("3 - Voltar ao Menu");

                string opcaoFase = Console.ReadLine();

                switch (opcaoFase)
                {
                    case "1":
                        Fases.IniciarFase(faseAtual, jogador);
                        faseAtual++;
                        break;
                    case "2":
                        Console.WriteLine($"\nStatus de {jogador.Nome}:");
                        Console.WriteLine($"Level: {jogador.Level} | XP: {jogador.XP}");
                        Console.WriteLine($"Vida: {jogador.Vida} | Ataque: {jogador.AtaqueBase}");
                        break;
                    case "3":
                        Iniciar(); // Retorna ao menu principal
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            Console.WriteLine("\n🎉 Parabéns! Você completou todas as fases!");
            Iniciar(); // Volta ao menu após vitória
        }
    }
}