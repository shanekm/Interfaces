namespace PersonRepository.SQL
{
    using PersonRepository.Interfaces;
    using System;
    using System.Collections.Generic;

    public class SQLRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            // Implement get from db here
            //using (var ctx = new PeopleEntities())
            //{
            //    ...
            //}
            var p = new List<Person>
                        {
                            new Person() { FirstName = "John", LastName = "Benish" },
                            new Person() { FirstName = "Stew", LastName = "Billing" }
                        };

            return p;
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
