using _1.DATA.Model;
using _1_API.ViewModel.KhachHang;
using _4.ClientView.StrConnection;
using _4.CusView.IServices;
using _4.CusView.ModelRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net.WebSockets;
using System;

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
            if (Request.Cookies.ContainsKey("Pass"))
            {
                ViewData["Email"] = Request.Cookies["Email"];
                var a = ParseLai(Request.Cookies["Pass"]);
                ViewData["Pass"] = a;
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
                                var a = ParseDi(kh.MatKhau);
                                Response.Cookies.Append("Pass", a, op);

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

        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("idkh");
            HttpContext.Session.Remove("ten");
            HttpContext.Session.Remove("idgh");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DangKy()
        {
            return View();
        }
        public async Task<IActionResult> CheckDangKy(DangKyRequestModel request)
        {
            if (ModelState.IsValid)
            {
                bool check = await CheckEmail_SDT(request.Email, request.Sdt);
                if (check == false)
                {
                    return View("DangKy"); 
                }
                else
                {
                    string a = TempData["mxn"].ToString();

					if (request.MaXacNhan == a)
                    {
                        var success = await _services.Add<DangKyRequestModel>(StrConnection.api + "KhachHangs/", request);
                        if (success != null)
                        {
                            ViewData["dangkythanhcong"] = "Đăng ký thành công!!!";
                            return View("DangNhap");
                        }
                        else
                        {
                            return View("DangKy");
                        }
                    }
                    else
                    {
                        return Ok("Sai mã xác nhận rồi");
                    }
                    
                }
            }
            return View("DangKy");
        }
        public async Task<bool> CheckEmail_SDT(string email, string sdt)
        {
            var lstKH = await _services.GetAll<KhachHang>(StrConnection.api + "KhachHangs/Get-All");
            var checkEmail = lstKH.FirstOrDefault(p=>p.Email == email);
            var checkSdt = lstKH.FirstOrDefault(p=>p.Sdt == sdt);
            //if (checkEmail != null && checkSdt!= null) 
            //{
            //    ViewData["thongbaoEmail"] = "Email đã tồn tại, vui lòng sử dụng Email khác!";
            //    ViewData["thongbaoSdt"] = "Số điện thoại đã tồn tại, vui lòng sử dụng SDDT khác!";
            //    return false;
            //}
            if (checkEmail!=null)
            {
				ViewData["thongbaoEmail"] = "Email đã tồn tại, vui lòng sử dụng Email khác!";
				return false;
			}
            if (checkSdt!=null) {
				ViewData["thongbaoSdt"] = "Số điện thoại đã tồn tại, vui lòng sử dụng SDDT khác!";
				return false;
			}
            return true;
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
		public async Task<IActionResult> LayMaXacNhan(DangKyRequestModel request)
		{
			var lstKH = await _services.GetAll<KhachHang>(StrConnection.api + "KhachHangs/Get-All");
			var checkEmail = lstKH.FirstOrDefault(p => p.Email == request.Email);
			if (checkEmail != null)
			{
				ViewData["thongbaoEmail"] = "Email đã tồn tại, vui lòng sử dụng Email khác!";
                ViewData["guiEmail"] = null;
			}
            else
            {
				ViewData["guiEmail"] = "Mã xác nhận đã được gửi đi!";
                guiEmail(request.Email,null);

            }
            return View("DangKy",request);
		}
		public static string GenerateRandomString(int length)
		{
			Random random = new Random();
			string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";char[] result = new char[length];
			bool hasLetter = false;
			bool hasDigit = false;

			for (int i = 0; i < length; i++)
			{
				result[i] = characters[random.Next(characters.Length)];

				if (char.IsLetter(result[i]))
				{
					hasLetter = true;
				}
				else if (char.IsDigit(result[i]))
				{
					hasDigit = true;
				}
			}

			if (!hasLetter || !hasDigit)
			{
				// Nếu chuỗi không có chữ hoặc không có số, thực hiện đệ quy để tạo lại chuỗi khác
				return GenerateRandomString(length);
			}

			return new string(result);
		}
		public async Task<IActionResult> UpdateKH()
		{
			var id = HttpContext.Session.GetString("idkh");
			Guid guidID = Guid.Parse(id);
			var kh = await _services.GetById<KhachHang>(StrConnection.api + "KhachHangs/GetById/", guidID);
            UpdateKhachHang view = new UpdateKhachHang()
			{
				Id = kh.Id,
				Ten = kh.Ten,
				DiaChi = kh.DiaChi,
				GioiTinh = kh.GioiTinh,
				Sdt = kh.Sdt,
				NgaySinh = kh.NgaySinh
			};
			return View(view);
		}

		public async Task<IActionResult> Updateing(UpdateKhachHang request)
		{
			var id = HttpContext.Session.GetString("idkh");
			Guid guidID = Guid.Parse(id);
            var kh = await _services.GetById<KhachHang>(StrConnection.api + "KhachHangs/GetById/", guidID);
            UpdateKhachHang up = new UpdateKhachHang()
			{
				Id = request.Id,
				Ten = request.Ten,
				DiaChi = request.DiaChi,
				Sdt = request.Sdt,
				NgaySinh = request.NgaySinh,
				GioiTinh = request.GioiTinh,
                Email = kh.Email,
                MatKhau = kh.MatKhau,
			};
			await _services.Update<UpdateKhachHang>(StrConnection.api +"KhachHangs/Update/", up, guidID);            
			return View("ThongTinKhachHang");

		}
        public async Task<IActionResult> ThongTinKhachHang()
        {
            var id = HttpContext.Session.GetString("idkh");
            Guid guidID = Guid.Parse(id);
            var kh = await _services.GetById<KhachHang>(StrConnection.api + "KhachHangs/GetById/", guidID);
            ViewKhachHang view = new ViewKhachHang()
            {
                Id = kh.Id,
                Ten = kh.Ten,
                DiaChi = kh.DiaChi,
                Email = kh.Email,
                GioiTinh = kh.GioiTinh,
                Sdt = kh.Sdt,
                NgaySinh = kh.NgaySinh
            };
            return View(view);
        }

        public IActionResult DoiMK()
        {
            return View();
        }

        public async Task<IActionResult> ThayDoiMK(ThayDoiMKRequest request)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Sdt) || string.IsNullOrEmpty(request.MatKhau))
                {
                    ViewData["check"] = "Email hoặc số điện thoại không được để trống";
                    return View("DoiMK");
                }

                var lstKH = await _services.GetAll<KhachHang>(StrConnection.api + "KhachHangs/Get-All");
                var tk = lstKH.FirstOrDefault(p => p.Email == request.Email && p.Sdt == request.Sdt && p.MatKhau == request.MatKhau);
                if (request.MatKhauMoi == request.NhapLaiMkm)
                {
                    if (tk != null)
                    {
                        tk.MatKhau = request.MatKhauMoi;

                        await _services.Update<KhachHang>(StrConnection.api + "KhachHangs/Update/", tk, tk.Id);
                        HttpContext.Session.Remove("idkh");
                        HttpContext.Session.Remove("ten");
                        HttpContext.Session.Remove("idgh");
                        ViewData["thanhcong"] = "Thay đổi mật khẩu thành công";
                        return View("DangNhap");
                    }
                    else
                    {
                        ViewData["loidmk"] = "Thông tin tài khoản không chính xác";
                        return View("DoiMK"); ;
                    }
                }
                else
                {
                    ViewData["loidmk"] = "Mật khẩu mới không trùng khớp, hãy nhập lại";
                    return View("DoiMK");
                }
            }
            else
            {
                return View("DoiMK");
            }
        }

        public IActionResult QuenMK()
        {
            return View();
        }
        public async Task<IActionResult> CheckQuenMK(QuenMK request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.SDT))
            {
                ViewData["check"] = "Email hoặc số điện thoại không được để trống";
                return View("QuenMK");
            }
            var lstKH = await _services.GetAll<KhachHang>(StrConnection.api + "KhachHangs/Get-All");
            var tk = lstKH.FirstOrDefault(p => p.Email == request.Email && p.Sdt == request.SDT);
            if (tk != null)
            {
                guiEmail(tk.Email, tk.MatKhau);
                ViewData["dangkythanhcong"] = "Lấy lại mật khẩu thành công. Vui lòng Kiểm tra email !";
                return View("DangNhap");
            }
            else
            {
                ViewData["check"] = "Email hoặc số điện thoại không đúng";
                return View("QuenMK");
            }
        }

        public void guiEmail(string email, string pass)
        {
            if (pass == null)
            {
                var maxacnhan = GenerateRandomString(6);
                TempData["mxn"] = maxacnhan;
                var fromAddress = new MailAddress("nguyenhuukhoa5462@gmail.com");
                var toAddress = new MailAddress(email);
                const string fromPassword = "mqanjbksawuxofko";
                string subject = "Mã xác nhận ";
                string body = "Mã xác nhận của bạn là: " + maxacnhan;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            else
            {
                var fromAddress = new MailAddress("nguyenhuukhoa5462@gmail.com");
                var toAddress = new MailAddress(email);
                const string fromPassword = "mqanjbksawuxofko";
                string subject = "Mã xác nhận ";
                string body = "Mật khẩu của bạn là: " + pass;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            
        }
        
    }
}
