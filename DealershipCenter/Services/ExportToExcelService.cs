namespace DealershipCenter.Services;
public class ExportToExcelService : IExportToExcelService
{
    public async Task ExportToExcelAsync(string mainTitle, List<string> headersDocument, List<IList<CellExcel>> expordData, string pathToFile)
    {
        await Task.Run(() =>
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Use1904DateSystem = true;

                var worksheet = workbook.Worksheets.Add("Лист 1");

                var row = worksheet.Row(1);

                var mainHeaderCell = row.Cell(1);
                mainHeaderCell.Value = mainTitle;
                mainHeaderCell.Style.Font.Bold = true;

                row = worksheet.Row(2);

                for (int i = 0; i < headersDocument.Count; i++)
                {
                    var cell = row.Cell(i+1);
                    cell.Value = headersDocument[i];
                    cell.Style.Font.Bold = true;
                }

                for (int i = 0; i < expordData.Count; i++)
                {
                    row = worksheet.Row(i + 3);

                    for (int j = 0; j < expordData[i].Count; j++)
                    {
                        var cell = row.Cell(j + 1);
                        var datacell = expordData[i][j];

                        switch (datacell.Type)
                        {
                            case CellExcelType.String:
                                {
                                    cell.Value = (string)datacell.Value!;
                                    break;

                                }
                            case CellExcelType.DateTime:
                                {
                                    cell.Value = (DateTime)datacell.Value!;
                                    break;

                                }
                            case CellExcelType.Decimal:
                                {
                                    cell.Value = (decimal)datacell.Value!;
                                    break;

                                }
                            default:
                                break;
                        }
                    }

                }
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(pathToFile);
            }
        });
    }
}
