using System;
using System.Collections.Generic;
using Rpg_Game.Classes;

namespace Rpg_Game.Sistemas
{
    public static class Fases
    {
        // Dados das fases: nível dos inimigos e recompensas
        private static readonly Dictionary<int, Fase> _fases = new Dictionary<int, Fase>()
        {
            { 1, new Fase(InimigoLevel: 1, XpRecompensa: 100, ItensRaros: new List<string> { "Poção de Cura", "Espada de Madeira" }) },
            { 2, new Fase(InimigoLevel: 3, XpRecompensa: 250, ItensRaros: new List<string> { "Armadura de Couro", "Pergaminho de Fogo" }) },
            { 3, new Fase(InimigoLevel: 5, XpRecompensa: 500, ItensRaros: new List<string> { "Amuleto da Vida", "Machado de Guerra" }) }
        };

        // Inicia uma fase específica
        public static void IniciarFase(int numeroFase, Personagem jogador)
        {
            if (_fases.TryGetValue(numeroFase, out Fase fase))
            {
                Console.WriteLine($"\n=== FASE {numeroFase} ===");
                Console.WriteLine($"Inimigos Nível: {fase.InimigoLevel}");

                // Simula uma batalha (pode ser substituído por Batalha.Iniciar())
                bool vitoria = SimularBatalha(jogador, fase.InimigoLevel);

                if (vitoria)
                {
                    DarRecompensa(jogador, fase);
                    Console.WriteLine($"\nVocê avançou para a próxima fase!");
                }
                else
                {
                    Console.WriteLine("Você foi derrotado... Tente novamente!");
                }
            }
            else
            {
                Console.WriteLine("Fase não encontrada!");
            }
        }

        private static bool SimularBatalha(Personagem jogador, int inimigoLevel)
        {
            // Lógica simplificada (substitua por Batalha.cs)
            Console.WriteLine($"Batalha contra inimigos nível {inimigoLevel}...");
            Random rand = new Random();
            return rand.Next(0, 2) == 1; // 50% de chance de vitória
        }

        private static void DarRecompensa(Personagem jogador, Fase fase)
        {
            jogador.XP += fase.XpRecompensa;
            Console.WriteLine($"\nVocê ganhou {fase.XpRecompensa} XP!");

            // Itens aleatórios
            if (fase.ItensRaros.Count > 0)
            {
                Random rand = new Random();
                string item = fase.ItensRaros[rand.Next(0, fase.ItensRaros.Count)];
                Console.WriteLine($"Você encontrou: {item}!");
            }
        }
    }

    // Classe auxiliar para armazenar dados da fase
    public class Fase
    {
        public int InimigoLevel { get; }
        public int XpRecompensa { get; }
        public List<string> ItensRaros { get; }

        public Fase(int InimigoLevel, int XpRecompensa, List<string> ItensRaros)
        {
            this.InimigoLevel = InimigoLevel;
            this.XpRecompensa = XpRecompensa;
            this.ItensRaros = ItensRaros;
        }
    }
}