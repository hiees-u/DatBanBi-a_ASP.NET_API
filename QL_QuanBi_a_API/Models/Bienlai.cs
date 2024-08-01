using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Bienlai
{
    public int Mabienlai { get; set; }

    public string Manhanvien { get; set; } = null!;

    public int Maban { get; set; }

    public int? Makh { get; set; }

    public DateTime? Ngaylap { get; set; }

    public DateTime? Giobd { get; set; }

    public DateTime? Giokt { get; set; }

    public double? Tongtien { get; set; }

    public virtual ICollection<Chitietdv> Chitietdvs { get; set; } = new List<Chitietdv>();

    public virtual Ban MabanNavigation { get; set; } = null!;

    public virtual Khachhang? MakhNavigation { get; set; }

    public virtual Nhanvien ManhanvienNavigation { get; set; } = null!;
}
