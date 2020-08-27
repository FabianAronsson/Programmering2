using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var living = "";
            var check = true;
            var age = 0;
            var answer = "";
            var number1 = 0;
            var number2 = 0;

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
                    Environment.Exit(0);
                }
                else if (answer == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Var vänlig skriv in en giltlig inmatning. (y/n \n");
                }
            }
        }
    }
}
