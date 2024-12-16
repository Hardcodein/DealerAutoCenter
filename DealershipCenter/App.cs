namespace DealershipCenter;
public class App : Application
{
    
    public void Start()
    {
        var container = new Container();
        container.InitializeContainer();

        try
        {
            var view = container.GetInstance<MainWindow>();
            var vm = container.GetInstance<MainViewModel>();
            view.DataContext = vm;
            view.Show();
        }
        catch
        {
            throw;
        }
    }
       
    
}
