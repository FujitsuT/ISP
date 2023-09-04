namespace G253504_VashkevichLab5.Entities;

public class Ticket
{
    private String _direction;
    private double _price;
    private DateTime _dateTime;

    public Ticket(string direction, double price, int year, int month, int day)
    {
        this._direction = direction;
        this._price = price;
        this._dateTime = new DateTime(year, month, day);
    }

    public Ticket(String direction)
    {
        this._direction = direction;
        this._price = 0;
    }

    public string Direction
    {
        get => _direction;
        set => _direction = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Price
    {
        get => _price;
        set => _price = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        Ticket ticket = (Ticket)obj;
        return ticket._direction == this._direction;
    }

    public DateTime DateTime
    {
        get => _dateTime;
    }
}