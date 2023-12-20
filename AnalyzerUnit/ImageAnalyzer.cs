using AForge.Imaging;
using CG_Lab5.DatabaseUnit;
using Point = System.Drawing.Point;

namespace CG_Lab5.AnalyzerUnit
{
    public class ImageAnalyzer
    {
        private List<Blob> _segments = new();
        private Bitmap _bitmap;
        private List<ComparisonResult> comparisonResults = new();


        private readonly BlobCounter blobCounter = new()
        {
            FilterBlobs = true,
            MinHeight = 8,
            MinWidth = 8
        };

        public List<ComparisonResult> Analyze(Bitmap bitmap, ImageDatabase db)
        {
            _bitmap = (Bitmap)bitmap.Clone();
            _segments = ExtractSegments(_bitmap);

            comparisonResults = ImageHashComparator.CompareSegments(_segments, db, _bitmap);

            return comparisonResults.FindAll(r => r.SimilarityPercentage >= 65);
        }

        private List<Blob> ExtractSegments(Bitmap bitmap)
        {
            blobCounter.ProcessImage(bitmap);
            return blobCounter.GetObjectsInformation().ToList();
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
