using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Ban
{
    public int Maban { get; set; }

    public string? Tenban { get; set; }

    public bool? Loaiban { get; set; }

    public int? Khuvuc { get; set; }

    public bool? Tinhtrang { get; set; }

    public double? Giathue { get; set; }

    public virtual ICollection<Bienlai> Bienlais { get; set; } = new List<Bienlai>();

    public virtual ICollection<Datban> Datbans { get; set; } = new List<Datban>();
}
