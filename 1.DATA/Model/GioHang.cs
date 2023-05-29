﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class GioHang
    {
        public GioHang()
        {
            giohangChitiets = new HashSet<GioHangChiTiet>();
        }

        public Guid Id { get; set; }
        public Guid? IdKH { get; set; }
        public KhachHang? KhachHang { get; set; }
        public virtual ICollection<GioHangChiTiet> giohangChitiets { get; set; }
    }
}
