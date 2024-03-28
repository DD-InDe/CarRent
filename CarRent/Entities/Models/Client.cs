using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? MailAddress { get; set; }

    public virtual DriverLicense? DriverLicense { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
