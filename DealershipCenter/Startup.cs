namespace DealershipCenter;

internal class Startup
{
    [STAThread]
    public static void Main(string[] args)
    {
        var app = new App();
       
        app.Start();
        app.Run();
    }
}
