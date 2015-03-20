Why Use IDisposable? - resource management, release management (from Heap)
- Memory usage
- Database connections
- Network issues

Not using IDisposable issues
- Expending memory
- Hogging external resources
- Functional defects

IDisposible -> in mscall.lib
Unmanaged Resources - external resources
	- external COM library
	- IO - external file may be not closed etc, should tell it when finished
	- Data SQL - connections are unmanaged
	- WCF - unmanaged connections

GARBAGE COLLECTOR
1. var obj = new MyClass() 
	- new keyword = (STACK) {}pointer => (HEAP) .NET allocates memory on the, no other app/program may use that memory location
	- app end OR CRASHES => memory is cleared. Another way memory is cleared is via GC run (is object still recheable?) => pointer (STACK) / mem (HEAP) are cleared
	- GC (groups objects into 3 different generations (gen0, gen1, gen2) => short and long lived: a1, a2, a3 => a1, a2 move to gen1 and so on
	- Heap compression - removing gaps between memory objects
2. When does the GC collect?
	- when new() - it checks Gen0 (least expensive) - threshold check - executed in the background in a seperate thread -> GC collects
	- balances between efficiency for app, and making memory available (collecting memory)

.dotMemory - JetBrains for viewing memory allocation

IMPORTANT
Is a resources/class you're using implements IDisposible you need to use it correctly and/or also implement IDisposable

BEST PRACTICES
1. Dispose of IDisposable objects as soon as you can (using{} statement)
2. If you use IDisposable objects as instance fields, implement IDisposable (call Dispose() on the resource)
	- DatabaseState uses SqlConnection which in turn implements IDisposable. Therefore DatabaseState needs to implement IDisposable as well
3. Allow Dispose() to be called multiple times and don't throw exception (checking bool - because you don't know if object has already been disposed


SUMMARY
1. Why use IDisposable - provides a mechanism for releasing unmanaged resources
2. Using IDisposable - alwasy use "using{}" statement, it will automatically call Dispose() method
3. DatabaseState class - implementing IDisposable (using{} and finally statements (WCF))
4. WordCounter application - computes number of words
	- Console app - managed code
	- Everything else (files, other resources) - unmanaged code
5. GC - garbage collector - .net frameworks GC manages the allocation and release of memory for your application
	- When GC collects? - whenever creating new objects => new() - clear Gen0, Gen1, and Gen3 - balance efficiency/memory allocation
6. DatabaseStateIDisposableImplementation - implementing IDisposable correctly
7. DatabaseStateIDisposableImplementation - Dispose() and Finalize - Dispose is only there for the User to use/programmer to explicity call it
	- if user does not call Dispose() it will never be cleaned/collected. Therefore use Finalizer in case user of the class doesn't call Dispose()
	- Finalizer ~ClassWithFinalizer - when GC is cleaning a dead object, and sees Finalizer defined and it has NOT been told NOT to finilize it DOES run Finalizer
	- Finalizer - expensive. avoid it. Run Dispose() instead
8. UnmanagedDatabaseState - implementing parent class that implements IDisposable(), calling Dispose() on base class after child class Dispose() has been called
