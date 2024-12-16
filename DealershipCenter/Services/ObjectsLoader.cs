namespace DealershipCenter.Services;
class ObjectsLoader : IObjectsLoader
{
    private DbContextOptions<DealershipCenterDBContext> dbContextOptions { get; }
    public ObjectsLoader(DbContextOptions<DealershipCenterDBContext> options)
    {
        dbContextOptions = options;
    }

    public async Task<List<SaleofCarItem>> LoadSalesBySelectedModelCar(ModelCarItem carItem)
    {
        if (carItem is null)
            return [];

        var listDatabySelectedModelCar = new List<SaleofCarItem>();

        using (var context = new DealershipCenterDBContext(dbContextOptions))
        {
            listDatabySelectedModelCar = await (from sale in context.Sales
                                                where sale.ModelId == carItem.Id
                                                join color in context.Colors on sale.ColorId equals color.Id
                                                join complectation in context.Complectations on sale.ComplectationId equals complectation.Id
                                                select new SaleofCarItem()
                                                {
                                                    Color = color.Name,
                                                    Complectation = complectation.Name,
                                                    Date = sale.Date!.Value.ToLocalTime(),
                                                    Amount = sale.Amount,
                                                    IsExpensive = sale.Amount > Constatns.HighPrice,
                                                }).ToListAsync();
        }

        return listDatabySelectedModelCar;
    }

    public async Task<List<ModelCarItem>> LoadModelsCars()
    {
        var modelCars = new List<ModelCarItem>();

        using (var context = new DealershipCenterDBContext(dbContextOptions))
        {
            modelCars = await
                 (from model in context.Models
                  join brand in context.Brands on model.BrandId equals brand.Id
                  select new ModelCarItem()
                  {
                      Id = model.Id,
                      Name = model.Name,
                      BrandName = brand.Name!
                  }).ToListAsync();
        }

        return modelCars;
    }
    public async Task<Dictionary<int, decimal?>> LoadStatisticsByModelCarByAllYears(ModelCarItem modelcarItem)
    {
        var valuesStatisticbyItemCarByAllYears = new Dictionary<int, decimal?>();

        await Task.Run(() =>
        {
            using (var context = new DealershipCenterDBContext(dbContextOptions))
            {

                valuesStatisticbyItemCarByAllYears = context.Sales.Where(sale => sale.ModelId == modelcarItem.Id)
                                                                        .GroupBy(s => s.Date!.Value.Year)
                                                                            .ToDictionary(x => x.Key, x => x.Select(x => x.Amount).Sum());

            }
        });

        return valuesStatisticbyItemCarByAllYears;
    }
}

