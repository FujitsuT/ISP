using System.Runtime.InteropServices.JavaScript;
using G253504_VashkevichLab5.Entities;

namespace G253504_VashkevichLab5.Contracts;

public interface IContract
{
    void AddTicket(string firstName, string secondName, int age, string nameOfRate, double priceOfRate, int year,
        int month, int day);

    string? GetAllInfo();

    double? GetTotalPriceBySecondName(string secondName);

    double? GetTotalPriceByAllTickets();

    String? GetPassagersForDirection(String direction);
}