namespace SmartRefridgerator
{
    public class Refrigerator
    {
        private VegetableTray _vegetableTray ;
        private ConfigurationManager _configurationManager;
        private StorageFactory _storageFactory ;
        public Refrigerator()
        {
            _storageFactory = new StorageFactory();
            _vegetableTray = new VegetableTray();
            _configurationManager = new ConfigurationManager(_storageFactory.GetStorage("inmemory"));
        }
        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.Add(vegetable, quantity);
        }

        public void TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.TakeOut(vegetable, quantity);

            var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
        }
        public VegetableTray GetVegetableTray()
        {
            return _vegetableTray;
        }

    }
}
