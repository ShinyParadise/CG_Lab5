using CG_Lab5.DatabaseUnit;

namespace CG_Lab5.AnalyzerUnit
{
    class ImageHashComparator
    {
        public static List<ComparisonResult> CompareSegments(List<ImageSegment> segments, ImageDatabase db)
        {
            var imageHashes = db.ImageHashes;
            List<ComparisonResult> similarityResults = new();

            foreach (var segment in segments)
            {
                foreach (var imageHash in imageHashes)
                {
                    double similarity = CompareHashes(segment.PerceptualHash, imageHash.Value);
                    var result = new ComparisonResult
                    {
                        SimilarityPercentage = similarity,
                        ImageName = imageHash.Key,
                        SegmentRectangle = segment.Bounds
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
    }
}
