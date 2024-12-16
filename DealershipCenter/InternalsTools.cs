namespace DealershipCenter;

public static class InternalsTools
{
    public static  void SetMultiGaugePieStyle(string name, PieSeries<ObservableValue> series)
    {

        series.Name = name;
        series.DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Start;
        series.DataLabelsSize = 1;
        series.InnerRadius = 52;
    }
}
