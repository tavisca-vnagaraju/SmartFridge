using SmartRefridgerator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class VegetableTrayTests
    {
        [Fact]
        public void GetMinimumQuantityTest()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            Assert.Equal(2, configurationManager.GetMinimumQuantity(tomato));
        
        }
        [Fact]
        public void AddVegetableToEmptyTrayTest()
        {
            var tray = new VegetableTray();
            tray.Add(new Tomato(), 5);
            tray.Add(new Cabbage(), 5);
            var vegetableQuantity = tray.GetVegetableQuantity();
            Assert.Equal(5, vegetableQuantity[0].Value);
            
        }
        [Fact]
        public void GetInsufficientVegetablesTest()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 3);
            fridge.AddVegetable(cabbage, 1);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            var vegetableTracker = new VegetableTracker(tray, configurationManager);
            Assert.Equal(1, vegetableTracker.GetInsufficientVegetableQuantity()[0].Value);
        }
        [Fact]
        public void GetInsufficientVegetablesTesting()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(cabbage, 10);
            fridge.TakeOutVegetable(cabbage, 9);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            var vegetableTracker = new VegetableTracker(tray, configurationManager);
            Assert.Equal(1, vegetableTracker.GetInsufficientVegetableQuantity()[0].Value);
        }
        [Fact]
        public void GetInsufficientVegetablesAreZeroTesting()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(cabbage, 10);
            fridge.TakeOutVegetable(cabbage, 5);
            fridge.TakeOutVegetable(tomato, 5);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            var vegetableTracker = new VegetableTracker(tray, configurationManager);
            Assert.Equal(0, vegetableTracker.GetInsufficientVegetableQuantity().Count);
        }
        [Fact]
        public void NotNotifyingUserTesting()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(cabbage, 10);
            fridge.TakeOutVegetable(cabbage, 5);
            fridge.TakeOutVegetable(tomato, 5);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            var vegetableTracker = new VegetableTracker(tray, configurationManager);
            var notifier = new DisplayNotifier(vegetableTracker);
            

            Assert.Equal(null, notifier.NotifyUser());
        }
        [Fact]
        public void NotifyingUserTesting()
        {
            var tomato = new Tomato();
            var cabbage = new Cabbage();
            var fridge = new Refrigerator();
            fridge.AddVegetable(tomato, 5);
            fridge.AddVegetable(cabbage, 1);
            var tray = fridge.GetVegetableTray();

            var configurationManager = new ConfigurationManager(new InMemoryStorage());
            configurationManager.SetMinimumQuantity(tomato, 2);
            configurationManager.SetMinimumQuantity(cabbage, 2);

            var vegetableTracker = new VegetableTracker(tray, configurationManager);
            NotifierFactory notifierFactory = new NotifierFactory();
            INotifier notifier = notifierFactory.GetNotifierType("emailnotifier", vegetableTracker);

            Assert.Equal("Smart Fridge AlertInsufficient Vegetables", notifier.NotifyUser());
        }
    }
}
