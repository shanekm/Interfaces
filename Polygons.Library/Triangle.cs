using System;
namespace Polygons.Library
{
    public class Triangle : AbstractRegularPolygon
    {
        public Triangle(int length)
            : base(3, length)
        {
        }

        public override double GetArea()
        {
            // Formula for calculating area of triangle
            return SideLength * SideLength * Math.Sqrt(3) / 4;
        }

        // I don't need to overwrite OverwriteMethod() from base since it's virtual
    }
}
