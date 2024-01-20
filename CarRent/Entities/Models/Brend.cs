using System;
using System.Collections.Generic;

namespace CarRent.Models;

public partial class Brend
{
    public int BrendId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BrendModel> BrendModels { get; set; } = new List<BrendModel>();
}
