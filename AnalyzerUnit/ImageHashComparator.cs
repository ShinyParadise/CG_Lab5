using AForge.Imaging;
using CG_Lab5.DatabaseUnit;

namespace CG_Lab5.AnalyzerUnit
{
    class ImageHashComparator
    {
        public static List<ComparisonResult> CompareSegments(List<Blob> segments, ImageDatabase db, Bitmap source)
        {
            var imageHashes = db.ImageHashes;
            List<ComparisonResult> similarityResults = new();

            foreach (Blob segment in segments)
            {
                var blobBitmap = ExtractBitmapFromBlob(segment, source);
                var currentSegmentHash = HashCalculator.Calculate(blobBitmap);

                foreach (var imageHash in imageHashes)
                {
                    double similarity = CompareHashes(currentSegmentHash, imageHash.Value);
                    var result = new ComparisonResult
                    {
                        SimilarityPercentage = similarity,
                        ImageName = imageHash.Key,
                        Blob = segment,
                    };

                    similarityResults.Add(result);
                }
            }

            return similarityResults;
        }

        private static double CompareHashes(ulong hash1, ulong hash2)
        {
            // Вычисляем расстояние Хемминга
            ulong xorResult = hash1 ^ hash2;

            // Подсчитываем количество установленных битов в результате XOR
            int setBitsCount = CountSetBits(xorResult);

            // Вычисляем процент соответствия
            double similarity = 1.0 - setBitsCount / 64.0;
            return similarity * 100.0;
        }

        private static int CountSetBits(ulong number)
        {
            int count = 0;
            while (number > 0)
            {
                count += (int)(number & 1);
                number >>= 1;
            }
            return count;
        }

        private static Bitmap ExtractBitmapFromBlob(Blob blob, Bitmap sourceImage)
        {
            // Получение координат объекта
            int x = blob.Rectangle.X;
            int y = blob.Rectangle.Y;
            int width = blob.Rectangle.Width;
            int height = blob.Rectangle.Height;

            // Выделение соответствующей области на исходном изображении
            Bitmap blobBitmap = sourceImage.Clone(new Rectangle(x, y, width, height), sourceImage.PixelFormat);

            return blobBitmap;
        }
    }
}
