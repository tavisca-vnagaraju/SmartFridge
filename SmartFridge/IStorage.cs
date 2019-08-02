﻿namespace SmartRefridgerator
{
    public interface IStorage
    {
        void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity);

        int GetVegetableMinimumQuantity(Vegetable vegetable);
    }
}
