namespace Polygons.Library
{
    public abstract class AbstractRegularPolygon
    {
        public int NumberOfSides { get; set; }

        public int SideLength { get; set; }

        public AbstractRegularPolygon(int sides, int length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public double GetParameter()
        {
            return NumberOfSides * SideLength;
        }

        // Abstract method -> must be implemented
        // abstract member means we have to mark class as abstract as well
        public abstract double GetArea();
    }
}
