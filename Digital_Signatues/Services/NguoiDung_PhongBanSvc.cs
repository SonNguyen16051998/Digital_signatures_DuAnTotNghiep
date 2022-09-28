using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface INguoiDung_PhongBan
    {
        Task<bool> AddOrUpdateNguoiDung_PhongBanAsync(List<NguoiDung_PhongBan> nguoiDung_PhongBans);
        Task<bool> DeleteAlNothavelNguoiDung_PhongBanAsync(List<NguoiDung_PhongBan> nguoiDung_PhongBans);
        Task<List<NguoiDung_PhongBan>> GetNguoiDung_PhongBansAsync(int id_nguoiDung);//Hiển thị toàn bộ phòng ban đã có của người dùng
        Task<List<PhongBan>> GetNguoiDung_PhongBanNotHaveAsync(int id_nguoiDung);//lấy các phòng ban mà người dùng chưa có
    }
    public class NguoiDung_PhongBanSvc:INguoiDung_PhongBan
    {
        private readonly DataContext _context;
        public NguoiDung_PhongBanSvc(DataContext context)
        {
            _context = context; 
        }

        public async Task<bool> AddOrUpdateNguoiDung_PhongBanAsync(List<NguoiDung_PhongBan> nguoiDung_PhongBans)
        {
            bool ret = false;
            try
            {
                foreach (var item in nguoiDung_PhongBans)
                {
                    NguoiDung_PhongBan nguoiDung_phongBan = new NguoiDung_PhongBan();
                    nguoiDung_phongBan = await _context.NguoiDung_PhongBans.Where(x => x.Ma_NguoiDung == item.Ma_NguoiDung
                                      && x.Ma_PhongBan == item.Ma_PhongBan).FirstOrDefaultAsync();//
                    if (nguoiDung_phongBan != null)//kiểm tra người dùng đã nằm trong phòng ban này chưa
                    {
                        continue;
                    }
                    else//chưa thì thêm vào
                    {
                        await _context.NguoiDung_PhongBans.AddAsync(item);
                    }
                }
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public async Task<bool> DeleteAlNothavelNguoiDung_PhongBanAsync(List<NguoiDung_PhongBan> nguoiDung_PhongBans)
        {
            bool ret = false;
            try
            {
                List<NguoiDung_PhongBan> nguoiDung_phongBannothave = new List<NguoiDung_PhongBan>();
                List<int> id_NguoiDung_phongban = (from p in nguoiDung_PhongBans
                                                   select p.Ma_PhongBan).ToList();
                //lấy các phòng ban mà người dùng bỏ đi và xóa nó
                nguoiDung_phongBannothave = await _context.NguoiDung_PhongBans.Where(x => !id_NguoiDung_phongban.Contains(x.Ma_PhongBan)
                                          && x.Ma_NguoiDung == nguoiDung_PhongBans[0].Ma_NguoiDung).ToListAsync();
                foreach (var item in nguoiDung_PhongBans)
                {
                    _context.NguoiDung_PhongBans.Remove(item);
                }
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public async Task<List<NguoiDung_PhongBan>> GetNguoiDung_PhongBansAsync(int id_nguoiDung)
        {
            List<NguoiDung_PhongBan> nguoiDung_phongbans = new List<NguoiDung_PhongBan>();
            nguoiDung_phongbans = await _context.NguoiDung_PhongBans.Where(x => x.Ma_NguoiDung == id_nguoiDung)
                            .Include(x => x.PhongBan).ToListAsync();
            return nguoiDung_phongbans;
        }

        public async Task<List<PhongBan>> GetNguoiDung_PhongBanNotHaveAsync(int id_nguoiDung)
        {
            List<NguoiDung_PhongBan> nguoiDung_phongbans = new List<NguoiDung_PhongBan>();
            nguoiDung_phongbans = await _context.NguoiDung_PhongBans.Where(x => x.Ma_NguoiDung == id_nguoiDung)
                                .ToListAsync();
            List<int> Id_Phongban = new List<int>();
            Id_Phongban = (from p in nguoiDung_phongbans
                       select p.Ma_PhongBan).ToList();
            List<PhongBan> phongbans = new List<PhongBan>();
            phongbans = await _context.PhongBans.Where(x => !Id_Phongban.Contains(x.Ma_PhongBan)).ToListAsync();
            return phongbans;
        }
    }
}
