namespace DealershipCenter.Models;
public  class SaleofCarItem
{
    public string? Color { get; set; }
    public string? Complectation { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Amount { get; set; }
    
    public bool IsExpensive { get; set; }
}
