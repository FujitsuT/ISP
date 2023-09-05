using G253504_VashkevichLab5.Collections;

namespace G253504_VashkevichLab5.Entities;

public class Journal
{
    private MyCustomCollection<String> EventList;
    private int count;

    public Journal()
    {
        count=0;
        EventList = new MyCustomCollection<string>();
    }

    public MyCustomCollection<string> EventList1
    {
        get => EventList;
        set => EventList = value ?? throw new ArgumentNullException(nameof(value));
    }


    public void AddEvent(object sender, CustomMessage message)
    {
        EventList.Add(message.Message);
        count++;
    }

    public void ShowEvents()
    {
        foreach (var a in EventList)
        {
            Console.WriteLine(a);
        }
    }
    
    
    public int Count
    {
        get => count;
        set => count = value;
    }
    
    // public void OnTariffsChanged(object sender, CustomMessage message)
    // {
    //     AddEvent(sender, message.Message);
    // }
    //
    // public void OnPassengersChanged(object sender, CustomMessage message)
    // {
    //     AddEvent(sender, message.Message);
    // }
}