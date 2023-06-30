using _1.DATA.Model;
using _4.ClientView.StrConnection;
using _4.CusView.IServices;
using _4.CusView.ModelRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
            if (Request.Cookies["Email"] != null)
            {
                ViewData["Email"] = Request.Cookies["Email"];
                ViewData["Pass"] = Request.Cookies["Pass"];          
                return View();
            }
            return View();
        }
        public async Task<IActionResult> CheckDangNhap(LoginRequest request)
        {

            if (ModelState.IsValid)
            {

                ViewData["loginfalse"] = "";
                if (HttpContext.Session.GetString("idkh") != null)
                {
                    ViewData["loginfalse"] = "Bạn đã đăng nhập rồi";
                    return View("DangNhap");
                }
                else
                {
                    var lstKH = await _services.GetAll<KhachHang>(StrConnection.api + "KhachHangs/Get-All");
                    if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.MatKhau))
                    {
                        ViewData["thongbao"] = "Tài khoản hoặc mật khẩu không được để trống";
                        return View("DangNhap");
                    }
                    else
                    {
                        var kh = lstKH.FirstOrDefault(p => p.Email == request.Email && p.MatKhau == request.MatKhau);
                        if (kh != null)
                        {
                            HttpContext.Session.SetString("idkh", kh.Id.ToString());
                            HttpContext.Session.SetString("ten", kh.Ten ?? "");
                            var lstGH = await _services.GetAll<GioHang>(StrConnection.api + "GioHangs/Get-All");
                            var gh = lstGH.FirstOrDefault(x => x.IdKH == kh.Id);
                            if (gh != null)
                            {
                                HttpContext.Session.SetString("idgh", gh.Id.ToString());
                            }
                            if (request.Remember)
                            {
                                CookieOptions op = new CookieOptions()
                                {
                                    Expires = DateTime.Now.AddDays(30),
                                    HttpOnly = true
                                };
                                Response.Cookies.Append("Email", kh.Email, op);
                                Response.Cookies.Append("Pass", kh.MatKhau, op);

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {                              
                                Response.Cookies.Delete("Email");
                                Response.Cookies.Delete("Pass");
                                return RedirectToAction("Index", "Home");
                            }

                        }
                        else
                        {
                            ViewData["thongbao"] = "Sai tài khoản hoặc mật khẩu";
                            return View("DangNhap");


                        }
                    }
                }
            }
            return View("DangNhap");
        }
        public string ParseLai(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public static string ParseDi(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }	
}
