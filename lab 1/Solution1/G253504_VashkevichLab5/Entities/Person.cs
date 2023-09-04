namespace G253504_VashkevichLab5.Entities;

public class Person
{
    private String firstName;
    private String secondName;
    private int age;

    public Person(string firstName, string secondName, int age)
    {
        this.firstName = firstName;
        this.secondName = secondName;
        this.age = age;
    }

    public string FirstName => firstName;

    public string SecondName => secondName;

    public int Age => age;
}