using StarwarsApi.ApiDataAccess;
using StarwarsApi.DTOs;
using StarWarsPlanetsStats.ApiDataAccess;
using System.Numerics;
using System.Text.Json;


try
{
    await new StarWarsPlanetStatsApp(
        new ApiDataReader(), 
        new MockStarWarsApiDataReader()).Run();
}catch(Exception ex)
{
    Console.WriteLine("An Error Occured" + "Error Message: " + ex.Message);
}

Console.WriteLine("Hello, World!");
Console.ReadKey();


public class StarWarsPlanetStatsApp
{

    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;

    public StarWarsPlanetStatsApp(
        IApiDataReader apiDataReader,
        IApiDataReader secondaryApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;

    }

    
    public async Task Run()
    {
        string? json = null;

        try
        {

            json = await _apiDataReader.Read(
                "https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("Api request was unseccessful" +
                " switching to mockData" +
                "Exception message: " + ex.Message);
        }
        json ??= await _secondaryApiDataReader.Read(
                "https://swapi.dev/", "api/planets");
        var root = JsonSerializer.Deserialize<Root>(json);
        //if (json is null)
        //{
        //    json = await _secondaryApiDataReader.Read(
        //        "https://swapi.dev/", "api/planets");
        //}

        var planets = ToPlanet(root);

        foreach (var planet in planets)
        {
            Console.WriteLine(planet);
        }

        var propertyNamesToSelctorMaping = new Dictionary<string, Func<Planet, int?>>
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["SurfaceWater"] = planet => planet.SurfaceWater,
        };

        Console.WriteLine();
        Console.WriteLine(
            "The statistics of which property you would" + 
            "like to see");
        Console.WriteLine(
            string.Join(
                Environment.NewLine,
                propertyNamesToSelctorMaping.Keys));

        var userChoice = Console.ReadLine();

        if (userChoice is null || 
            !propertyNamesToSelctorMaping.ContainsKey(userChoice))
        {
            Console.WriteLine("invalid Choice");
        }
        else
        {
            ShowStatistics(planets, 
                userChoice, 
                propertyNamesToSelctorMaping[userChoice]
            );
        }
    }


    private static void ShowStatistics(
        IEnumerable<Planet> planets,
        string propertyName, Func<Planet, int?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);

        //var planetWithMaxPropertyValue =
        //       planets.MaxBy(propertySelector);

        //Console.WriteLine($"Max {propertyName} is" +
        //    $" {propertySelector(planetWithMaxPropertyValue)}" +
        //    $"Planet :" + $"{propertySelector(planetWithMaxPropertyValue)}");


        //var planetWithMinPropertyValue =
        //    planets.MinBy(propertySelector);

        //Console.WriteLine($"Min Population is" +
        //    $" {propertySelector(planetWithMinPropertyValue)}" +
        //    $"Planet :" + $"{propertySelector(planetWithMinPropertyValue)}");
    }

    private static void ShowStatistics(
        string descriptor, 
        Planet selectedPlanet, 
        Func<Planet, int?> propertySelector, 
        string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is" +
            $" {propertySelector(selectedPlanet)}" +
            $"Planet {selectedPlanet}");
    }

    private static IEnumerable<Planet> ToPlanet(Root? root)
    {
        if(root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        return root.results.Select(
            planetDto => (Planet)planetDto);

        //var planet = new List<Planet>();

        //foreach (var planetDTOs in root.results)
        //{
        //    Planet planets = (Planet)planetDTOs;
        //    planet.Add(planets);
        //}
        //return planet;
    }

}

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public int? Population { get; }

    public Planet(string name, int diameter, int? surfaceWater, int? population)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;

        var diameter = int.Parse(planetDto.diameter);

        int? population = planetDto.population.ToIntOrNull();

        int? surfaceWater = planetDto.surface_water.ToIntOrNull();

        return new Planet(name, diameter, population, surfaceWater);
    }

   
}

public static class StringExtentions
{
    public static int? ToIntOrNull(this string? input)
    {
        return int.TryParse(
            input, out int resultParsed)
            ? resultParsed
            : null;
    }
}
