using System;

namespace SmartRefridgerator
{
    public class StorageFactory
    {
        public IStorage GetStorage(string storageType)
        {
            switch (storageType.ToLowerInvariant())
            {
                case "inmemory":
                    return new InMemoryStorage();
                case "filestorage":
                    return new FileBasedMemoryStorage();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
