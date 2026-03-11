using System;
using System.Collections.Generic;

namespace StudentAndHostelMangement.Models;

public partial class Hostel
{
    public int Id { get; set; }

    public int? RoomNo { get; set; }

    public int? CollegeId { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
