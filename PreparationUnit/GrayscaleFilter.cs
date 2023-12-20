using System.Drawing.Imaging;

namespace CG_Lab5.PreparationUnit
{
    public class GrayscaleFilter : IFilter
    {
        public Bitmap Apply(Bitmap original)
        {
            Bitmap grayscale = new(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Получаем цвет текущего пикселя
                    Color originalColor = original.GetPixel(x, y);

                    // Вычисляем среднее значение компонент цвета и устанавливаем его для нового пикселя
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscale.SetPixel(x, y, grayColor);
                }
            }

            return grayscale;
        }
    }
}
