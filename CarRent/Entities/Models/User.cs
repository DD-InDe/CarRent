using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Account UserNavigation { get; set; } = null!;
}
