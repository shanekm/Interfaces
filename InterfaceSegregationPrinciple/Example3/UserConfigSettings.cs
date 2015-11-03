namespace InterfaceSegregationPrinciple.Example3
{
    // Single interface has both get/set so if I have two controllers
    // one for reading and one for writing to UserConfigSettings
    // then reader controller should not have access to Set property

    // TAKE 1
    public class UserConfigSettings : IUserConfigSettings
    {
        private string theme;

        public UserConfigSettings()
        {
            // read from config file here and set theme
            theme = "test";
        }

        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
            }
        }
    }

    // TAKE 2 - GOOD (not creating a common I interface that implements both - this creates interface soup)
    // Better to have Concrete type implement both
    // This is the same as having IUserConfigSettingsReaderWriterBoth
    public class UserConfigSettingsReaderWriter : IUserConfigReader, IUserConfigWriter
    {
        public string GetTheme()
        {
            return "test";
        }

        public void SetTheme(string theme)
        {
            // setting theme
        }

    }

    // This is the same as having IUserConfigSettingsReaderWriterBoth
    public class UserConfigSettingsReader : IUserConfigReader
    {
        public string GetTheme()
        {
            return "test";
        }
    }

    // Same as above
    // Interface Soup Anti-Pattern (Implementor below needs to Implement ALL interfaces -> defeats the purpose of segragation)
    public interface IUserConfigSettingsReaderWriterBoth : IUserConfigReader, IUserConfigWriter
    {
       
    }

    // Wrong - Creates interface soup. there is no benefit
    // Same as above
    public class UserConfigSettingsReaderWriterBoth : IUserConfigSettingsReaderWriterBoth
    {
        public string GetTheme()
        {
            throw new System.NotImplementedException();
        }

        public void SetTheme(string theme)
        {
            throw new System.NotImplementedException();
        }
    }

}
