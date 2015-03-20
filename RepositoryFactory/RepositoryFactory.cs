namespace RepositoryFactory
{
    using System;
    using PersonRepository.CSV;
    using PersonRepository.Interfaces;
    using PersonRepository.SQL;
    using PersonRepository.WebService;

    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(string repositoryType)
        {
            IPersonRepository repo = null;
            switch (repositoryType)
            {
                case "Service":
                    repo = new WebServiceRepository();
                    break;
                case "CSV":
                    repo = new CSVRepository();
                    break;
                case "SQL":
                    repo = new SQLRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repository type!");
            }

            return repo;
        }
    }
}
