using G253504_VashkevichLab5.Entities;

RailwayStation Minsk = new RailwayStation("Minsk");
Journal journal = new Journal();
Minsk.TariffsChanged += (sender, e) => journal.AddEvent(sender, e);
Minsk.PassengersChanged += (sender, e) => journal.AddEvent(sender, e);
Minsk.BoughtTicket += (sender, e) => journal.AddEvent(sender, e);

Minsk.AddPerson("Eugen", "Vashkevich", 22);
Minsk.AddTicket("Brest", 22, 22, 1, 3);
Console.WriteLine(Minsk.GetAllInfo());
Minsk.BuyTicket("Eugen", "Vashkevich", "Brest");
Minsk.AddPerson("C", "K", 22);
Minsk.AddPerson("Q", "E", 22);

Minsk.AddTicket("Vitebsk", 22, 22, 1, 3);




journal.ShowEvents();
