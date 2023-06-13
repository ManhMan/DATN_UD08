using _1.DATA.IRepositories;
using _1.DATA.Model;
using _2.API.ViewModel.PhieuNhap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuNhapsController : ControllerBase
    {
        private IAllRepositories<PhieuNhap> _repo;


        public PhieuNhapsController(IAllRepositories<PhieuNhap> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllPhieuNhap()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có phiếu nhập");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetPhieuNhapById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy phiếu nhập");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePhieuNhap([FromForm] CreatePhieuNhap ccv)
        {
            PhieuNhap cv = new PhieuNhap()
            {
                Id = Guid.NewGuid(),
                IdNhaCungCap = ccv.IdNhaCungCap,
                IdNhanVien = ccv.IdNhanVien,
                MaPhieuNhap = ccv.MaPhieuNhap,
                TrangThai = ccv.TrangThai,
                GhiChu = ccv.GhiChu,
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công"+ex);
            }

        }

        [HttpPost]
        [Route("Update/id")]
        public async Task<IActionResult> UpdatePhieuNhap(Guid id, [FromForm] UpdatePhieuNhap ccv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy phiếu nhập");
            }
            else
            {
                result.IdNhaCungCap = ccv.IdNhaCungCap;
                result.IdNhanVien = ccv.IdNhanVien;
                result.MaPhieuNhap = ccv.MaPhieuNhap;
                result.TrangThai = ccv.TrangThai;
                result.GhiChu = ccv.GhiChu;
                try
                {
                    await _repo.UpdateOneAsyn(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Update không thành công" + ex);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy phiếu nhập");
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
                    return StatusCode(StatusCodes.Status500InternalServerError, "Xóa không thành công" + ex);
                }


            }
        }
    }
}
