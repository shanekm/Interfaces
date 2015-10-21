namespace InterfaceSegregationPrinciple.Example2
{
    public interface IProduct
    {
        decimal Price { get; set; }
        double Weight { get; set; }
        int Stock { get; set; }
        // int RunningTime { get; set; } // took this out
    }
}