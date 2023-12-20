using System.Drawing.Imaging;

namespace CG_Lab5.PreparationUnit
{
    public class MonochromeFilter : IFilter
    {
        private int _threshold = 128;

        public MonochromeFilter() { }

        public MonochromeFilter(int threshold) {  _threshold = threshold; }

        public Bitmap Apply(Bitmap original)
        {
            Bitmap binary = new(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color originalColor = original.GetPixel(x, y);

                    // Вычисляем яркость пикселя
                    int brightness = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);

                    // Устанавливаем цвет пикселя в зависимости от яркости и порога
                    Color binaryColor = (brightness > _threshold) ? Color.White : Color.Black;
                    binary.SetPixel(x, y, binaryColor);
                }
            }

            return binary;
        }
    }
}
