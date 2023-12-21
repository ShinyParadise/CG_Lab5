namespace CG_Lab5.PreparationUnit
{
    public class ImagePreparator
    {
        public int MatrixSize { 
            get => matrixSize; 
            set 
            {
                matrixSize = value;
                _mininumFilter = new(matrixSize);
            } 
        }
        public int KernelSize
        {
            get => kernelSize;
            set
            {
                kernelSize = value;
                _dilationFilter = new(kernelSize);
            }
        }

        public int MonochromeBound { 
            get => monochromeBound; 
            set 
            {  
                monochromeBound = value;
                _monochromeFilter = new(monochromeBound);
            } 
        }

        private FloydSteinbergFilter _monochromeFilter = new();
        private GrayscaleFilter _grayscaleFilter = new();
        private MininumFilter _mininumFilter = new();
        private DilationFilter _dilationFilter = new();

        private List<IFilter> _filters = new();
        private int matrixSize;
        private int kernelSize;
        private int monochromeBound;

        public ImagePreparator(int matrixSize, int monochromeBound)
        {
            MatrixSize = matrixSize;

            _mininumFilter = new(matrixSize);
            _monochromeFilter = new(monochromeBound);

            _filters.AddRange(new List<IFilter> { _grayscaleFilter, _mininumFilter, _monochromeFilter, _dilationFilter });
            MatrixSize = matrixSize;
        }

        public Bitmap PrepareImage(Bitmap bitmap)
        {
            Bitmap convertedBitmap = (Bitmap)bitmap.Clone();

            foreach (var filter in _filters) 
            {
                convertedBitmap = filter.Apply(convertedBitmap);
            }

            return convertedBitmap;
        }

        public Bitmap ConvertToGrayscale(Bitmap original)
        {
            return _grayscaleFilter.Apply(original);
        }

        public Bitmap ConvertToMonochrome(Bitmap original)
        {
            return _monochromeFilter.Apply(original);
        }

        public Bitmap GrayscaleTransform(Bitmap original)
        {
            return _mininumFilter.Apply(original);
        }

        public Bitmap MonochromeTransform(Bitmap original)
        {
            return _dilationFilter.Apply(original);
        }
    }
}
