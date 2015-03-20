namespace PersonRepository.WebService
{
    using System.Collections.Generic;
    using PersonRepository.Interfaces;
    using Services;

    public class WebServiceRepository : IPersonRepository
    {
        // Implement a proxy
        // Inteface only specifies a contract
        // MyServiceProxy actually gets objects from service
        // so that in main I do not care what gets those objects
        // I only care about what methods are available to me
        MyService serviceProxy = new MyService();

        public IEnumerable<Person> GetPeople()
        {
            return serviceProxy.GetPersons();
        }

        public Person GetPerson(string lastName)
        {
            return serviceProxy.GetPerson(lastName);
        }

        public void AddPerson(Person newPerson)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPersons)
        {
            throw new System.NotImplementedException();
        }
    }
}
