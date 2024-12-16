namespace DealershipCenter.ViewModels;

public partial class AnalyticsViewModel : ObservableObject
{
    private IObjectsLoader ObjectsLoader { get; }

    [ObservableProperty]
    private ModelCarItem? selectedModelCarItem = default;

    [ObservableProperty]
    private ObservableCollection<ModelCarItem> modelCars = [];
    [ObservableProperty]
    private IEnumerable<PieSeries<ObservableValue>> salesAmountsByYears = [];

    [ObservableProperty]
    private double maxValuePieChart;

    public AnalyticsViewModel(IObjectsLoader objectsLoader)
    {
        ObjectsLoader = objectsLoader;
    }

    [RelayCommand]
    private async Task SelectModelCar()
    {
        ModelCars.Clear();

        ModelCars = new ObservableCollection<ModelCarItem>(await ObjectsLoader.LoadModelsCars());
    }

    [RelayCommand]
    private async Task LoadDataByYears()
    {
        if (SelectedModelCarItem is null)
            return;

        var statisticDataByAllYearsDictionary = await ObjectsLoader.LoadStatisticsByModelCarByAllYears(SelectedModelCarItem);

        if (statisticDataByAllYearsDictionary is null || !statisticDataByAllYearsDictionary.Any())
            return;

        MaxValuePieChart = (double)statisticDataByAllYearsDictionary.Max(x => x.Value)! * 1.2;

        SalesAmountsByYears = GaugeGenerator.BuildSolidGauge(statisticDataByAllYearsDictionary
                                      .Select(x => new GaugeItem((double)x.Value!, series => InternalsTools.SetMultiGaugePieStyle(x.Key.ToString(), series))).ToArray());
    }  
}