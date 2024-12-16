namespace DealershipCenter.Models;

public class CellExcel
{
    public  CellExcelType Type { get; }
    public object? Value { get; }
    public CellExcel(
        CellExcelType type,
        object? value)
    {
        Type = type;
        Value = value;
    }

}
public enum CellExcelType
{ 
    DateTime,
    String,
    Decimal
}
