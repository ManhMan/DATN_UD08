﻿using _1_API.ViewModel.GioHang;
using _1.DATA.IRepositories;
using _1.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangsController : ControllerBase
    {
        private IAllRepositories<GioHang> _repo;


        public GioHangsController(IAllRepositories<GioHang> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllGioHang()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có giỏ hàng");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetGioHangById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy giỏ hàng");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateGioHang([FromForm] CreateGioHang ccv)
        {
            GioHang cv = new GioHang()
            {
                Id = Guid.NewGuid(),
                IdKH = ccv.IdKhacHang
            };
            try
            {
                var result = await _repo.AddOneAsyn(cv);
                return Ok(cv);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Tạo mới không thành công");
            }

        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateGioHang(Guid id,CreateGioHang ucv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng");
            }
            else
            {
                result.IdKH = ucv.IdKhacHang;
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy giỏ hàng");
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
