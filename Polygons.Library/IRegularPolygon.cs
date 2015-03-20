namespace Polygons.Library
{
    public interface IRegularPolygon
    {
        // These properties need to exist 
        // in concrete types
        int NumberOfSides { get; set; }

        int SideLenght { get; set; }

        double GetParameter();

        double GetArea();
    }
}
