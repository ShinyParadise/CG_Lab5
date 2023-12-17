using CG_Lab5.PreparationUnit;

namespace CG_Lab5.AnalyzerUnit
{
    public class SuperSampler : IFilter
    {
        private int v1, v2;

        public SuperSampler(int v1 = 8, int v2 = 8) { this.v1 = v1; this.v2 = v2; }

        public Bitmap Apply(Bitmap original)
        {
            Bitmap resizedImage = new(v1, v2);

            for (int x = 0; x < v1; x++)
            {
                for (int y = 0; y < v2; y++)
                {
                    int originalX = x * original.Width / v1;
                    int originalY = y * original.Height / v2;

                    Color newColor = AverageColor(original, originalX, originalY, v1, v2);
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
