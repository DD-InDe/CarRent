﻿using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class CarStatus
{
    public int CarStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
