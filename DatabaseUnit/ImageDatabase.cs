namespace CG_Lab5.DatabaseUnit
{
    public class ImageDatabase
    {
        private Dictionary<string, ulong> imageHashes = new();

        public void AddImage(string imageName, Bitmap image)
        {
            ulong perceptualHash = HashCalculator.Calculate(image);
            imageHashes[imageName] = perceptualHash;
        }

        public ulong GetHash(string imageName)
        {
            if (imageHashes.ContainsKey(imageName))
            {
                return imageHashes[imageName];
            }
            else
            {
                Console.WriteLine($"Образ с именем {imageName} не найден в базе данных.");
                return 0;
            }
        }

        public void SaveHashesToFile(string filePath)
        {
            using BinaryWriter writer = new(File.Open(filePath, FileMode.Create));
            foreach (var entry in imageHashes)
            {
                writer.Write(entry.Key);    // записываем имя образа
                writer.Write(entry.Value);  // записываем хеш
            }
        }

        public void LoadHashesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using BinaryReader reader = new(File.Open(filePath, FileMode.Open));
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string imageName = reader.ReadString(); // читаем имя образа
                    ulong hash = reader.ReadUInt64();       // читаем хеш
                    imageHashes[imageName] = hash;
                }
            }
            else
            {
                Console.WriteLine($"Файл {filePath} не найден.");
            }
        }
    }
}
