namespace CG_Lab5.AnalyzerUnit
{
    public class ComparisonResult
    {
        public string ImageName { get; set; } = "";
        public double SimilarityPercentage { get; set; }
        public Size SegmentSize { get; set; }
        public Point StartPoint { get; set; }
    }
}
