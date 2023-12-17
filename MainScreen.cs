using CG_Lab5.AnalyzerUnit;
using CG_Lab5.DatabaseUnit;
using CG_Lab5.PreparationUnit;

namespace CG_Lab5
{
    public partial class MainScreen : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Color _bgColor = Color.White;

        private ImagePreparator _imagePreparator;
        private ImageDatabase _db = new();
        private ImageAnalyzer _analyzer = new();

        private int _kernelSize = 1;
        private int _matrixSize = 1;
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
                Console.WriteLine($"������ ��� �������� �����������: {ex.Message}");
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

        private void addImageBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var addedImage = new Bitmap(dialog.FileName);
                _db.AddImage(dialog.SafeFileName, addedImage);
            }
        }

        private void loadImagesBtn_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _db.LoadHashesFromFile(dialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _db.SaveHashesToFile(dialog.FileName);
            }
        }

        private void analyzeBtn_Click(object sender, EventArgs e)
        {
            var results = _analyzer.Analyze(_bitmap, _db);
            var pen = new Pen(Color.Orange, 3);
            var brush = new SolidBrush(Color.Orange);

            foreach (var res in results)
            {
                res.StartPoint.Offset(new(-10, -10));
                _graphics.DrawString(res.ImageName, DefaultFont, brush, res.StartPoint);
                _graphics.DrawRectangle(pen, new(res.StartPoint, res.SegmentSize));
            }
        }
    }
}