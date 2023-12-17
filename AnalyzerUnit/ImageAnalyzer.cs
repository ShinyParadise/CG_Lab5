using CG_Lab5.DatabaseUnit;

namespace CG_Lab5.AnalyzerUnit
{
    public class ImageAnalyzer
    {
        private List<ImageSegment> _segments = new();
        private Bitmap? _bitmap;

        public double Analyze(Bitmap bitmap)
        {
            _bitmap = bitmap;
            _segments = ExtractAndSaveSegments(bitmap);

            return 0;
        }

        private List<ImageSegment> ExtractAndSaveSegments(Bitmap grayscaleImage)
        {
            List<ImageSegment> segments = new();

            int currentSegmentIndex = 0;
            for (int x = 0; x < grayscaleImage.Width; x++)
            {
                for (int y = 0; y < grayscaleImage.Height; y++)
                {
                    Color pixelColor = grayscaleImage.GetPixel(x, y);
                    if (pixelColor.ToArgb() == Color.Black.ToArgb())
                    {
                        // Если текущий пиксель черный, начинаем процесс извлечения сегмента
                        List<Point> segmentPoints = new();
                        ExtractSegment(grayscaleImage, x, y, ref currentSegmentIndex, ref segmentPoints);

                        Bitmap segmentImage = CreateSegmentImage(grayscaleImage, segmentPoints);
                        ulong perceptualHash = HashCalculator.Calculate(segmentImage);

                        segments.Add(new ImageSegment
                        {
                            SegmentImage = segmentImage,
                            PerceptualHash = perceptualHash
                        });
                    }
                }
            }

            return segments;
        }

        // Метод для извлечения сегмента с использованием Depth-First Search (DFS)
        private void ExtractSegment(Bitmap image, int startX, int startY, ref int currentSegmentIndex, ref List<Point> segmentPoints)
        {
            Stack<Point> stack = new Stack<Point>();
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

                // Добавляем соседние пиксели в стек
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
