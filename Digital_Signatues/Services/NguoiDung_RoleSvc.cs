using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface INguoiDung_Role
    {
        Task<bool> AddOrUpdateNguoiDung_RoleAsync(List<NguoiDung_Role> nguoiDung_Roles);
        Task<bool> DeleteAllRoleNotHaveNguoiDung_RoleAsync(List<NguoiDung_Role> nguoiDung_Roles);
        Task<List<NguoiDung_Role>> GetNguoiDung_RolesAsync(int id_nguoiDung);//Hiển thị toàn bộ role đã chọn của người dùng
        Task<List<Role>> GetRoleNguoiDungNotHaveAsync(int id_nguoiDung);//lấy các role mà người dùng chưa có
        Task<List<NguoiDung_Quyen>> GetNguoiDung_QuyensAsync(int id_nguoiDung);
    }
    public class NguoiDung_RoleSvc : INguoiDung_Role
    {
        private readonly DataContext _context;
        public NguoiDung_RoleSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdateNguoiDung_RoleAsync(List<NguoiDung_Role> nguoiDung_Roles)
        {
            bool ret = false;
            try
            {
                foreach(var item in nguoiDung_Roles)
                {
                    NguoiDung_Role nguoiDung_Role = new NguoiDung_Role();
                    nguoiDung_Role = await _context.NguoiDung_Roles.Where(x => x.Ma_NguoiDung == item.Ma_NguoiDung
                                      && x.Ma_Role == item.Ma_Role).FirstOrDefaultAsync();//
                    if(nguoiDung_Role != null)//kiểm tra người dùng đã có role này chưa
                    {
                        continue;
                    }
                    else//chưa có role sẽ thêm role vào cho người dùng
                    {
                        await _context.NguoiDung_Roles.AddAsync(item);
                        List<Role_Quyen> role_quyens = new List<Role_Quyen>();
                        //lấy toàn bộ quyền của role đang muốn thêm cho người dùng
                        role_quyens = await _context.Role_Quyens.Where(x => x.Ma_Role == item.Ma_Role).ToListAsync();
                        foreach (var role_quyen in role_quyens)
                        {
                            NguoiDung_Quyen nguoidung_Quyen=new NguoiDung_Quyen();
                            nguoidung_Quyen=await _context.NguoiDung_Quyens.Where(x=>x.Ma_NguoiDung==item.Ma_NguoiDung
                                            && x.Ma_Quyen==role_quyen.Ma_Quyen).FirstOrDefaultAsync();
                            if(nguoidung_Quyen!=null)//kiểm tra quyền này người dùng đã có chưa
                            {
                                continue;
                            }
                            else//chưa có thì thêm vào cho người dùng
                            {
                                NguoiDung_Quyen nd_quyen = new NguoiDung_Quyen();
                                nd_quyen = await _context.NguoiDung_Quyens.Where(x => x.Ma_NguoiDung == item.Ma_NguoiDung
                                              && x.Ma_Quyen == role_quyen.Ma_Quyen).FirstOrDefaultAsync();
                                if (nd_quyen != null)
                                {
                                    continue;
                                }
                                else
                                {
                                    NguoiDung_Quyen nguoiDung_Quyen = new NguoiDung_Quyen()
                                    {
                                        Ma_NguoiDung = item.Ma_NguoiDung,
                                        Ma_Quyen = role_quyen.Ma_Quyen
                                    };
                                    await _context.NguoiDung_Quyens.AddAsync(nguoiDung_Quyen);
                                }
                            }
                        }
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
        public async Task<bool> DeleteAllRoleNotHaveNguoiDung_RoleAsync(List<NguoiDung_Role> nguoiDung_Roles)
        {
            bool ret = false;
            try
            {
                List<NguoiDung_Role> nguoiDung_Rolenothave = new List<NguoiDung_Role>();
                List<int> id_NguoiDung_Role = (from p in nguoiDung_Roles
                                               select p.Ma_Role).ToList();
                //lấy các role mà người dùng bỏ đi và xóa nó
                nguoiDung_Rolenothave = await _context.NguoiDung_Roles.Where(x => !id_NguoiDung_Role.Contains(x.Ma_Role)
                                          && x.Ma_NguoiDung == nguoiDung_Roles[0].Ma_NguoiDung).ToListAsync();
                foreach (var item in nguoiDung_Rolenothave)
                {
                    _context.NguoiDung_Roles.Remove(item);
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

        public async Task<List<NguoiDung_Role>> GetNguoiDung_RolesAsync(int id_nguoiDung)
        {
            List<NguoiDung_Role> nguoiDung_Roles=new List<NguoiDung_Role>();
            nguoiDung_Roles=await _context.NguoiDung_Roles.Where(x=>x.Ma_NguoiDung==id_nguoiDung)
                            .Include(x=>x.Role).ToListAsync();
            return nguoiDung_Roles;
        }

        public async Task<List<Role>> GetRoleNguoiDungNotHaveAsync(int id_nguoiDung)
        {
            List<NguoiDung_Role> nguoiDung_Roles = new List<NguoiDung_Role>();
            nguoiDung_Roles = await _context.NguoiDung_Roles.Where(x => x.Ma_NguoiDung == id_nguoiDung)
                                .ToListAsync();
            List<int> Id_Role=new List<int>();
            Id_Role= (from p in nguoiDung_Roles
                      select p.Ma_Role).ToList();
            List<Role> roles=new List<Role>();
            roles=await _context.Roles.Where(x=>!Id_Role.Contains(x.Ma_Role)).ToListAsync();
            return roles;
        }

        public async Task<List<NguoiDung_Quyen>> GetNguoiDung_QuyensAsync(int id_nguoiDung)
        {
            List<NguoiDung_Quyen> nguoiDung_Quyens = new List<NguoiDung_Quyen>();
            nguoiDung_Quyens = await _context.NguoiDung_Quyens.Where(x => x.Ma_NguoiDung == id_nguoiDung)
                                .Include(x => x.Quyen)
                                .ToListAsync();
            return nguoiDung_Quyens;
        }
    }
}
