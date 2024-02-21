﻿using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Model
{
    public int ModelId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BrandModel> BrandModels { get; set; } = new List<BrandModel>();
}
