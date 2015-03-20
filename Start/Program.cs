namespace Start
{
    using System;
    using PersonRepository.Fake;
    using PersonRepository.Interfaces;
    using Polygons.Library;
    using RepositoryFactory;

    using ViewModel;

    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(5);

            var octagon = new Octagon(10);

            //IPersonRepository repo = new WebServiceRepository();
            //var people = repo.GetPeople();

            // I can use CSV repository instead easily
            // the code is exacly the same as above
            // without any changes
            //repo = new CSVRepository();
            //people = repo.GetPeople();

            //repo = new SQLRepository();
            //people = repo.GetPeople();

            // To refactor for (WebServiceRepo, CSV, SQLRepository) we will use Factory Method (RepositoryFactory class)
            // Compile time Factory -> application makes decision what repo to use
            // References to ALL repos have to be here (better to use Run-Time Binding (using reflection))
            // This allows us to NOT have references to all repos
            IPersonRepository repoFromFactory = RepositoryFactory.GetRepository("SQL");
            repoFromFactory.GetPeople();

            // TAKE TWO
            // Dynamic Loading 
            // 1. Get Type and assembly from configuration
            // 2. Load assembly through reflection
            // 3. Create Repository instance with the Activator
            // This allows us to get repository without specifying Repo type
            IPersonRepository repoFromDynamicRepository = RepositoryFactoryDynamic.GetRepository();
            var people = repoFromDynamicRepository.GetPeople();

            // TAKE THREE -> UNIT TESTING
            // Need to add another layer (View Model) in order to take out dependencies
            // public ViewModel { private prop IPersonRepository and other properties
            // use ViewModel to bind all data to UI controls => then in UI page declare ViewModel
            // EX: viewModel = new ViewModel() => view model has all the data and access and fetching from DB
            // now we can do Unit Tests => just on ViewModel (responsible for all the work)


            // Layered approach
            // 1. Application => UI, click buttons etc
            // 2. ViewModel => does all the fetching from db/service/csv
            // 3. Repository => actual repos (CSV/SQL etc) => GetPerson, Update, Insert
            // 4. DataStorage => actual DB or CSV file

            // LAYERED APPROACH
            // 1. APPLICATION => Program/UI => has/init new ViewModel()
            // 2. VIEWMODEL => defines IPersonRepository() and has all CRUD Methods needed for UI
            // 3. REPOSITORY => using { } => Concrete type => gets the data from DB/CSV etc
            // 4. DATA_STORAGE => actual file or SQL DB

            // This would be in UI constructor class
            //MainViewModel viewModel;
            //viewModel = new MainViewModel();

            //viewModel.FetchDataForUi();

            // UNIT TESTING
            // Test if people box gets populated
            // Its easy now since we can use FakeRepository (consistant data), and test MainViewModel
            // to see if it gets populated correctly

            // TO GET FULLY QUALIFIED NAME
            //var fakeRepo = new FakeRepository();
            //string fullyQualifiedName = fakeRepo.GetType().AssemblyQualifiedName;
        }
    }
}
