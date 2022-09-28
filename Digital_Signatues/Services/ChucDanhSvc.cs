using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IChucDanh
    {
        Task<List<ChucDanh>> GetChucDanhsAsync();
        Task<ChucDanh> GetChucDanhAsync(int id);
        Task<bool> DeleteChucDanhAsync(int id);
        Task<int> AddChucDanhAsync(ChucDanh chucDanh);
        Task<int> UpdateChucDanhAsync(ChucDanh chucDanh);
    }
    public class ChucDanhSvc:IChucDanh
    {
       
        private readonly DataContext _context;
        public ChucDanhSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ChucDanh>> GetChucDanhsAsync()
        {
            List<ChucDanh> chucDanhs = new List<ChucDanh>();
            chucDanhs = await _context.ChucDanhs
                        .OrderBy(x=>x.Oder)    
                        .Include(x=>x.NguoiDung)
                        .ToListAsync();
            return chucDanhs;
        }

        public async Task<ChucDanh> GetChucDanhAsync(int id)
        {
            ChucDanh chucDanh = new ChucDanh();
            chucDanh = await _context.ChucDanhs.Where(x => x.Ma_ChucDanh == id)
                    .Include(x=>x.NguoiDung)
                    .FirstOrDefaultAsync();
            return chucDanh;
        }

        public async Task<bool> DeleteChucDanhAsync(int id)
        {
            bool ret = false;
            try
            {
                NguoiDung nguoiDung_ChucDanh=new NguoiDung();
                nguoiDung_ChucDanh=await _context.NguoiDungs.Where(x=>x.Ma_ChucDanh==id).FirstOrDefaultAsync();
                if (nguoiDung_ChucDanh!=null)
                {
                    ret = false;
                }
                else
                {
                    ChucDanh chucDanh = new ChucDanh();
                    chucDanh = await _context.ChucDanhs.Where(x => x.Ma_ChucDanh == id).FirstOrDefaultAsync();
                    chucDanh.IsDeleted = true;
                    _context.ChucDanhs.Update(chucDanh);
                    await _context.SaveChangesAsync();
                    ret = true;
                }
            }
            catch { }
            return ret;
        }

        public async Task<int> AddChucDanhAsync(ChucDanh chucDanh)
        {
            int ret = 0;
            try
            {
                await _context.ChucDanhs.AddAsync(chucDanh);
                await _context.SaveChangesAsync();
                ret = chucDanh.Ma_ChucDanh;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> UpdateChucDanhAsync(ChucDanh chucDanh)
        {
            int ret = 0;
            try
            {
                _context.ChucDanhs.Update(chucDanh);
                await _context.SaveChangesAsync();
                ret = chucDanh.Ma_ChucDanh;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
