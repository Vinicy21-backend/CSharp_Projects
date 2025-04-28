using Rpg_Game.Classes;  
using Rpg_Game.Sistemas; 
public class Batalha
{
    public static void Iniciar(Personagem jogador, Personagem inimigo)
    {
        Console.WriteLine($"--- BATALHA: {jogador.Nome} vs {inimigo.Nome} ---");
        
        while (jogador.Vida > 0 && inimigo.Vida > 0)
        {
            // Turno do jogador
            Console.WriteLine("\nSeu turno:");
            Console.WriteLine("1 - Atacar | 2 - Habilidade Especial");
            string escolha = Console.ReadLine();

            if (escolha == "1")
                jogador.Atacar(inimigo);
            else if (escolha == "2" && jogador is Guerreiro guerreiro)
                guerreiro.GolpeFulminante(inimigo);
            else if (escolha == "2" && jogador is Mago mago)
                mago.BolaDeFogo(inimigo);

            // Verifica se o inimigo morreu
            if (inimigo.Vida <= 0)
            {
                Console.WriteLine($"{inimigo.Nome} foi derrotado!");
                break;
            }

            // Turno do inimigo (ataque básico)
            Console.WriteLine("\nTurno do inimigo:");
            inimigo.Atacar(jogador);

            if (jogador.Vida <= 0)
            {
                Console.WriteLine($"{jogador.Nome} foi derrotado!");
                break;
            }
        }
    }
}