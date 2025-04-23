using System.Globalization;
using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using static System.Net.Mime.MediaTypeNames;

const string TicketFolder = @"C:\Users\lenovo T490\source\repos\UdemyCourse\TicketDataAggregator\Tickets";
try
{
    var ticketsAggregator = new TicketAggregator( TicketFolder );

    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An Exception occured" +
    "Exception message" + ex.Message);
}


Console.WriteLine();
Console.ReadKey();

public class TicketAggregator
{
    private readonly string _ticketFolder;
    private readonly Dictionary<string, string> _DomainToCultureMapping = new()
    {
        [".com"] = "en-US",
        [".fr"] = "fr-FR",
        [".jp"] = "ja-JP"
    };

    public TicketAggregator(string ticketFolder)
    {
        _ticketFolder = ticketFolder;
    }

    public void Run()
    {
        var stringBuilder = new StringBuilder();

        foreach (var filePath in Directory.GetFiles(
            _ticketFolder, "*.pdf"))
        {
            using PdfDocument document = PdfDocument.Open(
                filePath);

            Page page = document.GetPage(1);
            string text = page.Text;
            var split = text.Split(
                new[] {"Title: ", "Date: ", "Time: "}, 
                StringSplitOptions.None);

            var domain = ExtractDomain(split.Last());
            var ticketCulture = _DomainToCultureMapping[domain];
            Console.WriteLine($"[DEBUG] PDF Content:\n{text}");


            for (var i = 1; i < split.Length - 3; i += 3)
            {
                var title = split[i];
                var dateAsString = split[i + 1];
                var timeAsString = split[i + 2];

                var date = DateOnly.Parse(
                    dateAsString, new CultureInfo(ticketCulture));
                var time = TimeOnly.Parse(
                    timeAsString, new CultureInfo(ticketCulture));

                var dateAsStringInvariant = date.ToString(
                    CultureInfo.InvariantCulture);
                var timeAsStringInvariant = time.ToString(
                    CultureInfo.InvariantCulture);

                var ticketData =
                    $"{title, -40} | {dateAsStringInvariant} | {timeAsStringInvariant}";

                stringBuilder.AppendLine(ticketData);
            }
        }

        var resultPath = Path.Combine(
            _ticketFolder, "AggregatedTickets.txt");
        File.WriteAllText(resultPath, stringBuilder.ToString());
        Console.WriteLine("result saved to " + resultPath);
    }

    private static string ExtractDomain(string webAddress)
    {
        var lastDotIndex = webAddress.LastIndexOf('.');
        return webAddress.Substring(lastDotIndex);
    }
}