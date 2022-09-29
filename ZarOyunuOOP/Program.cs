namespace ZarOyunuOOP
{
    public class Combination
    {
        public string CombinationName { get; set; }
        public int Count { get; set; }
    }

    public class mainclass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zar içerikli oyunun kuralları şöyledir 1 2 3 Alt 4 5 6 Ust olarak geçer belirteceğiniz miktarda zar atılacaktır. 2 farklı oyun modu vardır.1-Amacınız ilk gelecek olan kombinasyonu doğru tahmin etmektir.örnek 'AUA'  2- Amacınız en yüksek 3 lü kombinasyonu tahmin etmektir örnek 'AUA' ");
            Console.WriteLine("Oyun Modunu Seçiniz 1- En Doğru Tahmin 2-İlk Tahmin");
            string mod = Console.ReadLine();
            if (mod.Contains("1"))
            {

                Console.WriteLine("Lütfen 1. oyuncu tahminde bulunun");
                string player1 = Console.ReadLine();
                Console.WriteLine("Lütfen 2. oyuncu tahminde bulunun");
                string player2 = Console.ReadLine();
                Console.WriteLine("Zar Miktarını giriniz");
                string numberOfDicee = Console.ReadLine();
                int numberOfDice = Convert.ToInt32(numberOfDicee);

                int player1count = 0;
                int player2count = 0;

                var DiceCombinatonCollection = CombinateCreator(numberOfDice);
                foreach (var item in DiceCombinatonCollection)
                {
                    if (item.CombinationName == player1)
                    {
                        player1count = item.Count;
                    }
                    if (item.CombinationName == player2)
                    {
                        player2count = item.Count;
                    }
                }
                Console.WriteLine(player1count > player2count ? "Kazanan 1. Oyuncu" : "Kazanan 2. Oyuncu");
            }
            else
            {
                Console.WriteLine("Lütfen 1. oyuncu tahminde bulunun");
                string player1 = Console.ReadLine();
                Console.WriteLine("Lütfen 2. oyuncu tahminde bulunun");
                string player2 = Console.ReadLine();
                Console.WriteLine("Zar Miktarını giriniz");
                string numberOfDicee = Console.ReadLine();
                int numberOfDice = Convert.ToInt32(numberOfDicee);
                var DiceCombinatonCollection = CombinateCreator(numberOfDice);
                foreach (var item in DiceCombinatonCollection)
                {
                    if (item.CombinationName == player1)
                    {
                        Console.WriteLine("Kazanan 1. oyuncu");
                        break;
                    }
                    if (item.CombinationName == player2)
                    {
                        Console.WriteLine("Kazanan 2. oyuncu");
                        break;
                    }
                }
                
            }
        }

        public static int Dice()
        {
            int diceNumber = 0;

            Random r = new Random();
            diceNumber = r.Next(1, 7);


            return diceNumber;
        }

        public static string DiceDeck(int numberOfDice)
        {
            string diceCollection = "";
            for (int i = 0; i < numberOfDice; i++)
            {

                diceCollection += Dice();

            }
            diceCollection = diceCollection.Replace('1', 'A');
            diceCollection = diceCollection.Replace('2', 'A');
            diceCollection = diceCollection.Replace('3', 'A');
            diceCollection = diceCollection.Replace('4', 'U');
            diceCollection = diceCollection.Replace('5', 'U');
            diceCollection = diceCollection.Replace('6', 'U');

            return diceCollection;
        }

        public static List<Combination> CombinateCreator(int numberOfDice)
        {

            string diceCollection = DiceDeck(numberOfDice);

            List<Combination> combinations = new();
            List<string> stringCollection = new();

            for (int i = 0; i < diceCollection.Length - 2; i++)
            {
                var combinationDice = diceCollection[i..(i + 3)];
                if (!stringCollection.Contains(combinationDice))
                {
                    int count = 0;
                    stringCollection.Add(combinationDice);

                    for (int j = 0; j < diceCollection.Length - 2; j++)
                    {
                        var stringblabla = diceCollection[j..(j + 3)];
                        if (stringblabla.Contains(combinationDice))
                            count++;
                    }
                    Combination combination = new();
                    combination = ObjectCreator(combinationDice, count);

                    combinations.Add(combination);
                }

            }
            return combinations;
        }

        public static Combination ObjectCreator(string combination, int count)
        {
            Combination combination1 = new()
            {
                CombinationName = combination,
                Count = count
            };
            return combination1;
        }
    }





}