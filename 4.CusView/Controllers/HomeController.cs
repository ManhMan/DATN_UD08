using _1.DATA.Model;
using _1_API.ViewModel.GioHangChiTiet;
using _1_API.ViewModel.Hang;
using _1_API.ViewModel.SanphamChitiet;
using _2.API.ViewModel.GioHangChiTiet;
using _4.ClientView.StrConnection;
using _4.CusView.IServices;
using _4.CusView.ModelRequest;
using _4.CusView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace _4.CusView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllServices _services;
        private readonly IToastNotification _toast;
        public HomeController(ILogger<HomeController> logger, IAllServices services, IToastNotification toastNotification)
        {
            _logger = logger;
            _services = services;
            _toast = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            try
            {

                var lstSp = await _services.GetAllViewSPCT<SanPhamChiTietRequest>(StrConnection.api + "sanphamchitiets/get-view-all");
                if (lstSp.error == 0) return View(lstSp);
                return RedirectToAction("error");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }
        public async Task<IActionResult> Add(Guid id, Guid idSize, int soluong)
        {
            try
            {
                var spct = await _services.GetById<ChiTietSanPhamChiTietRequest>(StrConnection.api + "sanphamchitiets/GetByIdView/", id);
                if (spct == null)
                {
                    return View("Index");
                }
                else
                {
                    string idkh = HttpContext.Session.GetString("idkh");
                    string idgh = HttpContext.Session.GetString("idgh");
                    if (string.IsNullOrEmpty(idkh) && string.IsNullOrEmpty(idgh))
                    {
                        return RedirectToAction("DangNhap", "KhachHang");
                    }
                    else
                    {
                        if (idSize == Guid.Empty)
                        {

                            ViewBag.errorSize = "Vui lòng chọn size";
                            return View("ChiTietSanPham", spct);
                        }
                        else
                        {
                            if (soluong <= 0)
                            {
                                ViewBag.errorSoLuong = "Vui lòng nhập số lượng";
                                return View("ChiTietSanPham", spct);
                            }
                            else
                            {
                                var lstSanphamChitiet = await _services.GetAll<SanPhamChiTiet>(StrConnection.api + "SanphamChitiets/Get-All");
                                var spdb = lstSanphamChitiet.FirstOrDefault(x => x.Id == id);
                                var lstKichCo = await _services.GetAll<Size>(StrConnection.api + "sizes/Get-All");
                                var lstSizeSP = await _services.GetAll<SizeSanPham>(StrConnection.api + "SizeSanPhams/Get-All");
                                var sizesp = lstSizeSP.FirstOrDefault(x => x.IdSize == idSize && x.IdSanPhamChiTiet == id);
                                var ghcts = await _services.GetAllViewCart<CartRequest>(StrConnection.api + "GioHangChiTiets/Get-All");
                                var ghct = ghcts.data.FirstOrDefault(p => p.IdSPChitiet == id && p.idGiohang == Guid.Parse(idgh) && p.IdSize == idSize);
                                if (ghct == null)
                                {
                                    if (soluong > sizesp.SoLuong)
                                    {
                                        ViewBag.errorSoLuong = "Vượt quá số lượng trong kho!";
                                    }
                                    else
                                    {
                                        CreateGioHangChiTiet newGhct = new CreateGioHangChiTiet()
                                        {
                                            IdGioHang = Guid.Parse(idgh),
                                            IdSPChitiet = id,
                                            SoLuong = soluong,
                                            IdSize = idSize,
                                        };
                                        await _services.Add(StrConnection.api + "GioHangChiTiets/", newGhct);
                                        _toast.AddSuccessToastMessage("Thêm vào giỏ hàng thành công <a href='/cart/index'>Đi đến giỏ hàng</a>");
                                        return View("ChiTietSanPham", spct);

                                    }

                                }
                                else
                                {
                                    var respon = (from a in lstSanphamChitiet
                                                  join b in lstSizeSP on a.Id equals b.IdSanPhamChiTiet
                                                  join c in lstKichCo on b.IdSize equals c.Id
                                                  where a.Id == id
                                                  select new { a, b, c });
                                    var sl = respon.FirstOrDefault(x => x.a.Id == id);
                                    ghct.SoLuong++;
                                    if (ghct.SoLuong > sl.b.SoLuong)
                                    {
                                        ViewBag.errorSoLuong = "Vượt quá số lượng trong kho!";
                                    }
                                    else
                                    {
                                        await _services.Update(StrConnection.api + "GioHangChiTiets/Update/", ghct, ghct.Id);
                                        _toast.AddSuccessToastMessage("Cập nhập giỏ hàng thành công <a href='/cart/index'>Đi đến giỏ hàng</a>");
                                        return View("ChiTietSanPham", spct);
                                    }
                                }
                                return View("ChiTietSanPham", spct);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }


        }
        public async Task<IActionResult> ChiTietSanPham(Guid id)
        {
            try
            {
                var spct = await _services.GetById<ChiTietSanPhamChiTietRequest>(StrConnection.api + "sanphamchitiets/GetByIdView/", id);
                if (spct.error == 0) return View(spct);
                return RedirectToAction("error");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

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