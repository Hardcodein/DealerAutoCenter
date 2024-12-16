namespace Databases.DealershipCenters.Models;

public class SalesCars
{
    public long? Id { get; set; }
    public long? ModelId { get; set; }
    public long? ColorId { get; set; }
    public long? ComplectationId { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Amount { get; set; }

    public virtual ModelCars? ModelCar {  get; set; }
    public virtual ColorsCars? ColorCar { get; set; }
    public virtual ComplectationsCars? ComplectationCar { get; set; }

}
