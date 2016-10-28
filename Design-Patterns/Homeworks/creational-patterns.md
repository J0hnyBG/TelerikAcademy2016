1. Singleton
    * The singleton is a design pattern which allows only a single instance of a class to exist at any given time and to provide a global access point for the object. 
        * Pros: Low latency; Better memory requirements; Needs initialization once;
        * Cons: The default implementation is not thread safe; Introduces tight coupling between classes because it's static; Difficult to test;
2. Factory method
    * The factory method is a design pattern which defines an interface for creating an object, but lets subclasses decide which class to instantiate.
        * Pros: Hides implementaton details; Allows for loose coupling and easy change of implementation details; 
        * Cons: Makes code less readable as the codes is behind and abstraction which may hide other abstractions; 
3. Fluent interface
    * Allows chaning of method calls by returning the whole object as a result of a method. For example IEnumerable<T>.Where(x => x > 10).Select(x => new Obj(x));
        * Pros: Produces easily readable code; Allows method chaining;
        * Cons: May need to omit meaningful return values when methods return something other than the object, resulting in some methods being chainable and others not.