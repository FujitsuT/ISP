using G253504_VashkevichLab5.Collections;
using G253504_VashkevichLab5.Contracts;

namespace G253504_VashkevichLab5.Entities;


public class RailwayStation : IContract
{
    private String name;

    private MyCustomCollection<(Person person, Ticket ticket)> list = new MyCustomCollection<(Person, Ticket)>();

    public RailwayStation(string name)
    {
        this.name = name;
    }

    public string Name => name;


    public void AddTicket(string firstName, string secondName, int age, string nameOfRate, double priceOfRate,  int year, int month, int day)
    {
        (Person, Ticket) tuple =  (
                                            new Person(firstName, secondName, age),
                                            new Ticket(nameOfRate, priceOfRate, year, month, day)
                                    );
        list.Add(tuple);
    }
    

    public string? GetAllInfo()
    {
        String info = "";
        list.Reset();
        while (!list.IsNull())
        {
            (Person person, Ticket ticket) tuple = list.Current();
            Person person = tuple.person;
            Ticket ticket = tuple.Item2;
            info += $"First name: {person.FirstName}\n";
            info += $"Last name: {person.SecondName}\n";
            info += $"Age: {person.Age}\n";
            info += $"Direction: {ticket.Direction}\n";
            info += $"Price: {ticket.Price}\n";
            info += $"Date: {ticket.DateTime}\n";
            info += '\n';
            list.Next();
        }

        return info;
    }

    public double? GetTotalPriceBySecondName(string secondName)
    {
        double price=0;
        list.Reset();
        while (!list.IsNull())
        {
            if (list.Current().Item1.SecondName==secondName)
            {
                price += list.Current().Item2.Price;
            }
            list.Next();
        }

        return price;
    }

    public double? GetTotalPriceByAllTickets()
    {
        double price=0;
        list.Reset();
        while (!list.IsNull())
        {
            price += list.Current().Item2.Price;
            list.Next();
        }
        return price;

    }

    public String? GetPassagersForDirection(string direction)
    {
        int count = 0;
        list.Reset();
        String info = "";
        while (!list.IsNull())
        {
            if (list.Current().Item2.Direction.Equals(direction))
            {
                (Person, Ticket) tuple = list.Current();
                Person person = tuple.Item1;
                Ticket ticket = tuple.Item2;
                info += $"First name: {person.FirstName}\n";
                info += $"Last name: {person.SecondName}\n";
                info += $"Age: {person.Age}\n";
                info += '\n';
            }
            list.Next();
        }

        return info;
    }
}