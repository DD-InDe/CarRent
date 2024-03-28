using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Passport
{
    public int Id { get; set; }

    public string? PassS { get; set; }

    public string? PassN { get; set; }

    public string? IssueBy { get; set; }

    public byte[]? Photo { get; set; }

    public DateTime? IssueDate { get; set; }

    public virtual User IdNavigation { get; set; } = null!;
}
