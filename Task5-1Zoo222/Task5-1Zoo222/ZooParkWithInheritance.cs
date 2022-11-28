using System;

namespace Task5_1Zoo222
{
    class ZooPark
    {
        static void Main(string[] args)
        {
            //Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            //Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            //Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");

            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "White");
            Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black", "Harpy", 98.5);

            tonyTiger.makeNoise();

            Animal baseAnimal = new Animal("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Colour");
            baseAnimal.makeNoise();

            Console.ReadLine();

            //Test eat
            tonyTiger.eat();
            baseAnimal.eat();
            williamWolf.eat();
            edgarEagle.eat();
            Console.ReadLine();

            //Test extra code
            tonyTiger.stunt();
            williamWolf.stunt();
            edgarEagle.stunt();
            edgarEagle.layEgg();
            edgarEagle.fly();
            Console.ReadLine();

            //Test sleep
            baseAnimal.sleep();
            tonyTiger.sleep();
            williamWolf.sleep();
            edgarEagle.sleep();
            tonyTiger.eat();
            Console.ReadLine();

            //Test new bird ang penguin
            Penguin Pengwing = new Penguin("Pengwing the Penguin", "Fish", "North Pole", 10.0, 10, "Black and White", "NA", 0.5);
            Pengwing.fly();
            edgarEagle.fly();
            Pengwing.layEgg();
            edgarEagle.layEgg();
            Console.ReadLine();
        }
    }
}
