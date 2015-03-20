namespace PersonRepository.CSV
{
    using PersonRepository.Interfaces;
    using System;
    using System.Collections.Generic;

    public class CSVRepository : IPersonRepository
    {
        // Get actual data from proxy here
        // ie. CSV file

        public IEnumerable<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPersons)
        {
            throw new NotImplementedException();
        }
    }
}
