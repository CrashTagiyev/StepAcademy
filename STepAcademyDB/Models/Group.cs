using System;
using System.Collections.Generic;

namespace STepAcademyDB.Models;

public partial class Group
{
    public int Id { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
