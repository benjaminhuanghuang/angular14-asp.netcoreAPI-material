﻿using System;
using System.Collections.Generic;

namespace EmployeeAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public int? IdDepartment { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? HireDate { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }
}
