using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            var living = "";
            var check = true;
            var age = 0;
            var answer = "";
            var number1 = 0;
            var number2 = 0;
            var stair = "x";

            while (check)
            {
                Console.WriteLine("Hur gammal är du?:");
                age = Convert.ToInt32(Console.ReadLine());     //Implementerade inte felhantering för int eftersom jag jag ej orkar hahaha
                if (age < 0 || age > 110)
                {
                    age = 0;
                    Console.WriteLine("Du är knappast så här gammal. Försök igen.");
                }
                else
                {
                    check = false;
                }

            }
            check = true;

            Console.WriteLine("Vad heter du?:");
            var name = Console.ReadLine();

            while (check)
            {
                Console.WriteLine("Lever du? (y/n)");
                living = Console.ReadLine();
                if (living == "y")
                {
                    living = "Sant";
                    check = false;
                }
                else if (living == "n")
                {
                    living = "Falskt";
                    check = false;
                }
                else
                {
                    living = "";
                    Console.WriteLine("Var vänlig skriv in en giltlig inmatning. (y/n");
                }
            }

            Console.WriteLine("Ålder: " + age + "\n" +
                "Namn: " + name + "\n"
                + "Lever? " + living);

            while (true)
            {
                Console.WriteLine("Vill du jämföra två tal och se vilket som är störst? (y/n)");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Skriv in första numret:");
                    number1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Skriv in andra numret:");
                    number2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Det största talet är: " + Math.Max(number1, number2));
                    break;
                }
                else if (answer == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Var vänlig skriv in en giltlig inmatning. (y/n \n");
                }
            }
            Console.WriteLine("Skriv in en siffra från 1-5 för att få en tur siffra.");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine(rand.Next(1, 3));
                    break;
                case 2:
                    Console.WriteLine(rand.Next(5, 10));
                    break;
                case 3:
                    Console.WriteLine(rand.Next(10, 20));
                    break;
                case 4:
                    Console.WriteLine(rand.Next(30, 50));
                    break;
                case 5:
                    Console.WriteLine(rand.Next(50, 100));
                    break;
            }

            for (int i = 0; i < Math.Max(number1, number2); i++)
            {
                Console.WriteLine(stair);
                stair += "x";
            }
        }
    }
}
