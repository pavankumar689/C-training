using System;
using System.Collections.Generic;

namespace StudentAndHostelMangement.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public virtual Hostel? Hostel { get; set; }
}
