namespace CG_Lab5.AnalyzerUnit
{
    struct ImageSegment
    {
        public Bitmap SegmentImage;
        public ulong PerceptualHash;

        public Point StartPoint;
        public RectangleF Bounds;
    }
}
