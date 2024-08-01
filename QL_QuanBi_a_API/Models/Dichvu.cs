using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Dichvu
{
    public int Madv { get; set; }

    public string? Tendv { get; set; }

    public double? Dongia { get; set; }

    public string? Donvitinh { get; set; }

    public virtual ICollection<Chitietdv> Chitietdvs { get; set; } = new List<Chitietdv>();
}
