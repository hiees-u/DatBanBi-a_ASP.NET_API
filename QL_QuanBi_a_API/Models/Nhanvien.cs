using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Nhanvien
{
    public string Manhanvien { get; set; } = null!;

    public string Tennv { get; set; } = null!;

    public bool? Calam { get; set; }

    public string? Passnv { get; set; }

    public string? Quyen { get; set; }

    public virtual ICollection<Bienlai> Bienlais { get; set; } = new List<Bienlai>();
}
