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

        public static void StartWithGuerreiro()
        {
            Thread.Sleep(500);
            Console.WriteLine("Você escolheu a classe Guerreiro");
            var Guerreiro = new Heroi("Guerreiro", 1000, 100, 3);
            Thread.Sleep(500);
            Console.WriteLine($"Seus atributos são:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Vida: {Guerreiro.Vida}\nAtaque: {Guerreiro.Ataque}\nChance de crítico: {Guerreiro.ChanceCritico}");
            Console.ResetColor();
            var vilao = InvocarInimigo();
            Thread.Sleep(500);
            Console.WriteLine($"Você encontrou um {vilao.Nome}");
            Thread.Sleep(500);
            Console.WriteLine($"Os atributos do vilão são:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Vida: {vilao.Vida}\nAtaque: {vilao.Ataque}\nChance de crítico: {vilao.ChanceCritico}");
            Console.ResetColor();
            Thread.Sleep(2000);
            Batalha(Guerreiro, vilao);
        }

        public static void StartWithArqueiro()
        {
            Thread.Sleep(500);            
            Console.WriteLine("Você escolheu a classe Arqueiro");
            var Arqueiro = new Heroi("Arqueiro", 800, 150, 6);
            Thread.Sleep(500);
            Console.WriteLine($"Seus atributos são:\nVida: {Arqueiro.Vida}\nAtaque: {Arqueiro.Ataque}\nChance de crítico: {Arqueiro.ChanceCritico}");
            var vilao = InvocarInimigo();
            Thread.Sleep(500);
            Console.WriteLine($"Você encontrou um {vilao.Nome}");
            Thread.Sleep(500);
            Console.WriteLine($"Os atributos do vilão são:\nVida: {vilao.Vida}\nAtaque: {vilao.Ataque}\nChance de crítico: {vilao.ChanceCritico}");
            Batalha(Arqueiro, vilao);
        }

        public static void StartWithAssassino()
        {
            Thread.Sleep(500);
            Console.WriteLine("Você escolheu a classe Assassino");
            var Assassino = new Heroi("Assassino", 600, 200, 8);
            Thread.Sleep(500);
            Console.WriteLine($"Seus atributos são:\nVida: {Assassino.Vida}\nAtaque: {Assassino.Ataque}\nChance de crítico: {Assassino.ChanceCritico}");
            var vilao = InvocarInimigo();
            Thread.Sleep(500);
            Console.WriteLine($"Você encontrou um {vilao.Nome}");
            Thread.Sleep(500);
            Console.WriteLine($"Os atributos do vilão são:\nVida: {vilao.Vida}\nAtaque: {vilao.Ataque}\nChance de crítico: {vilao.ChanceCritico}");
            Batalha(Assassino, vilao);
        }

        public static void StartWithMago()
        {
            Thread.Sleep(500);
            Console.WriteLine("Você escolheu a classe Mago");
            var Mago = new Heroi("Mago", 400, 250, 7);
            Thread.Sleep(500);
            Console.WriteLine($"Seus atributos são:\nVida: {Mago.Vida}\nAtaque: {Mago.Ataque}\nChance de crítico: {Mago.ChanceCritico}");
            var vilao = InvocarInimigo();
            Thread.Sleep(500);
            Console.WriteLine($"Você encontrou um {vilao.Nome}");
            Thread.Sleep(500);
            Console.WriteLine($"Os atributos do vilão são:\nVida: {vilao.Vida}\nAtaque: {vilao.Ataque}\nChance de crítico: {vilao.ChanceCritico}");
            Batalha(Mago, vilao);
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

        public static void Batalha(Heroi heroi, Inimigo inimigo)
        {
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            Console.WriteLine("Batalha iniciada");
            Thread.Sleep(1000);
            Console.Clear();
            Movimento(heroi.Vida, heroi.Ataque, inimigo.Vida, inimigo.Ataque, heroi.ChanceCritico, inimigo.ChanceCritico);           
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

        public static void Atacar(double heroiVida, double heroiAtaque, double inimigoVida, double inimigoAtaque, double heroiChanceCritico, double inimigoChanceCritico)
        {
            Console.WriteLine("Você atacou o inimigo");
            
            bool heroiCriticoYN = ChanceCritico(heroiChanceCritico);
            
            if (heroiCriticoYN == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Você acertou um ataque crítico");
                Console.ResetColor();
                inimigoVida = inimigoVida - (heroiAtaque *2);
            }
            
            else
            {
                inimigoVida = inimigoVida - heroiAtaque;
            }
            
            Console.WriteLine($"O inimigo agora tem {inimigoVida} de vida");
                
                if (inimigoVida <= 0)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Você conseguiu derrotar o vilão\nVocê venceu");
                    Denovo();
                }

            Console.WriteLine("O inimigo atacou você");
            
            bool inimigoCriticoYN = ChanceCritico(inimigoChanceCritico);

            if (inimigoCriticoYN == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("O inimigo acertou um ataque crítico");
                Console.ResetColor();
                heroiVida = heroiVida - (inimigoAtaque * 2);
            }

            else
            {
                heroiVida = heroiVida - inimigoAtaque;
            }
            
            Console.WriteLine($"Você agora tem {heroiVida} de vida");
                
                if (heroiVida <= 0)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Você foi derrotado\nVocê perdeu");
                    Denovo();
                }

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
                
                bool inimigoCriticoYN = ChanceCritico(inimigoChanceCritico);
                
                if (inimigoCriticoYN == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("O inimigo acertou um ataque crítico");
                    Console.ResetColor();
                    heroiVida = heroiVida - (inimigoAtaque);
                }

                else
                {
                    heroiVida = heroiVida - (inimigoAtaque / 2);
                }

                Console.WriteLine("E causando 20% de dano ao inimigo, num contra ataque");
                
                bool criticoYN = ChanceCritico(heroiChanceCritico);

                if (criticoYN == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Você acertou um ataque crítico");
                    Console.ResetColor();
                    inimigoVida = inimigoVida - ((heroiAtaque * 2) * 0.2);
                }
                
                else
                {
                    inimigoVida = inimigoVida - (heroiAtaque * 0.2);
                }

                Console.WriteLine($"Você agora tem {heroiVida} de vida");
                Console.WriteLine($"O inimigo agora tem {inimigoVida} de vida");
                    
                    if (heroiVida <= 0)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Você foi derrotado\nVocê perdeu");
                        Denovo();
                    }
                    
                    if (inimigoVida <= 0)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Você conseguiu derrotar o vilão\nVocê venceu");
                        Denovo();
                    }
                Thread.Sleep(500);
                Movimento(heroiVida, heroiAtaque, inimigoVida, inimigoAtaque, heroiChanceCritico, inimigoChanceCritico);
            }
            
            else
            {
                Console.WriteLine("Você não conseguiu esquivar do ataque do inimigo");
                Console.WriteLine("O inimigo atacou você");
            
                bool inimigoCriticoYN = ChanceCritico(inimigoChanceCritico);
                
                if (inimigoCriticoYN == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("O inimigo acertou um ataque crítico");
                    Console.ResetColor();
                    heroiVida = heroiVida - (inimigoAtaque * 2);
                }

                else
                {
                    heroiVida = heroiVida - inimigoAtaque;
                }


                Console.WriteLine($"Você agora tem {heroiVida} de vida");
                    
                    if (heroiVida <= 0)
                    {
                        Console.WriteLine("Você foi derrotado\n Você perdeu");
                        Denovo();
                    }
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
