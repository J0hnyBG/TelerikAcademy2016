## Database Systems - Overview
### _Homework_

1.  What database models do you know?
    * Hierarchical database model
    * Network model
    * Relational model
    * Entity–relationship model
    * Enhanced entity–relationship model
    * Object model
    * Document model
    * Entity–attribute–value model

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    * Managing of a relational database.. Duh
1.  Define what is "table" in database terms.
    * It is a means of storing and structuring related data in a database.
1.  Explain the difference between a primary and a foreign key.
    * The difference is that a foreign key is simpy a pointer to a row in another table while a primary key is usually used as an identifier for the current table and row.
1.  Explain the different kinds of relationships between tables in relational databases.
    * One-to-one - a single row in a table relates to a single row of another table or the same one
    * One-to-many - a single row in a table relates to many rows of another
    * Many-to-many - rows can share multiple connections with other rows
1.  When is a certain database schema normalized?
    * A database is fully normalized when all data redundancy has been removed
    * What are the advantages of normalized databases?
        * Reducing the risk of data corruption - for example if a "Country" column is not normalized "Blgaria" is a valid value.
1.  What are database integrity constraints and when are they used?
    * Integrity constraints are the "enforcers" of database integrity. They are ubiquitous in database design and are used in many forms (Primary keys, Foreign keys, Unique keys etc.)
1.  Point out the pros and cons of using indexes in a database.
    ##### Pros
        * Fast retrieval of data
    #####Cons
        * Indexing overhead 
        * Slower updating/insertion of data
1.  What's the main purpose of the SQL language?
    * The SQL language is a means for humans to design and interact with databases.
1.  What are transactions used for?
    * They are used from preventing partially successfull operations from making changes to data, when that data should not be partially updated
    * Give an example.
        * ATM withdrawal - you withdraw money and you money balance is lowered, but before the transaction can complete the connection to the bank db is lost.
1.  What is a NoSQL database?
     * It's a database which provides mechanisms for storage and retrieval of data modeled in a different way than a traditional relational database.
1.  Explain the classical non-relational data models.
       * Key-value store
            * In this model, data is represented as a collection of key-value pairs, such that each possible key appears at most once in the collection.
       * Document store
            * In general, they all assume that documents encapsulate and encode data in some standard formats or encodings (JSON, XML, etc.)
       * Object database
            * Information is represented in the form of objects as used in object-oriented programming.
1.  Give few examples of NoSQL databases and their pros and cons.
    * MongoDB
    * Cassandra
    * CouchDB
    * Redis
    
    #####Pros
        * Flexible data model
        * Mostly faster
        * Better scalability
    #####Cons
        * Easier data corruption due to flexible data model
        * Less powerful and consistent data queries