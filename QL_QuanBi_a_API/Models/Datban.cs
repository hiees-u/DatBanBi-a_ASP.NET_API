using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Datban
{
    public int Madatban { get; set; }

    public string Tenkh { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Ghichu { get; set; }

    public bool? Trangthai { get; set; }

    public DateTime Thoigianden { get; set; }

    public int? Maban { get; set; }

    public virtual Ban? MabanNavigation { get; set; }
}
