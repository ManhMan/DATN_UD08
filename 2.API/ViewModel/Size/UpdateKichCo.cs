using System.ComponentModel.DataAnnotations;

namespace _1_API.ViewModel.KichCo
{
    public class UpdateKichCo
    {
        [Required(ErrorMessage = "Vui lòng nhập Size")]
        public float? KichCo { get; set; }
    }
}
