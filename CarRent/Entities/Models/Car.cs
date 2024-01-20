using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? Color { get; set; }

    public double? CarPrice { get; set; }

    public double? RentPrice { get; set; }

    public int? BrendModelId { get; set; }

    public int? CarStatusId { get; set; }

    public virtual BrendModel? BrendModel { get; set; }

    public virtual ICollection<CarImage> CarImages { get; set; } = new List<CarImage>();

    public virtual CarStatus? CarStatus { get; set; }
}
