using _1_API.ViewModel.GioHangChiTiet;
using _1.DATA.IRepositories;
using _1.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2.API.ViewModel.GioHangChiTiet;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietsController : ControllerBase
    {
        private IAllRepositories<GioHangChiTiet> _repo;
        private IAllRepositories<SanPhamChiTiet> _spct;
        private IAllRepositories<HinhAnh> _hinhanh;
        private IAllRepositories<Size> _size;
        private IAllRepositories<MauSac> _mausac;

        public GioHangChiTietsController(IAllRepositories<GioHangChiTiet> repo, IAllRepositories<SanPhamChiTiet> spct, IAllRepositories<Size> size, IAllRepositories<MauSac> mausac, IAllRepositories<HinhAnh> hinhanh)
        {
            _repo = repo;
            _spct = spct;
            _size = size;
            _mausac = mausac;
            _hinhanh = hinhanh;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllGioHangChiTiet()
        {
            var ghcts = await _repo.GetAllAsync();
            var spcts = await _spct.GetAllAsync();
            var mausacs = await _mausac.GetAllAsync();
            var hinhanhs = await _hinhanh.GetAllAsync();
            var sizes = await _size.GetAllAsync();


            var result = from g in ghcts
                         join s in spcts on g.IdSPChitiet equals s.Id
                         join m in mausacs on s.IdMauSac equals m.Id
                         join sz in sizes on g.IdSize equals sz.Id
                         join h in hinhanhs on s.Id equals h.IdSPCT
                         where h.TrangThai == true
                         select new ViewGioHangChiTiet()
                         {
                             Id = g.Id,
                             AnhSanPham = h.LinkAnh,
                             TenSanPham = s.TenSPChiTiet,
                             LoaiHang = "[ "+ sz.KichCo.ToString()+" ]" + " " +"[ "+ m.TenMau+" ]",
                             GiaBan = s.GiaBan,
                             SoLuong = g.SoLuong,
                             idGiohang = g.IdGioHang,
                             IdSPChitiet = s.Id,
                             IdSize = g.IdSize,
                         };
            if (result == null) return new OkObjectResult(new { message = "Không có sản phẩm nào trong giỏ hàng. <a href='/'>Quay lại trang chủ</a>", error = -1});
            return new OkObjectResult(new { message = "Oke", error = 0,data= result });
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetGioHangChiTietById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy giỏ hàng chi tiết");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateGioHangChiTiet(CreateGioHangChiTiet cnv)
        {

            try
            {
                GioHangChiTiet nv = new GioHangChiTiet()
                {
                    Id = Guid.NewGuid(),
                    IdSPChitiet = cnv.IdSPChitiet,
                    IdSize = cnv.IdSize,
                    IdGioHang = cnv.IdGioHang,
                    SoLuong = cnv.SoLuong,
                };
                var result = await _repo.AddOneAsyn(nv);
                return new OkObjectResult(new { message = "Thêm vào giỏ hàng thành công", error = 0 });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new { message = "Có lỗi xảy ra hãy thử lại sau đó.", error = -2 });
            }

        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateGioHangChiTiet(Guid id, UpdateGiohangChiTiet unv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng chi tiết");
            }
            else
            {
                result.IdSPChitiet = unv.IdSPChitiet;
                result.IdSize = unv.IdSize;
                result.IdGioHang = unv.IdGioHang;
                result.SoLuong = unv.SoLuong;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return new OkObjectResult(new { message = "Cập nhập giỏ hàng thành công", error = 0 });
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new { message = "Có lỗi xảy ra hãy thử lại sau đó.", error = -2 });
                }


            }

        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteGioHangChiTiet(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng chi tiết");
            }
            else
            {
                try
                {
                    await _repo.DeleteOneAsyn(result);
                    return new OkObjectResult(new { message = "Xóa sản phẩm thành công", error = 0 });
                }
                catch (Exception ex)
                {
                    return new OkObjectResult(new { message = "Có lỗi xảy ra hãy thử lại sau đó.", error = -2 });
                }


            }
        }
    }
}
