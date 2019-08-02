using System.Collections.Generic;

namespace SmartRefridgerator
{
    public class VegetableTracker
    {
        private VegetableTray _vegetableTray;
        private ConfigurationManager _configurationManager;
        public VegetableTracker(VegetableTray vegetableTray,ConfigurationManager configurationManager)
        {
            _vegetableTray = vegetableTray;
            _configurationManager = configurationManager;
        }
        public List<KeyValuePair<Vegetable, int>> GetInsufficientVegetableQuantity()
        {
           var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
           var insufficientVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
           foreach(var item in vegetableQuantity)
           {
               var mininum =  _configurationManager.GetMinimumQuantity(item.Key);
               if(mininum > item.Value)
               {
                    insufficientVegetableQuantity.Add(item);
               }
           }
           return insufficientVegetableQuantity;
        }
    }
}
