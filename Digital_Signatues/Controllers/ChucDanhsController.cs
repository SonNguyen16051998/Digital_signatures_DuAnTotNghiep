using Digital_Signatues.Models;
using Digital_Signatues.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digital_Signatues.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChucDanhsController : Controller
    {
        private readonly IChucDanh _chucDanh;
        public ChucDanhsController(IChucDanh chucDanh)
        {
            _chucDanh = chucDanh;
        }
        /// <summary>
        /// hiển thị toàn bộ chức danh
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ChucDanh>> GetChucDanhsAsync()
        {
            return await _chucDanh.GetChucDanhsAsync();
        }
        /// <summary>
        /// trả về chức danh vừa chọn
        /// </summary>
        /// <param name="id">mã chức danh</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ChucDanh> GetChucDanhAsync(int id)
        {
            return await _chucDanh.GetChucDanhAsync(id);
        }
        /// <summary>
        /// thêm chức danh
        /// </summary>
        /// <param name="chucDanh">trong object chức danh chỉ cần truyền về tên chức danh còn lại để null</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostChucDanhAsync([FromBody] ChucDanh chucDanh)
        {// thêm chức danh chỉ cần gửi tên chức danh
            chucDanh.IsDeleted = false;
            chucDanh.Oder = 0;
            if (ModelState.IsValid)
            {
                int id_ChucDanh = await _chucDanh.AddChucDanhAsync(chucDanh);
                if (id_ChucDanh> 0)
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Thêm chức danh thành công",
                        data = await _chucDanh.GetChucDanhAsync(id_ChucDanh)
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thêm chức danh thất bại",
                data = ""
            });
        }
        /// <summary>
        /// cập nhật chức danh
        /// </summary>
        /// <param name="chucDanh">truyền đầy đủ dữ liệu không được bỏ trống</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PutChucDanhAsync(ChucDanh chucDanh)
        {//cập nhật chức danh truyền đầy đủ dữ liệu
            if (ModelState.IsValid)
            {
                int id_chucDanh = await _chucDanh.UpdateChucDanhAsync(chucDanh);
                if ( id_chucDanh> 0)
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Cập nhật chức danh thành công",
                        data = await _chucDanh.GetChucDanhAsync(id_chucDanh)
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Cập nhật chức danh thất bại",
                data = ""
            });
        }
        /// <summary>
        /// xóa chức danh: chuyển trường isdeleted về true. chỉ có thể xóa khi không có người dùng
        /// </summary>
        /// <param name="id">mã chức danh</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteChucDanhAsync(int id)
        {
            if (await _chucDanh.DeleteChucDanhAsync(id))
            {
                return Ok(new
                {
                    retCode = 1,
                    retText = "Xóa chức danh thành công",
                    data = await _chucDanh.GetChucDanhAsync(id)
                });
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Xóa chức danh thất bại",
                data = ""
            });
        }
    }
}
