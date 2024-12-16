namespace DealershipCenter.Composer;
internal static class InitialComposer
{
    public static  Container InitializeContainer (this Container container)
    {
        var config = new ConfigurationBuilder().AddJsonFile($"appsettings.json",true,true).Build();
       
        var databaseSettings = new DatabaseSettings 
        {
            ConntectionString = config["DealershipCenterDatabaseConnectionString"]
        };

        databaseSettings.Validate();

        container.RegisterInstance(databaseSettings);

        var builder = new DbContextOptionsBuilder<DealershipCenterDBContext>();
        builder.UseNpgsql(databaseSettings.ConntectionString);

        container.RegisterInstance(builder.Options);

        container.RegisterSingleton<ISaverFile, SaverFile>();
        container.RegisterSingleton<IExportToExcelService, ExportToExcelService>();
        container.RegisterSingleton<IObjectsLoader, ObjectsLoader>();

        container.Register<MainViewModel>();
        container.Register<SalesViewModel>();
        container.Register<AnalyticsViewModel>();

        container.Register<MainWindow>();

        return container;
    }
}