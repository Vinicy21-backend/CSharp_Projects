namespace Rpg_Game.Classes{
public abstract class Personagem
{
    public string Nome {get; protected set;}
    public int Vida {get; protected set;}
    public int AtaqueBase {get; protected set;}
    public int Defesa {get; protected set;}
    public int XP { get; set; }      // Novo atributo
    public int Level { get; set; } 


    public void GanharXP(int quantidade)
        {
            XP += quantidade;
            if (XP >= Level * 100)  // Exemplo: 100 XP por nível
            {
                Level++;
                Console.WriteLine($"\n{Nome} subiu para o nível {Level}!");
            }
        }


    public Personagem(string nome, int vida, int ataque, int defesa){
        Nome = nome;
        Vida = vida;
        AtaqueBase = ataque;
        Defesa = defesa;
    }

        protected Personagem(string nome)
        {
            Nome = nome;
        }

        public void ReceberDano(int dano)//Calculo do dano recebido
    {
        int danoFinal = dano - Defesa;

        if (danoFinal > 0)
        {
            Vida -= danoFinal;

            Console.WriteLine($"{Nome} recebeu {danoFinal} de dano! Vida restante: {Vida}");
        }
        

    }

    public abstract void Atacar(Personagem alvo);

}


public class Guerreiro : Personagem
{
    public Guerreiro (string nome) : base(nome, vida : 100, ataque : 20, defesa : 10){}

    public override void Atacar(Personagem alvo)
    {
        Console.WriteLine($"{Nome} ataca com espada!");
        alvo.ReceberDano(AtaqueBase);
    }

    public void GolpeFulminante(Personagem alvo){

        Console.WriteLine($"{Nome} usa GOLPE FULMINANTE!");
        alvo.ReceberDano(AtaqueBase * 2);
    }
}


public class Mago : Personagem
{
    public int Mana { get; private set; }

    public Mago(string nome) : base(nome, vida: 70, ataque: 15, defesa: 8) 
    {
        Mana = 100;
    }

    public override void Atacar(Personagem alvo)
    {
        Console.WriteLine($"{Nome} lança um feitiço básico!");
        alvo.ReceberDano(AtaqueBase);
    }

    // Habilidade especial (gasta mana)
    public void BolaDeFogo(Personagem alvo)
    {
        if (Mana >= 30)
        {
            Console.WriteLine($"{Nome} lança BOLA DE FOGO!");
            alvo.ReceberDano(AtaqueBase * 3);
            Mana -= 30;
        }
        else
        {
            Console.WriteLine("Mana insuficiente!");
        }
    }
}

public class Inimigo : Personagem
    {
        public int Nivel { get; set; }

        public Inimigo(string nome, int nivel) : base(nome)
        {
            Nivel = nivel;
            Vida = 50 + (nivel * 10);  // Vida escala com o nível
            AtaqueBase = 8 + (nivel * 2);
        }

        public override void Atacar(Personagem alvo)
    {
        int dano = AtaqueBase - alvo.Defesa;
        if (dano > 0)
        {
            Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano!");
            alvo.ReceberDano(AtaqueBase);
        }
        else
        {
            Console.WriteLine($"{Nome} atacou, mas {alvo.Nome} defendeu!");
        }
    }
    }


    public class Orc : Inimigo
    {
        public Orc(int nivel) : base($"Orc Nv.{nivel}", nivel)
        {
            Vida += 30;
            AtaqueBase += 7;

        }
        
        public void Machadada(Personagem alvo)
        {
            Console.WriteLine($"{Nome} Machadada!");
            alvo.ReceberDano(AtaqueBase*2);

        }
    

    }

  public class Dragao : Inimigo
{
    public Dragao(int nivel) : base($"Dragão Nv.{nivel}", nivel)
    {
        Vida += 100; // Bônus de vida para chefes
        AtaqueBase += 15;
    }

    public void Baforada(Personagem alvo)
        {
            Console.WriteLine($"{Nome} Baforada de Fogo!");
            alvo.ReceberDano(AtaqueBase*2);

        }
}
}