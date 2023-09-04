using G253504_VashkevichLab5.Entities;

RailwayStation Minsk = new RailwayStation("Minsk");
Minsk.AddTicket("Eugen", "Vashkevich", 22, "Brest", 45.5, 2004,12,1);
Console.WriteLine(Minsk.GetAllInfo());
Minsk.AddTicket("Ekaterina", "Vashkevich", 34, "Brest", 55.5, 2002, 1,6);
Console.WriteLine(Minsk.GetTotalPriceBySecondName("Vashkevich"));
Minsk.AddTicket("Vladislav", "Kornilchik", 21, "Gomel", 55.5, 2002, 1,6);
Console.WriteLine(Minsk.GetPassagersForDirection("Brest"));
Console.WriteLine(Minsk.GetAllInfo());


