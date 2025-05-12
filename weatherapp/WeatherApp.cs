using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace weatherappsim;
public class WeatherApp
{
    private List<City> Cities;
    private SmhiWeatherService SmhiService;
    public WeatherApp()
    {
        SmhiService = new SmhiWeatherService();
        Cities = new List<City>
        {
            new City("Stockholm", 59.3293, 18.0686),
            new City("Malmö", 55.6050, 13.0038),
            new City("Norrtälje", 59.7577, 18.6986),
            new City("Luleå", 65.5848, 22.1567)
        };
    }
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Weather App");
            DisplayCities();
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. View Weather");
            Console.WriteLine("2. Update Weather");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewWeather();
                    break;
                case "2":
                    RealWeatherUpdate().Wait();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter.");
                    Console.ReadLine();
                    break;
            }
        }
    }
    private void DisplayCities()
    {
        for (int i = 0; i < Cities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Cities[i].Name}");
        }
    }
    private void ViewWeather()
    {
        Console.Write("\nEnter city number: ");
        if (int.TryParse(Console.ReadLine(), out int cityIndex) && cityIndex >= 1 && cityIndex <= Cities.Count)
        {
            var city = Cities[cityIndex - 1];
            if (city.Weather != null)
            {
                Console.WriteLine($"\nWeather in {city.Name}: {city.Weather}");
            }
            else
            {
                Console.WriteLine("Update first.");
            }
        }
        else
        {
            Console.WriteLine("Invalid.");
        }
        Console.WriteLine("\nPress Enter to return.");
        Console.ReadLine();
    }
    private async Task RealWeatherUpdate()
    {
        foreach (var city in Cities)
        {
           // Console.WriteLine($"Fetching weather for {city.Name}...");
            var data = await SmhiService.GetRealWeatherAsync(city.Latitude, city.Longitude);
            if (data != null)
            {
                city.Weather = data;
                //(Console.WriteLine($"  Success: {data}");
            }
            else
            {
               // Console.WriteLine("  Failed.");
            }
        }
        //Console.WriteLine("\nWeather update complete. Press Enter.");
        Console.ReadLine();
    }
}
