using Rpg_Game.Classes;  
using Rpg_Game.Sistemas; 
public class Batalha
{
    public static bool Iniciar(Personagem jogador, Personagem inimigo)
{
    Console.WriteLine($"\n⚔️ BATALHA: {jogador.Nome} vs {inimigo.Nome}!");

    while (jogador.Vida > 0 && inimigo.Vida > 0)
    {
        // TURNO DO JOGADOR
        Console.WriteLine("\n🔵 SEU TURNO:");
        Console.WriteLine("1 - Ataque Básico");
        Console.WriteLine("2 - Habilidade Especial");
        Console.WriteLine("3 - Fugir (25% de chance)");

        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                jogador.Atacar(inimigo);
                break;
            case "2":
                if (jogador is Guerreiro guerreiro)
                    guerreiro.GolpeFulminante(inimigo);
                else if (jogador is Mago mago)
                    mago.BolaDeFogo(inimigo);
                break;
            case "3":
                if (new Random().Next(0, 4) == 0) // 25% de chance
                {
                    Console.WriteLine("Você fugiu da batalha!");
                    return false;
                }
                else
                {
                    Console.WriteLine("Falha ao fugir!");
                }
                break;
            default:
                Console.WriteLine("Opção inválida! Perdeu o turno.");
                break;
        }

        // VERIFICA SE O INIMIGO MORREU
        if (inimigo.Vida <= 0)
        {
            Console.WriteLine($"\n🎉 {inimigo.Nome} foi derrotado!");
            return true;
        }

        // TURNO DO INIMIGO (ATAQUE AUTOMÁTICO)
        Console.WriteLine($"\n🔴 TURNO DO {inimigo.Nome.ToUpper()}:");
        inimigo.Atacar(jogador); // INIMIGO SEMPRE ATACA AQUI

        // VERIFICA SE O JOGADOR MORREU
        if (jogador.Vida <= 0)
        {
            Console.WriteLine($"\n💀 {jogador.Nome} foi derrotado...");
            return false;
        }

        // MOSTRA STATUS APÓS CADA RODADA
        Console.WriteLine($"\nSTATUS: {jogador.Nome} (Vida: {jogador.Vida}) vs {inimigo.Nome} (Vida: {inimigo.Vida})");
    }
    return false;
}
    
}