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
        bool vitoria = IniciarBatalha(jogador, fase.InimigoLevel); // Agora usa o combate real

        if (vitoria)
        {
            DarRecompensa(jogador, fase);
        }
        else
        {
            Console.WriteLine("Você foi derrotado... Tente novamente!");
        }
    }
}

        private static bool IniciarBatalha(Personagem jogador, int inimigoLevel)
{
    // Cria um inimigo baseado no nível da fase
    Inimigo inimigo = new Inimigo($"Inimigo Nv.{inimigoLevel}", inimigoLevel);
    Console.WriteLine($"\n💀 Um {inimigo.Nome} apareceu!");

    // Chama o sistema de batalha real
    return Batalha.Iniciar(jogador, inimigo); // Agora vai para o combate por turnos
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