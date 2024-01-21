using System.Collections.Generic;

namespace CarRent.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BrendModel> BrendModels { get; set; } = new List<BrendModel>();
}
