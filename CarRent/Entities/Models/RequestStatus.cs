using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class RequestStatus
{
    public int RequestStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
