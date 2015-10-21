namespace InterfaceSegregationPrinciple.Example2
{
    public interface IMovie : IProduct
    {
        int RunningTime { get; set; }
    }
}