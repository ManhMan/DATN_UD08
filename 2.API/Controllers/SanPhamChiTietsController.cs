using _1_API.ViewModel.SanPham;
using _1_API.ViewModel.SanphamChitiet;
using _1.DATA.IRepositories;
using _1.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _1_API.ViewModel.SizeSanPham;
using System.Collections.Generic;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamChitietsController : ControllerBase
    {
        private IAllRepositories<SanPhamChiTiet> _repo;
        private IAllRepositories<SanPham> _sp;
        private IAllRepositories<TheLoaiSanPham> _theloaisprepo;
        private IAllRepositories<HinhAnh> _hinhanhprepo;
        private IAllRepositories<MauSac> _mausacrepo;
        private IAllRepositories<Size> _size;
        private IAllRepositories<SizeSanPham> _sizesanpham;


        public SanphamChitietsController(IAllRepositories<SanPhamChiTiet> repo, IAllRepositories<TheLoaiSanPham> theloaisprepo, IAllRepositories<HinhAnh> hinhanhprepo, IAllRepositories<MauSac> mausacrepo, IAllRepositories<Size> size, IAllRepositories<SizeSanPham> sizesanpham, IAllRepositories<SanPham> sp)
        {
            _repo = repo;
            _theloaisprepo = theloaisprepo;
            _hinhanhprepo = hinhanhprepo;
            _mausacrepo = mausacrepo;
            _size = size;
            _sizesanpham = sizesanpham;
            _sp = sp;
        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllSanPhamCt()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có sản phẩm chi tiết");
            return Ok(result);
        }
        [HttpGet]
        [Route("get-view-all")]
        public async Task<IActionResult> GetViewAll()
        {
            try
            {
                var spcts = await _repo.GetAllAsync();
                var hinhanhs = await _hinhanhprepo.GetAllAsync();
                var mausacs = await _mausacrepo.GetAllAsync();
                if (spcts != null)
                {
                    var result = (from a in spcts
                                  join b in hinhanhs on a.Id equals b.IdSPCT
                                  join c in mausacs on a.IdMauSac equals c.Id
                                  where b.TrangThai == true
                                  select new ViewSanPhamChiTiet
                                  {
                                      Id = a.Id,
                                      GiaBan = a.GiaBan,
                                      TrangThai = a.TrangThai.ToString(),
                                      TenMauSac = c.TenMau,
                                      MaSPChiTiet = a.MaSPChiTiet,
                                      TenSPChiTiet = a.TenSPChiTiet,
                                      AnhDaiDien = b.LinkAnh,
                                  });
                    return new OkObjectResult(new { message = "Thành công", error = 0, data = result });
                }
                else
                {
                    return new OkObjectResult(new { message = "Tạm thời không có sản phẩm nào", error = -2 });
                }

            }
            catch (Exception ex)
            {
                return new OkObjectResult(new { message = "error Exception", error = -1, data = ex });
            }

        }
        [HttpGet]
        [Route("GetByIdView/{id}")]
        public async Task<IActionResult> GetByIdView(Guid id)
        {
            try
            {
                var spct = await _repo.GetByIdAsync(id);
                if (spct != null)
                {
                    var hinhanhs = await _hinhanhprepo.GetAllAsync();
                    var mausacs = await _mausacrepo.GetAllAsync();
                    var sizes = await _size.GetAllAsync();
                    var sizesanphams = await _sizesanpham.GetAllAsync();
                    var sps = await _sp.GetAllAsync();
                    var tenSP = sps.FirstOrDefault(x => x.Id == spct.IdSP).Ten;
                    var mausacSP = mausacs.FirstOrDefault(x => x.Id == spct.IdMauSac).TenMau;
                    var listsize = (from a in sizesanphams.Where(x => x.IdSanPhamChiTiet == id)
                                    join c in sizes on a.IdSize equals c.Id
                                    where a.SoLuong > 0
                                    orderby c.KichCo ascending
                                    select new SizeSanPhamModel()
                                    {
                                        Id = a.IdSize,
                                        Size = c.KichCo.ToString(),
                                        SoLuong = a.SoLuong
                                    });
                    var listImage = (from a in hinhanhs.Where(x => x.IdSPCT == id)
                                     where a.isDelete == false
                                     orderby a.TrangThai ascending
                                     select new ListImage()
                                     {
                                         linkAnh = a.LinkAnh
                                     });
                    var result = new ViewChiTietSanPhamChiTiet() { 
                        idsqct = id,
                        giaban = spct.GiaBan,
                        ten = tenSP == null ? null: tenSP,
                        mausac = mausacSP == null ? null : mausacSP,
                        lstsize = listsize.ToList(),
                        lstanh = listImage.ToList()
                    };

                    return new OkObjectResult(new { message = "Thành công", error = 0, data = result });
                }
                else
                {
                    return new OkObjectResult(new { message = "Không tìm được thông tin sản phẩm", error = -2 });
                }

            }
            catch (Exception ex)
            {
                return new OkObjectResult(new { message = "Có lỗi sảy ra! Hãy thử lại sau", error = -1, data = ex });
            }
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetSanPhamCtById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy sản phẩm chi tiết");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateSanPhamCt(CreateSanphamChitiet csp)
        {
            var ma = await _repo.GetAllAsync();

            var listmau = await _mausacrepo.GetAllAsync();
            var tenmau = listmau.ToList().FirstOrDefault(p => p.Id == csp.IdMauSac);
            SanPhamChiTiet spct = new SanPhamChiTiet()
            {
                Id = Guid.NewGuid(),
                IdSP = csp.IdSP,
                IdMauSac = csp.IdMauSac,
                GiaBan = csp.GiaBan,
                TrangThai = csp.TrangThai,
                TenSPChiTiet = csp.TenChiTiet + " Màu " + tenmau.TenMau,
                MaSPChiTiet = "SP" + ma.Count(),
            };

            try
            {
                var result = await _repo.AddOneAsyn(spct);
                foreach (var item in csp.Selected)
                {
                    TheLoaiSanPham tlsp = new TheLoaiSanPham()
                    {
                        Id = Guid.NewGuid(),
                        IdChiTietSP = spct.Id,
                        IdTheLoai = Guid.Parse(item),
                    };
                    await _theloaisprepo.AddOneAsyn(tlsp);
                }


                return Ok(spct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công");
            }

        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateSanPhamCt(Guid id, UpdateSanphamChitiet usp)
        {
            var result = await _repo.GetByIdAsync(id);
            var listmau = await _mausacrepo.GetAllAsync();
            var tenmau = listmau.ToList().FirstOrDefault(p => p.Id == usp.IdMauSac);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy sản phẩm chi tiết");
            }
            else
            {

                result.IdSP = usp.IdSP;
                result.IdMauSac = usp.IdMauSac;
                result.GiaBan = usp.GiaBan;
                result.TrangThai = usp.TrangThai;
                result.TenSPChiTiet = usp.TenSPChiTiet + " Màu " + tenmau.TenMau;
                var lsttlsp = await _theloaisprepo.GetAllAsync();
                lsttlsp = lsttlsp.Where(p => p.IdChiTietSP == result.Id);

                try
                {
                    await _repo.UpdateOneAsyn(result);
                    foreach (var item in lsttlsp)
                    {
                        await _theloaisprepo.DeleteOneAsyn(item);
                    }
                    foreach (var item in usp.Selected)
                    {
                        TheLoaiSanPham tlsp = new TheLoaiSanPham()
                        {
                            Id = Guid.NewGuid(),
                            IdChiTietSP = result.Id,
                            IdTheLoai = Guid.Parse(item),
                        };
                        await _theloaisprepo.AddOneAsyn(tlsp);
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công");
                }


            }

        }
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy sản phẩm chi tiết");
            }
            else
            {
                try
                {
                    await _repo.DeleteOneAsyn(result);
                    return Ok("Xóa thành công");
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Xóa không thành công");
                }


            }
        }
    }
}
