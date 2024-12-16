namespace DealershipCenter.ViewModels;

internal partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private SalesViewModel _salesViewModel;

    [ObservableProperty]
    private AnalyticsViewModel _analyticsViewModel;
    public MainViewModel(
        SalesViewModel salesViewModel,
        AnalyticsViewModel analyticsViewModel )
    {
        _salesViewModel = salesViewModel;
        _analyticsViewModel = analyticsViewModel;
    }
}
  
