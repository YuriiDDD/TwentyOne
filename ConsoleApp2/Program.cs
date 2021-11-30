using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    //Карта
    public class Card
    {
        public Card(string name, int value, CardType type)
            => (Name, Value, Type) = (name, value, type);

        public string Name { get; init; }
        public int Value { get; init; }
        public CardType Type { get; init; }
    }
    //Типы карт
    public enum CardType
    {
        Number,
        Valet,
        Dama,
        Korol,
        Tuz
    }

    //Колода
    public class Deck
    {
        private readonly List<Card> cards = new();
        public Deck() => GenerateCards();
        //Взятка карты случайным образом
        public Card Take()
        {
            if (IsEmpty) return null;
            var card = cards[new Random().Next(cards.Count)];
            cards.Remove(card);

            return card;
        }
        //Отсутствие карт в колоде
        public bool IsEmpty => !cards.Any();
        //Количество карт в колоде

        
        public int Count => cards.Count;
        //Генерация колоды, все карты по порядку для каждой масти
        private void GenerateCards()
        {
            foreach (var type in Enum.GetValues<CardType>())
            {
                if (type is CardType.Number)
                {
                    for (int i = 6; i <= 10; i++)
                    {
                        cards.AddRange(CreateCardsByType(type, i));
                    }
                }
                else
                {
                    cards.AddRange(CreateCardsByType(type));
                }
            }
        }
        //Создание карт по типу
        private IEnumerable<Card> CreateCardsByType(CardType type, int value = 0)
        {
            List<Card> result = new();

            for (int i = 0; i < 4; i++)
            {
                Card card = type switch
                {
                    CardType.Number => new($"{value}", value, type),
                    CardType.Valet => new($"Валет", 2, type),
                    CardType.Dama => new($"Дама", 3, type),
                    CardType.Korol => new($"Король", 4, type),
                    CardType.Tuz => new($"Туз", 11, type),
                };

                result.Add(card);
            }

            return result;
        }
    }
   
    
    
    
    
    // Игрок
    public class Player
    {
        private Deck deck; // Колода игрока
        private List<Card> cards = new();

        public Player(string name, Deck deck, bool cpu)
            => (Name, this.deck, CPU) = (name, deck, cpu);
        //Имя игрока
        public string Name { get; init; }
        // Кто управляет игроком машина или человек
        public bool CPU { get; init; }
       //Счет игрока
        public int Score { get; private set; }
        
        public int Cards => cards.Count; // Количество карт
        public bool IsLost => Score > 21; // Проиграл >21
        public bool IsWin => Score == 21; // Выиграл досрочно

        public bool IsStop = false;  //Стоп брать карту

        //Взятка
        public string Take()
        {
           
            var card = deck.Take();
            cards.Add(card);
            Score += card.Value;
            if (IsLost) return "Продул";
            if (IsWin) return "Победа !!!!!!!!!!!!!!!";
            return "В игре";
        }
        //Сброс
        public void Reset()
        {
            Score = 0;
            cards.Clear();
        }
        //Брать карту или нет для CPU случайное решение
        //Или кто первый начинает
        public static bool Desicion()
        {
            bool result = false;
            if (new Random().Next(0, 100) > 50) result = true;
            return result;
        }
    }
    //Игра
    public class Game
    {
        private Deck deck = new();
        private Player[] players;

        public Game()
        {

            players = new[]
            {
             new Player("CPU", deck,true),
             new Player("Игрок", deck, false)
           };

            Start();
        }

        public bool IsEnded { get; private set; }

        public void Start()
        {
            bool replay = true;
           
            
            while (replay)
            {
               // Console.Clear();
                Turn();
                
                IsEnded = players.Any(x => x.IsLost)| players.Any(x => x.IsWin)|players.Any(x=>x.IsStop);

                Console.ReadLine();

                if (IsEnded)
                    replay = Replay();
            }
        }

        private void TurnCPU()
        {
            if (!(players[1].IsLost | players[1].IsWin))
            {

                var player = players[0];
                // Берет карты пока не откажется
                while (true)
                { //Брать не брать карту
                    if (player.Score >= 17)

                        if (!Player.Desicion())
                        {
                            player.IsStop = true;
                            break;
                        }
                    if (player.IsWin | player.IsLost) break;
                    var status = player.Take();// Статус игрока
                    Console.WriteLine($"У {player.Name} {player.Score}, он {status}");
                   
                   
                   
                }
            }
        }

        private void TurnMan()
        {
            if (!(players[0].IsLost | players[0].IsWin | players[0].IsStop))
            {
                var player = players[1];
                // Берет карты пока не откажется
                while (true)
                {
                    var status = player.Take();// Статус игрока
                    Console.WriteLine($"У {player.Name} {player.Score}, он {status}");
                    if (player.IsWin | player.IsLost) break;
                    Console.Write("Еще карту ? (y/n): ");
                   
                    if (Console.ReadLine() is "n")
                    {
                        player.IsStop = true;
                        break;
                    } 
                        
                        

                }
            }

        }

        private void Turn()
        {
            if (Player.Desicion())
            {
                TurnCPU();
                TurnMan();
            }
            else
            {
                TurnMan();
                TurnCPU();
            }
            
            
            //foreach (var player in players)
            //{

            //    // Берет карты пока не откажется
            //    while (true)
            //    {
            //        var status = player.Take();// Статус игрока
            //        Console.WriteLine($"У {player.Name} {player.Score}, он {status}");
            //        if (player.IsWin | player.IsLost) break; 
                   
                    
            //        Console.Write("Еще карту ? (y/n): ");
            //        var value = Console.ReadLine();

            //        if (value is "n") break;

            //    }

            //    if (player.IsWin | player.IsLost) break; 
               
            //}
        }

        //Повтор розыграша
        private bool Replay()
        {
            bool result = false;

            while (true)
            {
              //  Console.Clear();
                Console.Write("Повторить? (y/n): ");
                var value = Console.ReadLine();

                if (value is "y" or "n")
                {
                    result = value is "y";
                    break;
                }
            }

            if (result)
            {
                Reset();
            }

            return result;
        }

        private void Reset()
        {
            deck = new();
            foreach (var player in players)
            {
                player.Reset();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Начало
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Game NewGame = new Game();

            Console.ReadKey();
        }
    }
}
