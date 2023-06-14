using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class MaGiamGia : Entity
    {
        public MaGiamGia()
        {
            hoaDons = new HashSet<HoaDon>();
        }
        public string? Ma { get; set; }
        public DateTime NgayBatdau { get; set; }
        public DateTime NgayKetthuc { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }
        public int PhanTramGiam { get; set; }
        public virtual ICollection<HoaDon> hoaDons { get; set; }
    }
}
