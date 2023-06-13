using _1_API.ViewModel.GioHangChiTiet;
using _1.DATA.IRepositories;
using _1.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietsController : ControllerBase
    {
        private IAllRepositories<GioHangChiTiet> _repo;

        public GioHangChiTietsController(IAllRepositories<GioHangChiTiet> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllGioHangChiTiet()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có giỏ hàng chi tiết");
            return Ok(result);
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
            GioHangChiTiet nv = new GioHangChiTiet()
            {
                IdSPChitiet = cnv.IdSPChitiet,
                IdSize = cnv.IdSize,
                IdGioHang = cnv.IdGioHang,
                SoLuong = cnv.SoLuong,
            };
            try
            {
                var result = await _repo.AddOneAsyn(nv);
                return Ok(nv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công");
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
