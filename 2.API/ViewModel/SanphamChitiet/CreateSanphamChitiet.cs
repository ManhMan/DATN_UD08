using System.ComponentModel.DataAnnotations;

namespace _1_API.ViewModel.SanphamChitiet
{
    public class CreateSanphamChitiet
    {
        public Guid? IdSP { get; set; }
        public Guid? IdMauSac { get; set; }
        public string? TenChiTiet { get; set; }
        public decimal GiaBan { get; set; }
        public int? TrangThai { get; set; }
        public IList<string> Selected { get; set; }
        
    }
}
