namespace CG_Lab5.AnalyzerUnit
{
    public class ComparisonResult
    {
        public string ImageName { get; set; } = "";
        public double SimilarityPercentage { get; set; }
        public RectangleF SegmentRectangle { get; set; }
    }
}
