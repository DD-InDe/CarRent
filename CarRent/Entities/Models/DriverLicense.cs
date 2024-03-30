using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class DriverLicense
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public DateTime? DataOfIssue { get; set; }

    public DateTime? ExpirationData { get; set; }

    public byte[]? Photo { get; set; }

    public virtual Client IdNavigation { get; set; } = null!;
}
