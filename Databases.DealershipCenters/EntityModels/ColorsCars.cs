namespace Databases.DealershipCenters.Models;
public class ColorsCars
{
    public long? Id {  get; set; }
    public string? Name { get; set; }

    public virtual ICollection<SalesCars>? Sales { get; set; }
}
