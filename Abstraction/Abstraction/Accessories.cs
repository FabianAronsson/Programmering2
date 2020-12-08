using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    abstract class Accessories
    {
        public string Material { get; set; }

        public double Sturdiness { get; set; }

        public abstract void Use();

        public abstract void ThrowAway();
    }

    class PikaFood : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("Еду выбросили в мусорное ведро.");
        }

        public override void Use()
        {
            Console.WriteLine("Пища была размещена для пищухи.");
        }
    }

    class PikaToy : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("Мрачная трещина была брошена.");
        }

        public override void Use()
        {
            Console.WriteLine("ИГРУШКА БРОСАЛА СВЯТОЕ ДЕРЬМО. Пика быть сумасшедшим");
        }
    }

    class FerretGun : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("銃は捨てられました。悲しいフェレットの音。");
        }

        public override void Use()
        {
            Console.WriteLine("フェレットの足に銃を置いた。バンザイ!!!!");
        }
    }

    class FerretNip : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("フェレットニップは、スパイクされた薬などの状況のた​​めに捨てられました。");
        }

        public override void Use()
        {
            Console.WriteLine("フェレットさんはツルのように高いです。");
        }
    }

    class VaquitaLeash : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("The leash was thrashed.");
        }

        public override void Use()
        {
            Console.WriteLine("The freaking Vaquita was put on a leash. How the heck?");
        }
    }

    class VaquitaLamp : Accessories
    {
        public override void ThrowAway()
        {
            Console.WriteLine("The lamp was thrown away. ok");
        }

        public override void Use()
        {
            Console.WriteLine("A lamp was mounted on the Vaquita. Beware.");
        }
    }
}
