using System;
using System.Collections.Generic;

namespace DapperApi.Models;

public partial class DapperApiTable
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }
}
