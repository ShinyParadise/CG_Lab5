using CG_Lab5.AnalyzerUnit;
using CG_Lab5.PreparationUnit;

namespace CG_Lab5.DatabaseUnit
{
    public class HashCalculator
    {
        private const int white = 255;
        private const int one = 1;
        private const int resizedWidth = 8;

        private static GrayscaleFilter grayscaleFilter = new();
        private static MonochromeFilter monochromeFilter = new();

        public static ulong Calculate(Bitmap image)
        {
            Bitmap resizedImage = (image.Height == resizedWidth && image.Width == resizedWidth) 
                ? (Bitmap)image.Clone()
                : new(image, resizedWidth, resizedWidth);

            Bitmap grayImage = grayscaleFilter.Apply(resizedImage);
            Bitmap monochromeImg = monochromeFilter.Apply(grayImage);

            ulong hash = GenerateHash(monochromeImg);
            return hash;
        }

        private static ulong GenerateHash(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            ulong hash = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    if (color.R != white)
                    {
                        hash |= one;
                    }
                    hash <<= one;
                }
            }

            return hash;
        }
    }
}
