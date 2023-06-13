using _1.DATA.IRepositories;
using _1.DATA.Model;
using _2.API.ViewModel.NhaCungCap;
using _2.API.ViewModel.PhieuNhap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapsController : ControllerBase
    {
        private IAllRepositories<NhaCungCap> _repo;


        public NhaCungCapsController(IAllRepositories<NhaCungCap> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllNhaCungCap()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có nhà cung cấp");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetNhaCungCapById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy nhà cung cấp");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNhaCungCap([FromForm] CreateNhaCungCap ccv)
        {
            NhaCungCap cv = new NhaCungCap()
            {
                Id = Guid.NewGuid(),
                Ten = ccv.Ten,
                DiaChi = ccv.DiaChi,
                Sdt = ccv.Sdt,
                TrangThai = ccv.TrangThai,
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
        [Route("Update/id")]
        public async Task<IActionResult> UpdateNhaCungCap(Guid id, [FromForm] UpdateNhaCungCap ccv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy nhà cung cấp");
            }
            else
            {
                result.Ten = ccv.Ten;
                result.DiaChi = ccv.DiaChi;
                result.Sdt = ccv.Sdt;
                result.TrangThai = ccv.TrangThai;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy nhà cung cấp");
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
