﻿using _1_API.ViewModel.HoaDonChiTiet;
using _1_API.ViewModel.KhachHang;
using _1.DATA.IRepositories;
using _1.DATA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietsController : ControllerBase
    {
        private IAllRepositories<HoaDonChiTiet> _repo;

        public HoaDonChiTietsController(IAllRepositories<HoaDonChiTiet> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("Get-All")]
        public async Task<IActionResult> GetAllHoaDonChiTiet()
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return Ok("Không có hóa đơn chi tiết");
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetHoaDonChiTietById(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return Ok("Không tìm thấy hóa đơn chi tiết");
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateHoaDonChiTiet(CreateHoaDonChiTiet cnv)
        {
            HoaDonChiTiet nv = new HoaDonChiTiet()
            {
                IdSPChitiet = cnv.IdSPChitiet,
                IdHoaDon = cnv.IdHoaDon,
                IdSize = cnv.IdSize,
                SoLuong = cnv.SoLuong,
                GiaBan = cnv.GiaBan,
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
        public async Task<IActionResult> UpdateHoaDonChiTiet(Guid id, UpdateHoaDonChiTiet unv)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy hóa đơn chi tiết");
            }
            else
            {
                result.IdHoaDon = unv.IdHoaDon;
                result.IdSize = unv.IdSize;
                result.IdSPChitiet = unv.IdSPChitiet;
                result.SoLuong = unv.SoLuong;
                result.GiaBan = unv.GiaBan;
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
        public async Task<IActionResult> DeleteHoaDonChiTiet(Guid id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Không tìm thấy hóa đơn chi tiết");
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
