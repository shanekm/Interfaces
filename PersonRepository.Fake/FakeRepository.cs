namespace PersonRepository.Fake
{
    using System.Collections.Generic;
    using PersonRepository.Interfaces;

    public class FakeRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            var p = new List<Person>
                        {
                            new Person() { FirstName = "John", LastName = "Benish" },
                            new Person() { FirstName = "Stew", LastName = "Billing" }
                        };

            return p;
        }

        public Person GetPerson(string lastName)
        {
            throw new System.NotImplementedException();
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
