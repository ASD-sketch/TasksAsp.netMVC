using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Department
{
    public int Id { get; set; }

    public string DeptName { get; set; } = null!;

    public string Manager { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int StaffCount { get; set; }
}
