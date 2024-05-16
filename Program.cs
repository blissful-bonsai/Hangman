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
            guessLetter();
        }

        static void initializeWord()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, wordList.Length);

            fullWord = wordList[randomIndex];
            Console.WriteLine(fullWord);
            int fullWordLength = fullWord.Length;
            halfWord = new char[fullWord.Length];
        }

        static void guessLetter()
        {
            Console.WriteLine("Please, try guessing a letter: ");
            char letter = char.Parse(Console.ReadLine());

            checkLetter(fullWord, letter);
        }
        static void checkLetter(string word, char letter)
        {
            while (checkGame() != true)
            {
                for (int i = 0; i < fullWord.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        Console.WriteLine("You did it!");
                        halfWord[i] = letter;
                    }
                    else
                    {
                        limbs--;
                    }
                }
                Console.WriteLine(halfWord);
            }

        }

        static bool checkVictory()
        {
            for (int i = 0; i < halfWord.Length; i++)
            {
                if (halfWord[i] == '\0')
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkLoss()
        {
            if (limbs == 0)
            {
                Console.WriteLine("All of your limbs have been drawn using pixels, you are a goner!");
                return true;
            }
            return false;
        }

        static bool checkGame()
        {
            if (checkVictory() || checkLoss())
            {
                return true;
            }
            return false;
        }


    }
}
