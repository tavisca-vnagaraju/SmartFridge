﻿namespace SmartRefridgerator
{
    public class ConfigurationManager
    {
        private IStorage _storage;

        public ConfigurationManager(IStorage storage)
        {
            this._storage = storage;
        }

        public void SetMinimumQuantity(Vegetable vegetable, int quantity)
        {
            _storage.SetVegetableMinimumQuantity(vegetable, quantity);
        }

        public int GetMinimumQuantity(Vegetable vegetable)
        {
            return _storage.GetVegetableMinimumQuantity(vegetable);
        }
    }
}
