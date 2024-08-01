using System;
using System.Collections.Generic;

namespace QL_QuanBi_a_API.Models;

public partial class Chitietdv
{
    public int Mabienlai { get; set; }

    public int Madv { get; set; }

    public int? Soluong { get; set; }

    public virtual Bienlai MabienlaiNavigation { get; set; } = null!;

    public virtual Dichvu MadvNavigation { get; set; } = null!;
}
