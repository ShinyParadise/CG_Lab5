namespace CG_Lab5.PreparationUnit
{
    class FloydSteinbergFilter : IFilter
    {
        private readonly int threshold;
        
        public FloydSteinbergFilter(int threshold = 128) 
        {
            this.threshold = threshold;
        }

        public Bitmap Apply(Bitmap original)
        {
            Bitmap outputImage = new(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color oldColor = original.GetPixel(x, y);
                    int newColor = CalculateThreshold(oldColor.R);

                    outputImage.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));

                    int quantError = oldColor.R - newColor;

                    if (x + 1 < original.Width)
                        UpdatePixel(original, x + 1, y, quantError, 7.0 / 16.0);

                    if (x - 1 >= 0 && y + 1 < original.Height)
                        UpdatePixel(original, x - 1, y + 1, quantError, 3.0 / 16.0);

                    if (y + 1 < original.Height)
                        UpdatePixel(original, x, y + 1, quantError, 5.0 / 16.0);

                    if (x + 1 < original.Width && y + 1 < original.Height)
                        UpdatePixel(original, x + 1, y + 1, quantError, 1.0 / 16.0);
                }
            }

            return outputImage;
        }

        private int CalculateThreshold(int value)
        {
            return value < threshold ? 0 : 255;
        }

        private static void UpdatePixel(Bitmap image, int x, int y, int quantError, double factor)
        {
            Color currentColor = image.GetPixel(x, y);
            int newColor = Math.Max(0, Math.Min(255, currentColor.R + (int)(quantError * factor)));
            image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
        }
    }
}
