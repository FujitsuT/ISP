using G253504_VashkevichLab5.Collections;

namespace G253504_VashkevichLab5.Entities;

public class Person
{
    private String firstName;
    private String secondName;
    private int age;
    public MyCustomCollection<Ticket> _tickets;

    public Person(string firstName, string secondName, int age)
    {
        this.firstName = firstName;
        this.secondName = secondName;
        this.age = age;
    }

    public Person(string firstName, string secondName, int age, Ticket ticket)
    {
        this.firstName = firstName;
        this.secondName = secondName;
        this.age = age;
        _tickets = new MyCustomCollection<Ticket>();
        _tickets.Add(ticket);
    }

    public string FirstName => firstName;

    public string SecondName => secondName;

    public int Age => age;

    public void SaveTicket(String direction, double price, int year, int month, int day)
    {
        if (_tickets == null)
        {
            _tickets = new MyCustomCollection<Ticket>();
        }
        _tickets.Add(new Ticket(direction, price, year, month, day));
    }
    
    public void SaveTicket(Ticket ticket)
    {
        if (_tickets == null)
        {
            _tickets = new MyCustomCollection<Ticket>();
        }
        _tickets.Add(ticket);
    }

    public MyCustomCollection<Ticket> Tickets
    {
        get => _tickets;
        set => _tickets = value ?? throw new ArgumentNullException(nameof(value));
    }
}