namespace SmartRefridgerator
{
    public class EmailNotifier : INotifier,IEmailNotifier
    {
        private VegetableTracker _vegetableTracker;

        public EmailNotifier(VegetableTracker vegetableTracker)
        {
            _vegetableTracker = vegetableTracker;
        }

        public string Subject { get => "Smart Fridge Alert"; }

        public string Message => "Insufficient Vegetables";

        public string NotifyUser()
        {
            var insufficientVegetableQuantity = _vegetableTracker.GetInsufficientVegetableQuantity();
            if (insufficientVegetableQuantity.Count > 0)
            {
                return Subject+Message;
            }
            return null;
        }
    }
}