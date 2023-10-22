using System;
using System.Collections.Generic;

namespace STepAcademyDB.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public int? Average { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }
}
