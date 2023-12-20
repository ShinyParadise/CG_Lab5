namespace CG_Lab5.PreparationUnit
{
    public class Inverter : IFilter
    {
        public Bitmap Apply(Bitmap original)
        {
            Bitmap inverted = new(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color color = original.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    inverted.SetPixel(x, y, invertedColor);
                }
            }

            return inverted;
        }
    }
}
