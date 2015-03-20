namespace ViewModel
{
    using System.Collections.Generic;
    using PersonRepository.Interfaces;

    public class MainViewModel
    {
        private readonly IPersonRepository repo;

        private IEnumerable<Person> people;

        public IEnumerable<Person> People;

        // Constructor
        // for moqing - constructor injector
        public MainViewModel(IPersonRepository repo)
        {
            // TAKE ONE -> dynamic loading
            // However there is dependency on RepositoryFactoryDynamic class
            // repo = RepositoryFactoryDynamic.GetRepository();

            // TAKE TWO -> DI
            this.repo = repo;
        }

        public string RepositoryType
        {
            get
            {
                return repo.GetType().ToString();
            }
        }

        public void FetchDataForUi()
        {
            People = repo.GetPeople();
        }

        public void ClearDataForUi()
        {
            People = new List<Person>();
        }
        //...
    }
}
