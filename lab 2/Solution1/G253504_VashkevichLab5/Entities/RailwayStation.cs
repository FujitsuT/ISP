using G253504_VashkevichLab5.Collections;
using G253504_VashkevichLab5.Contracts;

namespace G253504_VashkevichLab5.Entities;

public class RailwayStation : IContract
{
    private String name;

    private MyCustomCollection<Person> _personsList = new MyCustomCollection<Person>();
    private MyCustomCollection<Ticket> _ticketsList = new MyCustomCollection<Ticket>();
    
    public RailwayStation(string name)
    {
        this.name = name;
    }

    public string Name => name;


    public event EventHandler<CustomMessage> TariffsChanged;
    public event EventHandler<CustomMessage> PassengersChanged;
    public event EventHandler<CustomMessage> BoughtTicket;


    public void AddTicket(string nameOfRate, double priceOfRate, int year, int month, int day)
    {
        _ticketsList.Add(new Ticket(nameOfRate, priceOfRate, year, month, day));
        TariffsChanged?.Invoke(this, new CustomMessage($"Ticket was added to {nameOfRate}"));
    }

    public void AddPerson(String firstName, String secondName, int age)
    {
        PassengersChanged?.Invoke(this, new CustomMessage($"Person was added name {firstName}, second name: {secondName}, age: {age}"));
        _personsList.Add(new Person(firstName, secondName, age));
    }


    public void BuyTicket(String name, String secondName, String direction)
    {
        _personsList.Reset();
        bool flag = false;
        foreach (var a in _personsList)
        {
            if (a.FirstName == name && a.SecondName == secondName)
            {
                foreach (var b in _ticketsList)
                {
                    if (b.Direction == direction)
                    {
                        BoughtTicket?.Invoke(this, new CustomMessage($"Ticket was bought by {name} {secondName} to {direction} "));
                        a.SaveTicket(b);
                        return;
                    }
                }
            }
        }

        if (!flag)
        {
            throw new Exception("Ticket or Person not found");
        }
    }

    public string? GetAllInfo()
    {
        String info = "";
        foreach (var a in _personsList)
        {
            info += $"First name: {a.FirstName}\n";
            info += $"Last name: {a.SecondName}\n";
            info += $"Age: {a.Age}\n";
            if (a.Tickets != null)
            {
                foreach (var b in a.Tickets)
                {
                    info += $"Direction: {b.Direction}\n";
                    info += $"Price: {b.Price}\n";
                    info += $"Date: {b.DateTime}\n";
                    info += $"-----------------------\n";
                }
            }

            info += '\n';
        }

        return info;
    }

    public double? GetTotalPriceBySecondName(string secondName)
    {
        double price = 0;
        foreach (var a in _personsList)
        {
            if (a.SecondName == secondName)
            {
                if (a.Tickets != null)
                {
                    foreach (var b in a.Tickets)
                    {
                        price += b.Price;
                    }
                }
            }
        }

        return price;
    }

    public double? GetTotalPriceByAllTickets()
    {
        double price = 0;
        foreach (var a in _personsList)
        {
            if (a.Tickets != null)
            {
                foreach (var b in a.Tickets)
                {
                    price += b.Price;
                }
            }
        }

        return price;
    }

    public String? GetPassagersForDirection(string direction)
    {
        String info = "";
        foreach (var a in _personsList)
        {
            if (a.Tickets != null)
            {
                foreach (var b in a.Tickets)
                {
                    if (b.Direction == direction)
                    {
                        info += $"First name: {a.FirstName}\n";
                        info += $"Last name: {a.SecondName}\n";
                        info += $"Age: {a.Age}\n";
                        info += '\n';
                    }
                }
            }

            info += '\n';
        }

        return info;
    }

}
