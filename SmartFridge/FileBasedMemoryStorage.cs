using System;
using System.IO;

namespace SmartRefridgerator
{
    public class FileBasedMemoryStorage : IStorage
    {
        
        public int GetVegetableMinimumQuantity(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        public void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity)
        {
            StoreIntoFile(vegetable,quantity);
        }
        public void StoreIntoFile(Vegetable vegetable, int quantity)
        {
            string path = @"VegetableMinimumQuantity.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter StreamWriter = File.CreateText(path))
                {
                    StreamWriter.WriteLine(vegetable.Name+","+quantity.ToString());
                }
                Console.WriteLine("File Created");
            }
            else
            {
                using (StreamWriter StreamWriter = File.AppendText(path))
                {
                    StreamWriter.WriteLine(vegetable.Name + "," + quantity.ToString());
                }
            }
        } 
    }
}
