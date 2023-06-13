using _1.DATA.IRepositories;
using _1.DATA.Model;
using _2.API.ViewModel.ChiTietPhieuNhap;
using _2.API.ViewModel.Entity;
using _2.API.ViewModel.PhieuNhap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : ControllerBase
    {
        private IAllRepositories<Entity> _repo;


        public EntitiesController(IAllRepositories<Entity> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllEntity()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có Entity");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetEntityById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy Entity");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateEntity([FromForm] CreateEntity ccv)
        {
            Entity cv = new Entity()
            {
                CreateBy = ccv.CreateBy,
                UpdateBy = ccv.UpdateBy,
                DeleteBy = ccv.DeleteBy,
                CreateDate = ccv.CreateDate,
                UpdateDate = ccv.UpdateDate,
                DeleteDate = ccv.DeleteDate,
                isDelete = ccv.isDelete,
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
        public async Task<IActionResult> UpdateEntity(Guid id, [FromForm] UpdateEntity ccv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy Entity");
            }
            else
            {
                result.CreateBy = ccv.CreateBy;
                result.UpdateBy = ccv.UpdateBy;
                result.DeleteBy = ccv.DeleteBy;
                result.CreateDate = ccv.CreateDate;
                result.UpdateDate = ccv.UpdateDate;
                result.DeleteDate = ccv.DeleteDate;
                result.isDelete = ccv.isDelete;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy Entity");
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
