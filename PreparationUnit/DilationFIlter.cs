namespace CG_Lab5.PreparationUnit
{
    public class DilationFIlter : IFilter
    {
        private int kernelSize = 3;

        public DilationFIlter() { }
        public DilationFIlter(int kernelSize) { this.kernelSize = kernelSize; }

        public Bitmap Apply(Bitmap original)
        {
            Bitmap result = new(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Применяем структурный элемент (квадрат)
                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            int neighborX = Math.Clamp(x + i, 0, original.Width - 1);
                            int neighborY = Math.Clamp(y + j, 0, original.Height - 1);

                            // Если структурный элемент перекрывает черный пиксель, делаем текущий пиксель белым
                            if (original.GetPixel(neighborX, neighborY).R == 0)
                            {
                                result.SetPixel(x, y, Color.Black);
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
