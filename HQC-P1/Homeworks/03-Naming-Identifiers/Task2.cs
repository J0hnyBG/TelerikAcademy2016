public class PersonFactory
{
    enum Gender { Male, Female };

    private class Person
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void CreatePerson(int personAge)
    {
        Person person = new Person();
        person.Age = personAge;

        if ( personAge % 2 == 0 )
        {
            person.Name = "Батката";
            person.Gender = Gender.Male;
        }
        else
        {
            person.Name = "Мацето";
            person.Gender = Gender.Female;
        }
    }
}