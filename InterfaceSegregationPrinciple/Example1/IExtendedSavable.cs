namespace InterfaceSegregationPrinciple.Example1
{
    // Extending interfaces
    public interface IExtendedSavable : ISavable
    {
        void Save(string saveName);
    }
}