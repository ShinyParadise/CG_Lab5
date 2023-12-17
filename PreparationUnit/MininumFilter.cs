namespace CG_Lab5.PreparationUnit
{
    public class MininumFilter : IFilter
    {
        private int _windowSize = 0;

        public MininumFilter() { }
        public MininumFilter(int windowSize) { _windowSize = windowSize; }

        public Bitmap Apply(Bitmap original)
        {
            Bitmap result = new(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Получаем окрестность текущего пикселя
                    Color[] neighborhood = IFilter.GetPixelNeighborhood(original, x, y, _windowSize);

                    // Находим минимальное значение цвета для текущего пикселя
                    int minR = int.MaxValue;
                    int minG = int.MaxValue;
                    int minB = int.MaxValue;

                    foreach (var color in neighborhood)
                    {
                        minR = Math.Min(minR, color.R);
                        minG = Math.Min(minG, color.G);
                        minB = Math.Min(minB, color.B);
                    }

                    // Устанавливаем минимальное значение цвета для текущего пикселя
                    result.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                }
            }

            return result;
        }
    }
}
