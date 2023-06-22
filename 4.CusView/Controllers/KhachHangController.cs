using _4.CusView.IServices;
using Microsoft.AspNetCore.Mvc;

namespace _4.CusView.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ILogger<KhachHangController> _logger;
        private readonly IAllServices _services;
        public KhachHangController(ILogger<KhachHangController> logger, IAllServices services)
        {
            _logger = logger;
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        
    }
}
