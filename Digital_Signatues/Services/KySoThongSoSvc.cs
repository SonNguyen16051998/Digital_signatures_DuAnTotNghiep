using Digital_Signatues.Models;
using Digital_Signatues.Models.ViewPost;
using Digital_Signatues.Models.ViewPut;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IKySoThongSo
    {
        Task<int> AddThongSoNguoiDungAsync(PostKySoThongSo PostKySoThongSo);//them thong so cho nguoi dung
        Task<KySoThongSo> GetThongSoNguoiDungAsync(int ma_nguoidung);//lay thong so cua mot nguoi dung
        Task<List<KySoThongSo>> GetThongSoNguoiDungsAsync();//lay toan bo nguoi dung co thong so
        Task<bool> CheckThemThongSo(int ma_nguoidung);//kiem tra nguoi dung da co thong so hay chua
        Task<int> UpdateThongSoAsync(PutThongSo PutThongSo);//cap nhat thong so  nguoi dung
        Task<bool> ChangePasscode (PutPasscode putPasscode);//doi passcode
        Task<bool> CauHinhChuKyAsync(PostCauHinhFileChuKy cauHinhFileChuKy);//cấu hình file pfx
        Task<bool> CapNhatThongSoFileAsync(PostThongSoFilePfx ThongSofilePfx);//lay thong so file pfx
    }
    public class KySoThongSoSvc
    {
        private readonly DataContext _context;
        public KySoThongSoSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<int> AddThongSoNguoiDung(PostKySoThongSo PostKySoThongSo)
        {
            int ret = 0;
            try
            {
                var thongso = new KySoThongSo()
                {
                    Ma_NguoiDung = PostKySoThongSo.Ma_NguoiDung,
                    Hinh1 = PostKySoThongSo.Hinh1,
                    Hinh2 = PostKySoThongSo.Hinh2,
                    LyDoMacDinh = PostKySoThongSo.LyDoMacDinh,
                    PassCode = PostKySoThongSo.PassCode,
                    Ma_NguoiCapNhatCuoi = PostKySoThongSo.Ma_NguoiCapNhatCuoi,
                    NgayCapNhatCuoi = System.DateTime.Now,
                    TrangThai = PostKySoThongSo.TrangThai,
                    LoaiChuKy = null,
                    NgayChuKyHetHan = PostKySoThongSo.NgayChuKyHetHan,
                    Serial = null,
                    Subject = null,
                    Ma_NguoiKyThuCuoi = null,
                    NgayKyThuCuoi = null,
                    FilePfx =null,
                    PasscodeFilePfx =null
                };
                await _context.KySoThongSos.AddAsync(thongso);
                await _context.SaveChangesAsync();
                ret = PostKySoThongSo.Ma_NguoiDung;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public async Task<KySoThongSo> GetThongSoNguoiDungAsync(int ma_nguoidung)
        {
            return await _context.KySoThongSos.Where(x => x.Ma_NguoiDung == ma_nguoidung).FirstOrDefaultAsync();
        }
        public async Task<List<KySoThongSo>> GetThongSoNguoiDungsAsync()
        {
            return await _context.KySoThongSos.ToListAsync();
        }
        public async Task<bool> CheckThemThongSo(int ma_nguoidung)
        {
            bool result = false;
            try
            {
                var thongso = await _context.KySoThongSos.Where(x => x.Ma_NguoiDung == ma_nguoidung).FirstOrDefaultAsync();
                if (thongso == null)
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public async Task<int> UpdateThongSoAsync(PutThongSo PutThongSo)
        {
            int ret = 0;
            try
            {
                var capnhatthongso = await _context.KySoThongSos
                    .Where(x => x.Ma_NguoiDung == PutThongSo.Ma_NguoiDung).FirstOrDefaultAsync();
                capnhatthongso.Hinh1 = PutThongSo.Hinh1;
                capnhatthongso.Hinh2 = PutThongSo.Hinh2;
                capnhatthongso.LyDoMacDinh = PutThongSo.LyDoMacDinh;
                capnhatthongso.Ma_NguoiCapNhatCuoi = PutThongSo.Ma_NguoiCapNhatCuoi;
                capnhatthongso.NgayCapNhatCuoi = System.DateTime.Now;
                capnhatthongso.TrangThai = PutThongSo.TrangThai;

                _context.KySoThongSos.Update(capnhatthongso);
                await _context.SaveChangesAsync();
                ret = PutThongSo.Ma_NguoiDung;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public async Task<bool> ChangePasscode(PutPasscode putPasscode)
        {
            bool result = false;
            try
            {
                var thongso = await _context.KySoThongSos.Where(x => x.Ma_NguoiDung == putPasscode.Ma_NguoiDung).FirstOrDefaultAsync();
                thongso.PassCode = putPasscode.PassCode;
                _context.KySoThongSos.Update(thongso);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> CauHinhChuKyAsync(PostCauHinhFileChuKy cauHinhFileChuKy)
        {
            bool result = false;
            try
            {
                var thongso = await _context.KySoThongSos
                    .Where(x => x.Ma_NguoiDung == cauHinhFileChuKy.Ma_NguoiDung).FirstOrDefaultAsync();
                thongso.FilePfx = cauHinhFileChuKy.FilePfx;
                thongso.PasscodeFilePfx = cauHinhFileChuKy.PasscodeFilePfx;
                thongso.LoaiChuKy = false;
                _context.KySoThongSos.Update(thongso);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> CapNhatThongSoFileAsync(PostThongSoFilePfx ThongSofilePfx)
        {
            bool result = false;
            try
            {
                var thongso = await _context.KySoThongSos
                    .Where(x => x.Ma_NguoiDung == ThongSofilePfx.Ma_NguoiDung).FirstOrDefaultAsync();
                thongso.Subject = ThongSofilePfx.Subject;
                thongso.Serial = ThongSofilePfx.Serial;
                _context.KySoThongSos.Update(thongso);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
