using _1_API.ViewModel.SanphamChitiet;
using _4.ClientView.StrConnection;
using _4.CusView.IServices;
using _4.CusView.ModelRequest;
using _4.CusView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _4.CusView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllServices _services;
        public HomeController(ILogger<HomeController> logger, IAllServices services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var lstSp = await _services.GetAllViewSPCT<SanPhamChiTietRequest>(StrConnection.api + "sanphamchitiets/get-view-all");
            return View(lstSp);
        }
        public async Task<IActionResult> ChiTietSanPham(Guid id)
        {
            var spct = await _services.GetById<ChiTietSanPhamChiTietRequest>(StrConnection.api + "sanphamchitiets/GetByIdView/", id);
            return View(spct);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}