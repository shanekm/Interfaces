namespace InterfaceSegregationPrinciple.Example1
{
    // Extending interfaces
    public interface IExtendedSavable : ISavable
    {
        string Save(string saveName);
    }
}