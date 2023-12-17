using CG_Lab5.DatabaseUnit;

namespace CG_Lab5.AnalyzerUnit
{
    public class ImageAnalyzer
    {
        private List<ImageSegment> _segments = new();
        private Bitmap _bitmap;
        private SuperSampler superSampler = new();
        private List<ComparisonResult> comparisonResults = new();

        public List<ComparisonResult> Analyze(Bitmap bitmap, ImageDatabase db)
        {
            _bitmap = (Bitmap)bitmap.Clone();
            _segments = ExtractAndSaveSegments(_bitmap);

            comparisonResults = ImageHashComparator.CompareSegments(_segments, db);

            return comparisonResults.FindAll(r => r.SimilarityPercentage >= 50);
        }

        private List<ImageSegment> ExtractAndSaveSegments(Bitmap original)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            List<ImageSegment> segments = new();

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        // Если текущий пиксель черный, начинаем процесс извлечения сегмента
                        List<Point> segmentPoints = new();
                        ExtractSegment(original, x, y, ref segmentPoints);

                        Bitmap segmentImage = CreateSegmentImage(original, segmentPoints);

                        // Применяем суперсемплинг
                        Bitmap resizedSegment = superSampler.Apply(segmentImage);

                        // Вычисляем перцептивный хеш для сегмента
                        ulong perceptualHash = HashCalculator.Calculate(resizedSegment);

                        // Сохраняем информацию о сегменте
                        segments.Add(new ImageSegment
                        {
                            SegmentImage = resizedSegment,
                            PerceptualHash = perceptualHash,
                            StartPoint = new Point(x, y),
                            Bounds = segmentImage.GetBounds(ref unit),
                        });
                    }
                }
            }

            return segments;
        }

        // Метод для извлечения сегмента с использованием Depth-First Search (DFS)
        private static void ExtractSegment(Bitmap image, int startX, int startY, ref List<Point> segmentPoints)
        {
            Stack<Point> stack = new();
            stack.Push(new Point(startX, startY));

            while (stack.Count > 0)
            {
                Point current = stack.Pop();

                int x = current.X;
                int y = current.Y;

                if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
                    continue;

                Color pixelColor = image.GetPixel(x, y);
                if (pixelColor.ToArgb() != Color.Black.ToArgb())
                    continue;

                // Окрашиваем пиксель, чтобы не рассматривать его снова
                image.SetPixel(x, y, Color.White);
                segmentPoints.Add(new Point(x, y));

                stack.Push(new Point(x - 1, y));
                stack.Push(new Point(x + 1, y));
                stack.Push(new Point(x, y - 1));
                stack.Push(new Point(x, y + 1));
            }
        }

        private static Bitmap CreateSegmentImage(Bitmap originalImage, List<Point> segmentPoints)
        {
            Bitmap segmentImage = new(originalImage.Width, originalImage.Height);

            foreach (var point in segmentPoints)
            {
                segmentImage.SetPixel(point.X, point.Y, Color.Black);
            }

            return segmentImage;
        }
    }
}
