using System;
using System.Collections.Generic;

namespace Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Accessories> accessories = new List<Accessories>();
            List<object> FerretWithGun = new List<object>();
            List<object> VaquitaOnLeash = new List<object>();

            animals.Add(new Pika());
            animals.Add(new Ferret());
            animals.Add(new Vaquita());

            accessories.Add(new PikaToy());
            accessories.Add(new PikaFood());
            accessories.Add(new FerretNip());
            accessories.Add(new FerretGun());
            accessories.Add(new VaquitaLeash());
            accessories.Add(new VaquitaLamp());

            FerretWithGun.Add(new Ferret());
            FerretWithGun.Add(new FerretGun());

            VaquitaOnLeash.Add(new Vaquita());
            VaquitaOnLeash.Add(new VaquitaLeash());

            foreach (Animal animal in animals)
            {
                item.Move();
                item.Speak();
            }

            foreach (Accessories accessory in accessories)
            {
                item.Use();
                item.ThrowAway();
            }
        }
    }
}
