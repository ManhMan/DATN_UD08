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
        //public async Task<IActionResult> CheckDangNhap(LoginRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        ViewData["loginfalse"] = "";
        //        if (HttpContext.Session.GetString("idkh") != null)
        //        {
        //            ViewData["loginfalse"] = "Bạn đã đăng nhập rồi";
        //            return View("DangNhap");
        //        }
        //        else
        //        {
        //            var lstKH = await _services.GetAll<KhachHang>(StrConnection.StrConnection.api + "KhachHangs/Get-All");
        //            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.MatKhau))
        //            {
        //                ViewData["loginfalse"] = "Tài khoản hoặc mật khẩu không được để trống";
        //                return View("DangNhap");
        //            }
        //            else
        //            {
        //                var kh = lstKH.FirstOrDefault(p => p.Email == request.Email && p.MatKhau == request.MatKhau);
        //                if (kh == null)
        //                {
        //                    ViewData["loginfalse"] = "Sai tài khoản hoặc mật khẩu";
        //                    return View("DangNhap");
        //                }
        //                else
        //                {
        //                    HttpContext.Session.SetString("idkh", kh.Id.ToString());
        //                    HttpContext.Session.SetString("ten", kh.Ten ?? "");

        //                    var lstGH = await _services.GetAll<GioHang>(StrConnection.StrConnection.api + "GioHangs/Get-All");
        //                    var gh = lstGH.FirstOrDefault(x => x.IdKH == kh.Id);
        //                    if (gh != null)
        //                        HttpContext.Session.SetString("idgh", gh.Id.ToString());
        //                    return RedirectToAction("Index", "Home");
        //                }
        //            }
        //        }
        //    }
        //    return View("DangNhap");
        //}
    }
}
