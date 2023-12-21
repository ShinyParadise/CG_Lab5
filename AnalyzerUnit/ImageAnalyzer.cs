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

            comparisonResults = comparisonResults.FindAll(r => r.SimilarityPercentage >= 65);
            return Filter(comparisonResults);
        }

        private List<Blob> ExtractSegments(Bitmap bitmap)
        {
            var invertedBmp = inverter.Apply(bitmap);

            blobCounter.ProcessImage(invertedBmp);
            return blobCounter.GetObjectsInformation().ToList();
        }

        private static List<ComparisonResult> Filter(List<ComparisonResult> results)
        {
            var filtered = new List<ComparisonResult>();

            foreach (ComparisonResult result in results)
            {
                var resInFilter = filtered.Find(x => x.Blob == result.Blob);

                if (resInFilter != null && result.SimilarityPercentage > resInFilter.SimilarityPercentage)
                {
                    filtered.Add(result);
                    filtered.Remove(resInFilter);
                }
                else if (resInFilter == null) 
                {
                    filtered.Add(result);
                }
            }

            return filtered;
        }
    }
}
