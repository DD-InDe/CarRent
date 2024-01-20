using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class BrendModel
{
    public int BrendModelId { get; set; }

    public int? BrendId { get; set; }

    public int? ModelId { get; set; }

    public int? ClassId { get; set; }

    public virtual Brend? Brend { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Class? Class { get; set; }

    public virtual Model? Model { get; set; }
}
