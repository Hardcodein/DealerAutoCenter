namespace Databases.DealershipCenters.Models;
public class ModelCars
{
    public long? Id { get; set; }
    public long? BrandId { get; set; }
    public string? Name { get; set; }

    public virtual BrandsCars? Brand { get; set; }

    public virtual ICollection<SalesCars>? Sales {  get; set; }
}
