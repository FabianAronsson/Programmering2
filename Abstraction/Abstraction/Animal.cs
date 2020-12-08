using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    abstract class Animal 
    {
        public double Height { get; set; }

        public string Color { get; set; }

        public abstract void Move();

        public abstract void Speak();
    }

    class Pika : Animal
    {
        public override void Move()
        {
            Console.WriteLine("The Pika runs around!");
        }

        public override void Speak()
        {
            Console.WriteLine("Здравствуйте, может я и не хорек, но я тоже не птица.");
        }
    }

    class Ferret : Animal
    {
        public override void Move()
        {
            Console.WriteLine("The Ferret runs around!");
        }

        public override void Speak()
        {
            Console.WriteLine("こんにちは私はフェレットです");
        }
    }
    class Vaquita : Animal
    {
        public override void Move()
        {
            Console.WriteLine("The Vaquita swims!");
        }

        public override void Speak()
        {
            Console.WriteLine("No hablas ingles!");
        }
    }
}
