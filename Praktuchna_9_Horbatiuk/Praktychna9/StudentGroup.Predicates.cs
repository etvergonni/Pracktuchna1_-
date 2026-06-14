using System;
using System.Collections.Generic;
using System.Linq;

namespace Praktychna9;

public partial class StudentGroup
{
    public List<Student> FilterStudents(Predicate<Student> predicate)
        => GetAllStudents().Where(s => predicate(s)).ToList();

    public List<Student> SortStudents(Comparison<Student> comparison)
    {
        var list = GetAllStudents();
        list.Sort(comparison);
        return list;
    }
}
