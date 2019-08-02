using System;

namespace SmartRefridgerator
{
    public class NotifierFactory
    {
        public INotifier GetNotifierType(string notifierType,VegetableTracker vegetableTracker)
        {
            switch (notifierType.ToLowerInvariant())
            {
                case "displaynotifier":
                    return new DisplayNotifier(vegetableTracker);
                case "emailnotifier":
                    return new EmailNotifier(vegetableTracker);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
