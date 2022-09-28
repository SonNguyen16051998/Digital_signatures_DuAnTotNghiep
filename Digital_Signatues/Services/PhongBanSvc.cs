using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IPhongBan
    {
        Task<List<PhongBan>> GetPhongBansAsync();
        Task<PhongBan> GetPhongBanAsync(int id);
        Task<bool> DeletePhongBanAsync(int id);
        Task<int> AddPhongBanAsync(PhongBan phongBan);
        Task<int> UpdatePhongBanAsync(PhongBan phongBan);
    }
    public class PhongBanSvc:IPhongBan
    {
        private readonly DataContext _context;
        public PhongBanSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<PhongBan>> GetPhongBansAsync()
        {
            List<PhongBan> phongBans = new List<PhongBan>();
            phongBans = await _context.PhongBans
                         .OrderBy(x=>x.Order)
                        .Include(x=>x.NguoiDung_PhongBan)
                        .ToListAsync();
            return phongBans;
        }

        public async Task<PhongBan> GetPhongBanAsync(int id)
        {
            PhongBan phongBan = new PhongBan();
            phongBan = await _context.PhongBans.Where(x => x.Ma_PhongBan == id)
                .Include(x=>x.NguoiDung_PhongBan)
                .FirstOrDefaultAsync();
            return phongBan;
        }

        public async Task<bool> DeletePhongBanAsync(int id)
        {
            bool ret = false;
            try
            {
                List<NguoiDung_PhongBan> nguoiDungs = new List<NguoiDung_PhongBan>();
                nguoiDungs = await _context.NguoiDung_PhongBans.Where(x => x.Ma_PhongBan == id).ToListAsync();
                if (nguoiDungs.Count > 0)
                {
                    ret = false;
                }
                else
                {
                    PhongBan phongBan = new PhongBan();
                    phongBan = await _context.PhongBans.Where(x => x.Ma_PhongBan == id).FirstOrDefaultAsync();
                    phongBan.IsDeleted = true;
                    _context.PhongBans.Update(phongBan);
                    await _context.SaveChangesAsync();
                    ret = true;
                }
            }
            catch { }
            return ret;
        }

        public async Task<int> AddPhongBanAsync(PhongBan phongBan)
        {
            int ret = 0;
            try
            {
                await _context.PhongBans.AddAsync(phongBan);
                await _context.SaveChangesAsync();
                ret = phongBan.Ma_PhongBan;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> UpdatePhongBanAsync(PhongBan phongBan)
        {
            int ret = 0;
            try
            {
                _context.PhongBans.Update(phongBan);
                await _context.SaveChangesAsync();
                ret = phongBan.Ma_PhongBan;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
