using System;

namespace SmartRefridgerator
{
    class Program
    {
        static void Main(string[] args)
        {

            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(cabbage, 1);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new FileBasedMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            Console.ReadKey();
        }
    }
}
