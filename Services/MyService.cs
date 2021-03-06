﻿using System.Collections.Generic;
using PersonRepository.Interfaces;

namespace Services
{
   
    public class MyService
    {
        public List<Person> GetPersons()
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
            return new Person() { FirstName = "jOHh", LastName = "Test" };
        }

    }
}
