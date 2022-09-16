﻿using Digital_Signatues.Services;
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
    [Route("api/[controller]/[action]")]
    public class NguoiDungsController : Controller
    {
        private readonly INguoiDung _nguoiDung;
        public NguoiDungsController(INguoiDung nguoiDung)
        {
            _nguoiDung=nguoiDung;
        }
        /// <summary>
        /// trả về toàn bộ người dùng kèm theo chức danh và phòng ban thuộc vào
        /// </summary>
        /// <returns></returns>
        [HttpGet,ActionName("nguoidung")]
        public async Task<List<NguoiDung>> GetNguoiDungsAsync() //lấy toàn bộ danh sách người dùng
        {
            return await _nguoiDung.GetNguoiDungsAsync();
        }
        /// <summary>
        /// trả về người dùng được chọn
        /// </summary>
        /// <param name="id">mã người dùng</param>
        /// <returns></returns>
        [HttpGet("{id}"),ActionName("nguoidung")]
        public async Task<NguoiDung> GetNguoiDungAsync(int id) //lấy người dùng bằng mã người dùng
        {
            return await _nguoiDung.GetNguoiDungAsync(id);
        }
        /// <summary>
        /// thêm người dùng. không cần truyền trường block và isdeleted. cần nhập email chưa đăng ký tài khoản
        /// </summary>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>
        [HttpPost,ActionName("nguoidung")]
        public async Task<IActionResult> PostNguoiDungAsync([FromBody]NguoiDung nguoiDung)
        {
            nguoiDung.Block = false;
            nguoiDung.IsDeleted = false;
            if(ModelState.IsValid)
            {
                if(await _nguoiDung.isEmail(nguoiDung.Email))
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Email đã tồn tại",
                        data = "" 
                    });
                }
                else
                {
                    int id_NguoiDung = await _nguoiDung.AddNguoiDungAsync(nguoiDung);
                    if (id_NguoiDung > 0)
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "Thêm người dùng thành công",
                            data = await _nguoiDung.GetNguoiDungAsync(id_NguoiDung)
                        });
                    } 
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
        /// cập nhật thông tin người dùng.cần truyền đầy đủ thông tin bao gồm trường block và isdeleted. không cho cập nhật email
        /// </summary>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>
        [HttpPut,ActionName("nguoidung")]
        public async Task<IActionResult> UpdateNguoiDungAsync([FromBody]NguoiDung nguoiDung)
        {
            if(ModelState.IsValid)
            {
                int id_nguoiDung = await _nguoiDung.UpdateNguoiDungAsync(nguoiDung);
                if (id_nguoiDung>0)
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Cập nhật thông tin người dùng thành công",
                        data = await _nguoiDung.GetNguoiDungAsync(id_nguoiDung)
                    }) ;
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Cập nhật người dùng thất bại",
                data = ""
            });
        }
        /// <summary>
        /// đổi mật khẩu
        /// </summary>
        /// <param name="changePass">mật khẩu từ 6 đến 30 kí tự</param>
        /// <returns></returns>
        [HttpPut,ActionName("doimatkhau")]
        public async Task<IActionResult> DoiMatKhauAsync([FromBody]ViewChangePass changePass)
        {
            if(ModelState.IsValid)
            {
                if(await _nguoiDung.isPass(changePass.Email,changePass.PassWord))
                {
                    await _nguoiDung.ChangePassAsync(changePass);
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Đổi mật khẩu thành công",
                        data = new {
                            Email=changePass.Email,
                            Password=changePass.NewPass
                        }
                    });
                }
                else
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Mật khẩu củ không chính xác",
                        data = ""
                    });
                }    
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Đổi mật khẩu thất bại",
                data = ""
            });
        }
        /// <summary>
        /// chức năng cập nhật mật khẩu khi đã xác nhận mã otp thành công
        /// </summary>
        /// <param name="quenMatKhau"></param>
        /// <returns></returns>
        [HttpPut,ActionName("quenmatkhau")]
        public async Task<IActionResult> QuenMatKhauAsync([FromBody]ViewQuenMatKhau quenMatKhau)
        {
            //xác nhận mã OTP thành công cho qua trang cập nhật mật khẩu mới
            if(ModelState.IsValid)
            {
                if(await _nguoiDung.QuenMatKhauAsync(quenMatKhau))
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Cập nhật mật khẩu thành công",
                        data = new
                        {
                            Email=quenMatKhau.Email,
                            NewPass=quenMatKhau.NewPass
                        }
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Cập nhật mật khẩu thất bại",
                data = ""
            });
        }
        /// <summary>
        /// chức năng nhận mã OTP khi xác nhận xong capcha và nhập email chính xác. cần nhập email đã có tài khoản
        /// </summary>
        /// <param name="maOTP">trả về obect OTP chỉ cần trả về email. còn lại trả về null</param>
        /// <returns></returns>
        [HttpPut,ActionName("maotp")]
        public async Task<IActionResult> CreateOrUpdateOTPAsync(OTP maOTP)//truyền về email,mặc định(otp=null,isuse=false)
        {
            maOTP.Otp = RandomOTPHelper.random();
            maOTP.isUse = false;
            maOTP.expiredAt = DateTime.Now.AddMinutes(2);
            if(ModelState.IsValid)
            {
                if(await _nguoiDung.isEmail(maOTP.email))
                {
                    if (await _nguoiDung.CreateOrUpdateOTPAsync(maOTP))
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "Mã otp đã được gửi đến email",
                            data = new
                            {
                                Email=maOTP.email,
                                OTP=maOTP.Otp
                            }
                        });
                    }
                }
                else
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Email không tồn tại",
                        data = ""
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
        /// chức năng xác nhận mã OTP
        /// </summary>
        /// <param name="maOTP">truyền về object OTP gồm email, mã otp, còn lại có thể để null</param>
        /// <returns></returns>
        [HttpPut,ActionName("xacnhanotp")]
        public async Task<IActionResult> XacNhanOTP(OTP maOTP)//truyền về email và mã otp ,mặc định isuse=false
        {
            if(ModelState.IsValid)
            {
                if(await _nguoiDung.ConfirmOTPAsync(maOTP.email,maOTP.Otp))
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Mã OTP chính xác",
                        data = ""
                    });
                }
                else
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Mã OTP đã hết hạn hoặc đã sử dụng",
                        data = ""
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
    }
}