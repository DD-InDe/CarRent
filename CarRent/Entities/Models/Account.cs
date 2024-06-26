﻿using System;
using System.Collections.Generic;

namespace CarRent.Entities.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual User? User { get; set; }
}
