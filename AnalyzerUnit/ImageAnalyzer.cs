using CG_Lab5.DatabaseUnit;

namespace CG_Lab5.AnalyzerUnit
{
    public class ImageAnalyzer
    {
        private List<ImageSegment> _segments = new();
        private Bitmap _bitmap;

        public double Analyze(Bitmap bitmap)
        {
            _bitmap = (Bitmap)bitmap.Clone();
            _segments = ExtractAndSaveSegments(_bitmap);



            return 0;
        }

        private List<ImageSegment> ExtractAndSaveSegments(Bitmap grayscaleImage)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            List<ImageSegment> segments = new();

            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    Color pixelColor = grayscaleImage.GetPixel(x, y);
                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        // Если текущий пиксель черный, начинаем процесс извлечения сегмента
                        List<Point> segmentPoints = new();
                        ExtractSegment(grayscaleImage, x, y, ref segmentPoints);

                        Bitmap segmentImage = CreateSegmentImage(grayscaleImage, segmentPoints);

                        // Применяем суперсемплинг
                        Bitmap resizedSegment = SuperSampling(segmentImage, 8, 8);

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

        private Bitmap SuperSampling(Bitmap originalImage, int v1, int v2)
        {
            Bitmap resizedImage = new(v1, v2);

            for (int x = 0; x < v1; x++)
            {
                for (int y = 0; y < v2; y++)
                {
                    int originalX = x * originalImage.Width / v1;
                    int originalY = y * originalImage.Height / v2;

                    Color newColor = AverageColor(originalImage, originalX, originalY, v1, v2);
                    resizedImage.SetPixel(x, y, newColor);
                }
            }

            return resizedImage;
        }

        private static Color AverageColor(Bitmap image, int x, int y, int blockWidth, int blockHeight)
        {
            int totalR = 0, totalG = 0, totalB = 0;

            for (int i = 0; i < blockWidth; i++)
            {
                for (int j = 0; j < blockHeight; j++)
                {
                    Color pixelColor = image.GetPixel(x + i, y + j);
                    totalR += pixelColor.R;
                    totalG += pixelColor.G;
                    totalB += pixelColor.B;
                }
            }

            int numPixels = blockWidth * blockHeight;
            int avgR = totalR / numPixels;
            int avgG = totalG / numPixels;
            int avgB = totalB / numPixels;

            return Color.FromArgb(avgR, avgG, avgB);
        }
    }
}
