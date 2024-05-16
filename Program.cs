namespace MyConsoleApp
{
    class Program
    {
        static string[] wordList = {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "AÇAÍ",
                "ARAÇA",
                "ABACATE",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJÁ",
                "CAJÚ",
                "CARAMBOLA",
                "CUPUAÇU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MAÇÃ",
                "MANGABA",
                "MANGA",
                "MARACUJÁ",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };
        static string fullWord;
        static char[] halfWord;
        static string emptyWord = "";
        // Head, left arm, right arm, torso, left leg, right leg, 
        static int limbs = 5;
        static void Main(string[] args)
        {
            initializeWord();
            guessWord();
        }

        static void initializeWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, wordList.Length);
            fullWord = wordList[randomIndex];
            Console.WriteLine(fullWord);
            int fullWordLength = fullWord.Length;
            halfWord = new char[fullWord.Length];
            for (int i = 0; i < halfWord.Length; i++)
            {
                halfWord[i] = '_'; // Initialize with underscores
            }
            Console.WriteLine(halfWord);
        }

        static void guessWord()
        {
            // While player has limbs or checkVictory is false
            while (limbs != 0 && checkVictory() != true)
            {
                guessChar();
            }
        }

        static void guessChar()
        {
            int correctGuesses = 0;
            Console.WriteLine($"You have {limbs} limbs left");
            Console.WriteLine($"You have guessed {correctGuesses} letters already!");
            Console.WriteLine("What letter do you want to try?: ");
            char letter = char.Parse(Console.ReadLine());
            if (fullWord.Contains(letter) == false)
            {
                limbs--;
                if (limbs == 0)
                {
                    Console.WriteLine("You lost!");
                }
            }
            else
            {
                for (int i = 0; i < fullWord.Length; i++)
                {
                    if (fullWord[i] == letter)
                    {
                        halfWord[i] = letter;
                        Console.WriteLine(halfWord);
                    }
                }
            }
        }

        static bool checkVictory()
        {
            return fullWord.Equals(new string(halfWord));
        }

    }
}
