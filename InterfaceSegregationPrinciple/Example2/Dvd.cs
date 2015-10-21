namespace InterfaceSegregationPrinciple.Example2
{
    public class DVD : IProduct
    {
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int RunningTime { get; set; }
    }
}