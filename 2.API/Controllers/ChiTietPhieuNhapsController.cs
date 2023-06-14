using _1.DATA.IRepositories;
using _1.DATA.Model;
using _2.API.ViewModel.ChiTietPhieuNhap;
using _2.API.ViewModel.PhieuNhap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuNhapsController : ControllerBase
    {
        private IAllRepositories<ChiTietPhieuNhap> _repo;


        public ChiTietPhieuNhapsController(IAllRepositories<ChiTietPhieuNhap> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllChiTietPhieuNhap()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có chi tiết phiếu nhập");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetChiTietPhieuNhapById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy chi tiết phiếu nhập");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateChiTietPhieuNhap([FromForm] CreateChiTietPhieuNhap ccv)
        {
            ChiTietPhieuNhap cv = new ChiTietPhieuNhap()
            {
                Id = Guid.NewGuid(),
                IdPhieuNhap = ccv.IdPhieuNhap,
                IdSPCT = ccv.IdSPCT,
                IdSize = ccv.IdSize,
                GiaNhap = ccv.GiaNhap,
                SoLuong = ccv.SoLuong,
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công" + ex);
            }

        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateChiTietPhieuNhap(Guid id, [FromForm] UpdateChiTietPhieuNhap ccv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy chi tiết phiếu nhập");
            }
            else
            {
                result.IdPhieuNhap = ccv.IdPhieuNhap;
                result.IdSPCT = ccv.IdSPCT;
                result.IdSize = ccv.IdSize;
                result.GiaNhap = ccv.GiaNhap;
                result.SoLuong = ccv.SoLuong;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy chi tiết phiếu nhập");
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
