namespace RepositoryFactory
{
    using System;
    using System.Configuration;
    using PersonRepository.Interfaces;

    public class RepositoryFactoryDynamic
    {
        public static IPersonRepository GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repositoryType = Type.GetType(typeName);
            object repositoryInstance = Activator.CreateInstance(repositoryType);

            IPersonRepository repo = repositoryInstance as IPersonRepository;
            return repo;
        }
    }
}
