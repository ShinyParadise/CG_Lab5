using CG_Lab5.PreparationUnit;

namespace CG_Lab5.DatabaseUnit
{
    public class ImageDatabase
    {
        private Dictionary<string, ulong> imageHashes = new();

        public void AddImage(string imageName, Bitmap image)
        {
            ulong perceptualHash = CalculatePerceptualHash(image);
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

        private ulong CalculatePerceptualHash(Bitmap image)
        {
            var grayscaleFilter = new GrayscaleFilter();
            int resizedWidth = 8;
            int hashSize = 64;

            Bitmap resizedImage = new(image, new Size(resizedWidth, resizedWidth));

            Bitmap grayImage = grayscaleFilter.Apply(resizedImage);

            double[,] pixelValues = ImageToPixelValues(grayImage);

            double[,] dctValues = DCT2D(pixelValues);

            // Вычисление среднего значения DCT-коэффициентов, их порогового значения и формирование хеша
            ulong hash = 0;
            double average = 0;

            for (int x = 0; x < resizedWidth; x++)
            {
                for (int y = 0; y < resizedWidth; y++)
                {
                    average += dctValues[x, y];
                }
            }

            average /= hashSize;

            for (int x = 0; x < resizedWidth; x++)
            {
                for (int y = 0; y < resizedWidth; y++)
                {
                    hash <<= 1;
                    if (dctValues[x, y] >= average)
                    {
                        hash |= 1;
                    }
                }
            }

            return hash;
        }

        private double[,] ImageToPixelValues(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            double[,] pixelValues = new double[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    pixelValues[x, y] = color.R;
                }
            }

            return pixelValues;
        }

        private double[,] DCT2D(double[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            double[,] output = new double[width, height];

            for (int u = 0; u < width; u++)
            {
                for (int v = 0; v < height; v++)
                {
                    double sum = 0;

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            sum += input[x, y] * Math.Cos((2.0 * x + 1) * u * Math.PI / (2.0 * width)) *
                                   Math.Cos((2.0 * y + 1) * v * Math.PI / (2.0 * height));
                        }
                    }

                    double Cu = (u == 0) ? 1.0 / Math.Sqrt(2) : 1.0;
                    double Cv = (v == 0) ? 1.0 / Math.Sqrt(2) : 1.0;

                    output[u, v] = 0.25 * Cu * Cv * sum;
                }
            }

            return output;
        }
    }
}
