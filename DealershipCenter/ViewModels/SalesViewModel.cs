namespace DealershipCenter.ViewModels;

public  partial class SalesViewModel : ObservableObject
{
    private DbContextOptions<DealershipCenterDBContext> dbContextOptions { get; }
    private  ISaverFile SaverFile { get; }
    private IExportToExcelService ExportToExcelService { get; }
    private IObjectsLoader ObjectsLoader { get; }

    [ObservableProperty]
    private ObservableCollection<SaleofCarItem> salesCars = [];
    [ObservableProperty]
    private ObservableCollection<ModelCarItem> modelCars = [];
    [ObservableProperty]
    private ModelCarItem? selectedModelCarItem = default;

    public SalesViewModel(
        DbContextOptions<DealershipCenterDBContext> options,
        ISaverFile saverFile,
        IExportToExcelService exportToExcelService,
        IObjectsLoader objectsLoader)
    {
        dbContextOptions = options;
        SaverFile = saverFile;
        ExportToExcelService = exportToExcelService;
        ObjectsLoader = objectsLoader;
    }

    [RelayCommand]
    private async Task ExportToExcel ()
    {
        if (SelectedModelCarItem is null)
            return;

        var pathToFile = SaverFile.SaveFileToPath(
            FileTool.ReplaceInvalidCharsInFileName($"{SelectedModelCarItem.Name} {DateTime.Now.ToString("G")}.xlsx", "-"),
            Constatns.ExcelFilterFile);

        if (string.IsNullOrWhiteSpace(pathToFile))
            return;

        var MainHeader = $"Выгрузка по {SelectedModelCarItem.Name}";

        var headersDocuments = new List<string>
        {
            Resources.Color,
            Resources.ComlectaionModel,
            Resources.DateofSale,
            Resources.PriceofSales,
        };

        var exportData = new List<IList<CellExcel>>();

        foreach(var sale in SalesCars)
        {
            var excelRow = new List<CellExcel>()
            {
                new(CellExcelType.String,sale.Color),
                new(CellExcelType.String,sale.Complectation),
                new(CellExcelType.DateTime,sale.Date),
                new(CellExcelType.Decimal,sale.Amount),

            };
            exportData.Add(excelRow);

        }
        await ExportToExcelService.ExportToExcelAsync(MainHeader, headersDocuments, exportData, pathToFile);
    }

    [RelayCommand]
    private async Task LoadDataToSelectedModelCar()
    {
        if(SelectedModelCarItem is null)
            return;

        SalesCars.Clear();

        SalesCars = new ObservableCollection<SaleofCarItem>(await ObjectsLoader.LoadSalesBySelectedModelCar(SelectedModelCarItem));
    }

    [RelayCommand]
    private async Task SelectModelCar()
    {
        ModelCars.Clear();

        ModelCars = new ObservableCollection<ModelCarItem>(await ObjectsLoader.LoadModelsCars());
    }
}