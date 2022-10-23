namespace RPG
{
    class RPG
    {
        static void Main(string[] args)
        {
            TelaInicial();
        }

        static void TelaInicial()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao RPG\nInforme a classe que você deseja jogar");
            Console.WriteLine("1 - Guerreiro\n2 - Arqueiro\n3 - Assassino\n4 - Mago\n0 - Sair");  
            short classe = short.Parse(Console.ReadLine());
            HandleMenuOption(classe);
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1:
                    StartWithGuerreiro();
                    break;
                case 2:
                    StartWithArqueiro();
                    break;
                case 3:
                    StartWithAssassino();
                    break;
                case 4:
                    StartWithMago();
                    break;
                case 0:
                    Console.WriteLine("Saindo. Obrigado por jogar!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida\nRetornando ao Menu");
                    Main(null);
                    break;
            }
        }

        public static void IteraçãoClasses(Heroi heroi, Inimigo inimigo)
        {
            Console.Clear();
            Console.WriteLine($"Você escolheu a classe {heroi.Classe}");
            Console.WriteLine($"Seus atributos são:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Vida: {heroi.Vida}\nAtaque: {heroi.Ataque}\nChance de crítico: {heroi.ChanceCritico}");
            Console.ResetColor();
            Console.WriteLine($"Você encontrou um {inimigo.Nome}");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Os atributos do vilão são:\nVida: {inimigo.Vida}\nAtaque: {inimigo.Ataque}\nChance de crítico: {inimigo.ChanceCritico}");
            Console.ResetColor();
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.WriteLine("Batalha iniciada");
            Thread.Sleep(1000);
            Console.Clear();
            Movimento(heroi.Vida, heroi.Ataque, inimigo.Vida, inimigo.Ataque, heroi.ChanceCritico, inimigo.ChanceCritico);           

        } 
        
        public static void StartWithGuerreiro()
        {
            Thread.Sleep(500);
            var Guerreiro = new Heroi("Guerreiro", 1000, 100, 3);
            Thread.Sleep(500);
            var vilao = InvocarInimigo();
            IteraçãoClasses(Guerreiro, vilao);
        }

        public static void StartWithArqueiro()
        {
            Thread.Sleep(500);            
            var Arqueiro = new Heroi("Arqueiro", 800, 150, 6);
            Thread.Sleep(500);            
            var vilao = InvocarInimigo();
            IteraçãoClasses(Arqueiro, vilao);
        }

        public static void StartWithAssassino()
        {
            Thread.Sleep(500);
            var Assassino = new Heroi("Assassino", 600, 200, 8);
            Thread.Sleep(500);
            var vilao = InvocarInimigo();
            IteraçãoClasses(Assassino, vilao);
        }

        public static void StartWithMago()
        {
            Thread.Sleep(500);
            var Mago = new Heroi("Mago", 400, 250, 7);
            Thread.Sleep(500);
            var vilao = InvocarInimigo();            
            IteraçãoClasses(Mago, vilao);
        }

        public static Inimigo InvocarInimigo()
        {
            var Zumbi = new Inimigo("Zumbi", 500, 60, 6);
            var Esqueleto = new Inimigo("Esqueleto", 650, 40, 5);
            var Dragao = new Inimigo("Dragão", 1000, 85, 8);
            var Orc = new Inimigo("Orc", 800, 70, 8);
            var Golem = new Inimigo("Golem", 1500, 60, 9);

            var numAleatorio = new Random();
            int inimigoInvocado = numAleatorio.Next(1, 6);

            switch (inimigoInvocado)
            {
                case 1:
                    return Zumbi;
                case 2:
                    return Esqueleto;
                case 3:
                    return Dragao;
                case 4:
                    return Orc;
                case 5:
                    return Golem;
                default:
                    return InvocarInimigo();
            }
        }
        public static void Movimento(double heroiVida, double heroiAtaque, double inimigoVida, double inimigoAtaque, double heroiChanceCritico, double inimigoChanceCritico)
        {
            Thread.Sleep(500);
            Console.WriteLine("Faça um movimento:");
            Console.WriteLine("1- Atacar");
            Console.WriteLine("2- Esquivar");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: Atacar(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
                    break;
                case 2: Esquivar(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Movimento(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
                    break;
            }
        }

        public static double heroiCriticoYN(bool heroiCriticoYN, double inimigoVida, double heroiAtaque)
        {
            if (heroiCriticoYN == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você acertou um ataque crítico!");
                Console.ResetColor();
                inimigoVida = inimigoVida - (heroiAtaque *2);
                return inimigoVida;
            }
            else
            {
                inimigoVida = inimigoVida - heroiAtaque;
                return inimigoVida;
            }
        }
        public static double inimigoCriticoYN(bool inimigoCriticoYN, double heroiVida, double inimigoAtaque)
        {
            if (inimigoCriticoYN == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O inimigo acertou um ataque crítico!");
                Console.ResetColor();
                heroiVida = heroiVida - (inimigoAtaque * 2);
                return heroiVida;
            }
            else
            {
                heroiVida = heroiVida - inimigoAtaque;
                return heroiVida;
            }
        }
        
        public static void HeroiVenceu(double inimigoVida)
        {
            if (inimigoVida <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Você conseguiu derrotar o vilão\nVocê venceu");
                Console.ResetColor();
                Denovo();
            }
        }

        public static void InimigoVenceu(double heroiVida)
        {
            if (heroiVida <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Você foi derrotado\nVocê perdeu");
                Console.ResetColor();
                Denovo();
            }
        }

        public static void Atacar(double heroiVida, double heroiAtaque, double inimigoVida, double inimigoAtaque, double heroiChanceCritico, double inimigoChanceCritico)
        {
            Console.WriteLine("Você atacou o inimigo");
            Thread.Sleep(500);
            inimigoVida = heroiCriticoYN(ChanceCritico(heroiChanceCritico), inimigoVida, heroiAtaque);            
            Console.WriteLine($"O inimigo agora tem {inimigoVida} de vida");
            HeroiVenceu(inimigoVida);
            Thread.Sleep(500);
            Console.WriteLine("O inimigo atacou você");
            heroiVida = inimigoCriticoYN(ChanceCritico(inimigoChanceCritico), heroiVida, inimigoAtaque);
            Console.WriteLine($"Você agora tem {heroiVida} de vida");
            InimigoVenceu(heroiVida);
            Thread.Sleep(1000);
            Movimento(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
        }

        public static void Esquivar(double heroiVida, double heroiAtaque, double inimigoVida, double inimigoAtaque, double heroiChanceCritico, double inimigoChanceCritico)
        {
            var numAleatorio = new Random();
            int sorte = numAleatorio.Next(1, 3);

            if (sorte == 1)
            {
                Thread.Sleep(500);
                Console.WriteLine("Você conseguiu se esquivar parcialmente do ataque do inimigo");
                Console.WriteLine("Recebendo metade do dano de ataque do inimigo");
                heroiVida = inimigoCriticoYN(ChanceCritico(inimigoChanceCritico), heroiVida, inimigoAtaque);
                Console.WriteLine($"Você agora tem {heroiVida} de vida");
                    
                    if (heroiVida <= 0)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Você foi derrotado\nVocê perdeu");
                        Denovo();
                    }
                                    
                Console.WriteLine("Você conseguiu causar 20% de dano ao inimigo, num contra ataque");            
                inimigoVida = heroiCriticoYN(ChanceCritico(heroiChanceCritico), inimigoVida, heroiAtaque);
                Console.WriteLine($"O inimigo agora tem {inimigoVida} de vida");
                HeroiVenceu(inimigoVida);                    
                Thread.Sleep(500);
                Movimento(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
            }
            
            else
            {
                Console.WriteLine("Você não conseguiu esquivar do ataque do inimigo");
                Console.WriteLine("O inimigo atacou você");            
                heroiVida = inimigoCriticoYN(ChanceCritico(inimigoChanceCritico), heroiVida, inimigoAtaque);
                Console.WriteLine($"Você agora tem {heroiVida} de vida");
                InimigoVenceu(heroiVida);
                Thread.Sleep(500);
                Movimento(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
            }
        }

        public static bool ChanceCritico(double chanceCritico)
        {
            var numAleatorio = new Random();
            int sorte = numAleatorio.Next(1, 11);

            if (sorte <= chanceCritico)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
        public static void Denovo()
        {
            Console.WriteLine("Gostaria de jogar novamente?");
            Console.WriteLine("1- Sim\n2- Não");
            int opcao = int.Parse(Console.ReadLine());
            
            switch (opcao)
            {
                case 1:
                    Main(null);
                    break;
                case 2:
                    Console.WriteLine("Saindo. Obrigado por jogar!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Denovo();
                    break;
            }
        }
        
        public struct Heroi
        {
            public Heroi(string classe, double vida, double ataque, double chanceCritico)
            {
                Classe = classe;
                Vida = vida;
                Ataque = ataque;
                ChanceCritico = chanceCritico;
            }
            public string Classe { get; set; }
            public double Vida { get; set; }
            public double Ataque { get; set; }
            public double ChanceCritico { get; set; }
        }

        public struct Inimigo
        {
            public Inimigo(string nome, double vida, double ataque, double chanceCritico)
            {
                Nome = nome;
                Vida = vida;
                Ataque = ataque;
                ChanceCritico = chanceCritico;
            }
            public string Nome { get; set; }
            public double Vida { get; set; }
            public double Ataque { get; set; }
            public double ChanceCritico { get; set; }
        }
    }
}
