using CG_Lab5.PreparationUnit;

namespace CG_Lab5.DatabaseUnit
{
    public class HashCalculator
    {
        public static ulong Calculate(Bitmap image)
        {
            var grayscaleFilter = new GrayscaleFilter();
            var monochromeFilter = new MonochromeFilter();

            int resizedWidth = 8;
            int hashSize = 64;

            Bitmap resizedImage = new(image, new Size(resizedWidth, resizedWidth));

            Bitmap grayImage = grayscaleFilter.Apply(resizedImage);
            Bitmap monochromeImg = monochromeFilter.Apply(grayImage);

            double[,] pixelValues = ImageToPixelValues(monochromeImg);

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

        private static double[,] ImageToPixelValues(Bitmap image)
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

        private static double[,] DCT2D(double[,] input)
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
