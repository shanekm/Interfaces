namespace InterfaceSegregationPrinciple.Example3
{
    // TAKE 1
    public interface IUserConfigSettings
    {
        string Theme { get; set; }
    }

    // TAKE 2
    public interface IUserConfigReader
    {
        string GetTheme();
    }

    public interface IUserConfigWriter
    {
        void SetTheme(string theme);
    }
}