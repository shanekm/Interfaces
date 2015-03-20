using System.Collections.Generic;
namespace PersonRepository.Interfaces
{
    public interface IPersonRepository
    {
        // Returning interface => this means that class implementing this (DB)
        // can return  anything ie. array(), List<T>, Collection and it will work
        // because this is a generic type
        IEnumerable<Person> GetPeople();

        Person GetPerson(string lastName);

        void AddPerson(Person newPerson);

        void UpdatePerson(string lastName, Person updatedPerson);

        void DeletePerson(string lastName);

        void UpdatePeople(IEnumerable<Person> updatedPersons);
    }
}
