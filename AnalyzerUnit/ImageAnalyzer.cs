using AForge.Imaging;
using CG_Lab5.DatabaseUnit;
using CG_Lab5.PreparationUnit;

namespace CG_Lab5.AnalyzerUnit
{
    public class ImageAnalyzer
    {
        private List<Blob> _segments = new();
        private Bitmap _bitmap;
        private List<ComparisonResult> comparisonResults = new();
        private Inverter inverter = new();

        private readonly BlobCounter blobCounter = new()
        {
            FilterBlobs = true,
            MinHeight = 8,
            MinWidth = 8
        };

        public List<ComparisonResult> Analyze(Bitmap bitmap, ImageDatabase db)
        {
            _bitmap = (Bitmap)bitmap.Clone();
            _segments = ExtractSegments(_bitmap);

            comparisonResults = ImageHashComparator.CompareSegments(_segments, db, _bitmap);

            return comparisonResults.FindAll(r => r.SimilarityPercentage >= 65);
        }

        private List<Blob> ExtractSegments(Bitmap bitmap)
        {
            var invertedBmp = inverter.Apply(bitmap);

            blobCounter.ProcessImage(invertedBmp);
            return blobCounter.GetObjectsInformation().ToList();
        }
    }
}
