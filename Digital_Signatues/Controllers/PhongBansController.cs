using Digital_Signatues.Services;
using Digital_Signatues.Models;
using Digital_Signatues.Models.ViewModel;
using Digital_Signatues.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Digital_Signatues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhongBansController : Controller
    {
        private readonly IPhongBan _phongBan;
        public PhongBansController(IPhongBan phongBan)
        {
            _phongBan = phongBan;
        }
        /// <summary>
        /// lấy toàn bộ phòng ban bao gồm nhân viên thuộc vào
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PhongBan>> GetPhongBansAsync()
        {
            return await _phongBan.GetPhongBansAsync();
        }
        /// <summary>
        /// hiển thị phòng ban được chọn bao gồm nhân viên thuộc vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<PhongBan> GetPhongBanAsync(int id)
        {
            return await _phongBan.GetPhongBanAsync(id);
        }
        /// <summary>
        /// thêm phòng ban
        /// </summary>
        /// <param name="phongBan">truyền về object phongban.trường isdeleted,order và ngaytao để null</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostPhongBanAsync([FromBody]PhongBan phongBan)
        {
            phongBan.IsDeleted = false;
            phongBan.Order = 0;
            phongBan.NgayTao = DateTime.Now;
            if(ModelState.IsValid)
            {
                int id_Phongban = await _phongBan.AddPhongBanAsync(phongBan);
                if (id_Phongban>0)
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Thêm phòng ban thành công",
                        data = await _phongBan.GetPhongBanAsync(id_Phongban)
                    }) ;
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Dữ liệu không hợp lệ",
                data = ""
            });
        }
        /// <summary>
        /// cập nhật phòng ban
        /// </summary>
        /// <param name="phongBan">truyền đầy đủ dữ liệu của object phongban</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutPhongbanAsync(PhongBan phongBan)
        {
            if (ModelState.IsValid)
            {
                int id_Phongban = await _phongBan.UpdatePhongBanAsync(phongBan);
                if ( id_Phongban> 0)
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Cập nhật phòng ban thành công",
                        data = await _phongBan.GetPhongBanAsync(id_Phongban)
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Dữ liệu không hợp lệ",
                data = ""
            });
        }
        /// <summary>
        /// xóa phòng ban. chuyển trường isdeleted về true. chỉ xóa khi không có nhân viên
        /// </summary>
        /// <param name="id">mã phòng ban</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> DeletePhongbanAsync(int id)//id phòng ban
        {
            if(await _phongBan.DeletePhongBanAsync(id))
            {
                return Ok(new
                {
                    retCode = 1,
                    retText = "Xóa phòng ban thành công",
                    data = await _phongBan.GetPhongBanAsync(id)
                });
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Phòng ban đang có người làm việc không thể xóa",
                data = ""
            });
        }
    }
}
