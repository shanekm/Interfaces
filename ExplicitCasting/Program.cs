namespace ExplicitCasting
{
    using System;

    public interface ISavable
    {
        string Save();
    }

    public interface IPersistable
    {
        string Save();
    }

    public interface IVoidSavable
    {
        void Save();
    }

    // Extending interfaces
    public interface IExtendedSavable : ISavable
    {
        string Save(string saveName);
    }

    public class Catalog : ISavable, IPersistable
    {
        public string Load()
        {
            return "Load";
        }

        public string Save()
        {
            return "Catalog Save";
        }

        // Explicit call
        // No access modifier on Explicit interface implementation
        string ISavable.Save()
        {
            return "ISavable Save";
        }
    }

    public class ExplicitCatalog : ISavable, IPersistable
    {
        public string Save()
        {
            return "Catalog Save";
        }

        string ISavable.Save()
        {
            return "ISavable Save";
        }

        string IPersistable.Save()
        {
            return "IPersistable Save";
        }
    }

    public class ExtendedCatalog : IExtendedSavable
    {
        public string Save(string saveName)
        {
            return "IExtendedSavable Save";
        }

        public string Save()
        {
            return "ISavable Save";
        }
    }

    public class CatalogVoid : ISavable, IVoidSavable
    {
        // Since these two interfaces' signatures are different
        // at LEAST ONE of them needs to be implemented explicitly
        public string Save()
        {
            throw new NotImplementedException();
        }

        void IVoidSavable.Save()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Concrete type
            Catalog catalog = new Catalog();
            catalog.Save(); // "Catalog Save"

            // Explicit implementation is only called
            // when programming agains an interface
            ISavable savablecatalog = new Catalog();
            savablecatalog.Save(); // "ISavable Save" - Explicit call

            ((ISavable)catalog).Save(); // "ISavable Save" - Explicit call

            // Explicit interface implementation
            ISavable savable = new Catalog();
            IPersistable persistable = new Catalog();

            Console.WriteLine(catalog.Save()); // "Catalog Save"
            Console.WriteLine(savable.Save()); // "Catalog Save"
            Console.WriteLine(persistable.Save()); // "Catalog Save"

            // TAKE TWO
            // Explicit interface implementation
            ExplicitCatalog explicitCatalog = new ExplicitCatalog();
            savable = new ExplicitCatalog();
            persistable = new ExplicitCatalog();

            Console.WriteLine(explicitCatalog.Save()); // "Catalog Save"
            Console.WriteLine(savable.Save()); // "ISavable Save"
            Console.WriteLine(persistable.Save()); // "IPersistable Save"

            // TAKE THREE
            Console.WriteLine(explicitCatalog.Save()); // "Catalog Save"
            Console.WriteLine(((ISavable)explicitCatalog).Save()); // "ISavable Save"
            Console.WriteLine(((IPersistable)explicitCatalog).Save()); // "IPersistable Save"

            // Extending Interface
            // Now I have two methods available (ISave.Save() and IExtendedSavable.Save())
            ExtendedCatalog extendedCatalog = new ExtendedCatalog();
            extendedCatalog.Save("Extended save!");
            extendedCatalog.Save(); // ISavable save called
        }
    }
}
