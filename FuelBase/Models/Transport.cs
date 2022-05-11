using System.ComponentModel.DataAnnotations;

namespace FuelBase.Models;

public class Transport
{
    [Key]
    public int Id { get; set; }

    //Идентификация ТС
    [Required]
    public int RouteNumber { get; set; }
    public string? TransportType { get; set; }

    //Груз
    public string? CargoType { get; set; }
    public int CargoNowTon { get; set; }
    public int CargoCapacityTon { get; set; }

    //Топливо
    public string? FuelType { get; set; }
    public int FuelNowLitre { get; set; }
    public int FuelCapacityLitre { get; set; }

    //Координаты
    public double GpsLatitudeNow { get; set; }
    public double GpsLongitudeNow { get; set; }
}