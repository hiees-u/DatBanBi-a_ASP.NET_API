using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Khachhang
{
    public int Makh { get; set; }

    public string? Tenkh { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<Bienlai> Bienlais { get; set; } = new List<Bienlai>();
}
