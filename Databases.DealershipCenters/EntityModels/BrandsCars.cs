namespace Databases.DealershipCenters.Models;
public class BrandsCars
{
    public long? Id { get; set; }   
    public string? Name { get; set; }

    public virtual ICollection<ModelCars>? Models { get; set; }
}
