namespace DealershipCenter.Abstractions;

public interface IObjectsLoader
{
    Task<Dictionary<int, decimal?>> LoadStatisticsByModelCarByAllYears(ModelCarItem modelcarItem);
    Task<List<SaleofCarItem>> LoadSalesBySelectedModelCar(ModelCarItem carItem);
    Task<List<ModelCarItem>> LoadModelsCars();
}