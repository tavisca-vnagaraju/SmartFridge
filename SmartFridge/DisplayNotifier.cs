namespace SmartRefridgerator
{
    public class DisplayNotifier:INotifier
    {
        VegetableTracker _vegetableTracker;
        public DisplayNotifier(VegetableTracker vegetableTracker)
        {
            _vegetableTracker = vegetableTracker;
        }

        public string Message => "Insufficient Vegetables";

        public string NotifyUser()
        {
            var insufficientVegetableQuantity = _vegetableTracker.GetInsufficientVegetableQuantity();
            if(insufficientVegetableQuantity.Count > 0)
            {
                return Message;
            }
            return null;
        }
    }
}
