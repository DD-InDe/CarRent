using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? Color { get; set; }

    public double? CarPrice { get; set; }

    public double? RentPrice { get; set; }

    public int? BrandModelId { get; set; }

    public int? CarStatusId { get; set; }

    public string? CarVin { get; set; }

    public virtual BrandModel? BrandModel { get; set; }

    public virtual ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();

    public virtual CarStatus? CarStatus { get; set; }
}
