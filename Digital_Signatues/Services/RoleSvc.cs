using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IRole
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role> GetRoleAsync(int id);
        Task<bool> DeleteRoleAsync(int id);
        Task<int> AddRoleAsync(Role role);
        Task<int> UpdateRoleAsync(Role role);
    }
    public class RoleSvc:IRole
    {
        private readonly DataContext _context;
        public RoleSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            List<Role> roles = new List<Role>();
            roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleAsync(int id)
        {
            Role role = new Role();
            role = await _context.Roles.Where(x =>x.Ma_Role == id).FirstOrDefaultAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            bool ret = false;
            try
            {
                List<NguoiDung_Role> nguoiDungs = new List<NguoiDung_Role>();
                nguoiDungs = await _context.NguoiDung_Roles.Where(x => x.Ma_Role == id).ToListAsync();
                foreach(var item in nguoiDungs)//xoas role của người dùng
                {
                    _context.NguoiDung_Roles.Remove(item);
                } 
                
                List<Role_Quyen> role_Quyens=new List<Role_Quyen>();
                role_Quyens=await _context.Role_Quyens.Where(x=>x.Ma_Role==id).ToListAsync();
                foreach(var item in role_Quyens)//xóa quyền của role
                {
                    _context.Role_Quyens.Remove(item);
                }

                Role role = new Role();
                role = await _context.Roles.Where(x => x.Ma_Role == id).FirstOrDefaultAsync();
                role.IsDeleted = true;
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch { }
            return ret;
        }

        public async Task<int> AddRoleAsync(Role role)
        {
            int ret = 0;
            try
            {
                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                ret = role.Ma_Role;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> UpdateRoleAsync(Role role)
        {
            int ret = 0;
            try
            {
                _context.Roles.Update(role);
                await _context.SaveChangesAsync();
                ret = role.Ma_Role;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
