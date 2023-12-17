namespace CG_Lab5.PreparationUnit
{
    public interface IFilter
    {
        public Bitmap Apply(Bitmap original);

        protected static Color[] GetPixelNeighborhood(Bitmap bitmap, int x, int y, int windowSize)
        {
            int halfWindowSize = windowSize / 2;
            Color[] neighborhood = new Color[windowSize * windowSize];

            int index = 0;

            // Проходим по окрестности текущего пикселя
            for (int i = -halfWindowSize; i <= halfWindowSize; i++)
            {
                for (int j = -halfWindowSize; j <= halfWindowSize; j++)
                {
                    int neighborX = Math.Clamp(x + i, 0, bitmap.Width - 1);
                    int neighborY = Math.Clamp(y + j, 0, bitmap.Height - 1);

                    // Добавляем цвет соседнего пикселя в массив
                    neighborhood[index++] = bitmap.GetPixel(neighborX, neighborY);
                }
            }

            return neighborhood;
        }
    }
}
