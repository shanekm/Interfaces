using System;
namespace Polygons.Library
{
    public class Octagon : IRegularPolygon
    {
        public Octagon(int length)
        {
            NumberOfSides = 8;
            SideLenght = length;
        }

        public int NumberOfSides { get; set; }

        public int SideLenght { get; set; }

        public double GetParameter()
        {
            return NumberOfSides * SideLenght;
        }

        public double GetArea()
        {
            return SideLenght * SideLenght * (2 + 2 * Math.Sqrt(2));
        }
    }
}
