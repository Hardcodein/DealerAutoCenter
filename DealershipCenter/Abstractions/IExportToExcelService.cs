namespace DealershipCenter.Abstractions;

public  interface IExportToExcelService
{
    Task ExportToExcelAsync(string mainTitle, List<string> headersDocument, List<IList<CellExcel>> expordData, string pathToFile);
}