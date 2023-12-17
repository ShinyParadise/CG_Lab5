using CG_Lab5.PreparationUnit;

namespace CG_Lab5
{
    public partial class MainScreen : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Color _bgColor = Color.White;

        private int _matrixSize = 1;

        private ImagePreparator _imagePreparator;
        private int _kernelSize = 1;
        private int _monochromeBound = 128;

        public MainScreen()
        {
            InitializeComponent();

            _imagePreparator = new(_matrixSize, _monochromeBound);

            InitCanvas();
        }

        private void InitCanvas()
        {
            Rectangle rectangle = pictureBox1.ClientRectangle;
            _bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            _graphics = Graphics.FromImage(_bitmap);
            pictureBox1.Image = _bitmap;
            _graphics.Clear(_bgColor);
        }

        private void choosePhotoBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(dialog.FileName);
            }
        }

        private void LoadImage(string fileName)
        {
            try
            {
                var loadedBitmap = new Bitmap(fileName);
                LoadBitmap(loadedBitmap);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке изображения: {ex.Message}");
            }
        }

        private void grayscaleBtn_Click(object sender, EventArgs e)
        {
            var newBitmap = _imagePreparator.ConvertToGrayscale(_bitmap);

            LoadBitmap(newBitmap);
        }

        private void LoadBitmap(Bitmap newBitmap)
        {
            _bitmap = newBitmap;
            pictureBox1.Image = _bitmap;
            _graphics = Graphics.FromImage(_bitmap);
        }

        private void monochromeBtn_Click(object sender, EventArgs e)
        {
            var newBitmap = _imagePreparator.ConvertToMonochrome(_bitmap);
            LoadBitmap(newBitmap);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _ = int.TryParse(textBox1.Text, out _matrixSize);
            _imagePreparator.MatrixSize = _matrixSize;
        }

        private void applyMininumFilterBtn_Click(object sender, EventArgs e)
        {
            var newBitmap = _imagePreparator.GrayscaleTransform(_bitmap);
            LoadBitmap(newBitmap);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _ = int.TryParse(textBox2.Text, out _kernelSize);
            _imagePreparator.KernelSize = _kernelSize;
        }

        private void dilationBtn_Click(object sender, EventArgs e)
        {
            var newBitmap = _imagePreparator.MonochromeTransform(_bitmap);
            LoadBitmap(newBitmap);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _ = int.TryParse(textBox3.Text, out _monochromeBound);
            _imagePreparator.MonochromeBound = _monochromeBound;
        }
    }
}