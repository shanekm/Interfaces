namespace InterfaceSegregationPrinciple.Example2
{
    public class TShirt : IProduct
    {
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
    }
}