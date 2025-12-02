// See https://aka.ms/new-console-template for more information
using datingapp1;
using ViewModel;

CityDB cdb = new();
CityList cityList = cdb.SelectAll();
foreach(City c in cityList)
    Console.WriteLine(c.Name);