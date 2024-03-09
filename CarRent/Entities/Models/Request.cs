using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Request
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? TotalPrice { get; set; }

    public int? CarId { get; set; }

    public int? RequestStatusId { get; set; }

    public int? ClientId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual User? Client { get; set; }

    public virtual RequestStatus? RequestStatus { get; set; }
}
