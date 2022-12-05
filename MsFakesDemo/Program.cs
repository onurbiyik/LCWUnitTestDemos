// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Greeter
{
    public string Greet()
    {
        var timeOfDay = DateTime.Now;

        return timeOfDay.Hour switch
        {
            > 04 and < 11 => "Günaydın",
            > 11 and < 17 => "İyi günler",
            > 17 and < 21 => "İyi akşamlar",
            _ => "İyi geceler"
        };
    }
}