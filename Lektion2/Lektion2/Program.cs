using System;

namespace Lektion2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine((inputs[0] - inputs[1]).ToString() + (inputs[0] + inputs[1]).ToString());
        }
    }
}
