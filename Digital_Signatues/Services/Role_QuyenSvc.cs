using Digital_Signatues.Models;
using Digital_Signatues.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IRole_Quyen
    {
        Task<bool> AddOrUpdateRole_QuyenAsync(PostRole_Quyen role_Quyens);
        Task<bool> DeleteAlNothavelRole_QuyenAsync(int id_role);
        Task<List<Role_Quyen>> GetRole_QuyensAsync(int id_role);//Hiển thị toàn bộ quyền đã có của role
        Task<List<Quyen>> GetRoleQuyenNotHaveAsync(int id_role);//lấy các quyền mà role chưa có
    }
    public class Role_QuyenSvc:IRole_Quyen
    {
        private readonly DataContext _context;
        public Role_QuyenSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdateRole_QuyenAsync(PostRole_Quyen role_Quyens)
        {
            bool ret = false;
            try
            {
                foreach(var item in role_Quyens.Quyens)
                {
                    var role_quyen = new Role_Quyen()
                    {
                        Ma_Quyen = item.id_Quyen,
                        Ma_Role = role_Quyens.Id_Role
                    };
                    await _context.Role_Quyens.AddAsync(role_quyen);
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
        public async Task<bool> DeleteAlNothavelRole_QuyenAsync(int id_role)
        {
            bool ret = false;
            try
            {
                var role_quyen=await _context.Role_Quyens.Where(x=>x.Ma_Role==id_role).ToListAsync();
                if(role_quyen.Count>0)
                {
                    foreach (var role in role_quyen)
                    {
                        _context.Role_Quyens.Remove(role);
                    }
                    await _context.SaveChangesAsync();
                }    
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public async Task<List<Role_Quyen>> GetRole_QuyensAsync(int id_Role)
        {
            List<Role_Quyen> Role_Quyens = new List<Role_Quyen>();
            Role_Quyens = await _context.Role_Quyens.Where(x => x.Ma_Role == id_Role)
                            .Include(x => x.Quyen).ToListAsync();
            return Role_Quyens;
        }

        public async Task<List<Quyen>> GetRoleQuyenNotHaveAsync(int id_Role)
        {
            List<Role_Quyen> Role_Quyens = new List<Role_Quyen>();
            Role_Quyens = await _context.Role_Quyens.Where(x => x.Ma_Role == id_Role)
                                .ToListAsync();
            List<int> id_Quyen = new List<int>();
            id_Quyen = (from p in Role_Quyens
                       select p.Ma_Quyen).ToList();
            List<Quyen> quyens = new List<Quyen>();
            quyens = await _context.Quyens.Where(x => !id_Quyen.Contains(x.Ma_Quyen)).ToListAsync();
            return quyens;
        }
    }
}
