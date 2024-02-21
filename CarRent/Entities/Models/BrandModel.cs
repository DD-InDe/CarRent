using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class BrandModel
{
    public int BrandModelId { get; set; }

    public int? BrandId { get; set; }

    public int? ModelId { get; set; }

    public int? ClassId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Class? Class { get; set; }

    public virtual Model? Model { get; set; }
}
