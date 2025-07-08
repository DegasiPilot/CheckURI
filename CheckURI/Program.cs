namespace CheckURI;

class Program
{
    static void Main(string[] args)
    {
        System.Diagnostics.Debug.WriteLine("UriHelper tests result: " + URIHelper.RunTests());
        Console.ReadKey();
    }
}