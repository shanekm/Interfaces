// How to choose (Abstract Class vs. Interface)
// Abstract class contains implementation -> children can use that implementation
// Interfaces -> no implementation
// Abstract class => when you need implementation use Abstract Class, as it contains implementation
// and if you don't need multiple inheritantce

for our example: Repository we have different implementation of GetPeople() => CSV reads from file, SQL from DB, etc
it is not correct to use Abstract class, but it's correct to use Interface

// Best Practices
// Program to Abstraction/Interface, NOT concrete type => 
// Collections, whey use IList<T> instead of List<T>
// use IList<T> instead of List<T> if you do NOT need all the features of the list collection

1. Accept the most basic/broad type that will work 
	=> in the future changing the method to accept an enumerable or ICollection of objects will still work 
	=> because the method accepts IList<T>
2. Return the richest type your user will need
	=> this saves the user need to cast when he gets those values back from the method

ex. returning IEnumerable<string> => letting the user know that this returns ONLY enumerable list there is no need for adding/removing from/to list
REPO => return Person[], List<Person>() 

// Repo may return Person[] or List<Person>, it doesn't matter
// no need for change anything in our code 
// because on the calling end we are getting an IEnumerable
IEnumerable people = people.GetPeople() => will work
// Better version Type safety
IEnumerable<Person> people = people.GetPeople()

public class List<T> : IList<T>, ICollection<T>, IReadOnlyList<T>, IEnumerable<T>...etc
IEnumerable<T> => ability to enumerate (foreach, List Boxes)

// Repository Pattern => to seperate application from db access
// pattern has CRUD methods => create, read, update, delete

Explicit Interface Implementation
public interface ISavable
{
	string Save();
}

public class Catalog : ISavable
{
	public string Save()
	{
		return "Catalog Save";
	}

	// Explicit call
	string ISavable.Save()
	{
		return "ISavable Save";
	}
}

// VERY IMPORTANT
// Interface Segregation Principle
public class List<T> : IList<T>, ICollection<T>, IReadOnlyList<T>, IEnumerable<T> etc
- clients should not be forced to depend upon methods that they do not use.
IEnumerable<T> => GetEnumerator
ICollection<T> => Count, IsReadOnly, Add, Clear, Contains, CopyTo, Remove (plus everything from IEnumerable)
IList<T> => Item/Indexer, IndexOf, Insert, RemoveAt (positioning)

// Granual Interfaces -> Future Proofing -> 3 LEVELS (IEnumerable, ICollection, IList)
1. If needed to iterate, databind, use LINQ => program against IEnumerable<T>
2. If needed to Add/Remove, count, clear => program against ICollection<T>
3. If needed to control items in collection, get item by Index => program against IList<T>

Usege: if your method receives (ICollection<T>) then any of these can be sent to that method: List<T>, Array, SortedList<T>, HastTable, Dictionary etc.
without any need to change your method's code

(all of these implement GetEnumerable therefore can be send to a method accepting IEnumerable)
IEnumerable => List<T>, Array, ArrayList, SortedList<T>, HashTable, Dictionary, Queue, Stack, ObservableCollection
ICollection => List<T> SortedList<T>, Dictionary<T>
IList => List<T>

// BETTER SEGRAGATION
have IReadOnlyRepository 

public interface IReadOnlyPersonRepository
{
	IEnumerable<Person> GetPeople();
	Person GetPerson(string lastName);
}

public interface IPersonRepository : IReadOnlyPersonRepository
{
	void AddPerson(Person newPerson);

	void UpdatePerson()
	etc..
}

then program against IReadOnlyPersonRepository when getting persons or person (gradual segregation) -> read operations

// UPDATING INTERFACES
- use Inheritance to extend interface
- no changes after contract is signed
- adding a member will break implementation
- removing also breaks implementation

public interface ISavable
{
	string Save();
}

// now, whenever we need a class to use Save in INamedSavable it will still work
public interface INamedSavable : ISavable 
{
	string Save(string name);
}

// UNIT TESTING
Mocking -> allows us to create "placeholder" objects (instead of making a new repo FakeRepository), in memory

