﻿using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Signatues.Services
{
    public interface IRole_Quyen
    {
        Task<bool> AddOrUpdateRole_QuyenAsync(List<Role_Quyen> role_Quyens);
        Task<bool> DeleteAlNothavelRole_QuyenAsync(List<Role_Quyen> role_Quyens);
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
        public async Task<bool> AddOrUpdateRole_QuyenAsync(List<Role_Quyen> role_Quyens)
        {
            bool ret = false;
            try
            {
                List<NguoiDung_Role> nguoiDung_Role = new List<NguoiDung_Role>();
                //lấy các id người dùng có role đang chọn
                nguoiDung_Role = await _context.NguoiDung_Roles.Where(x => x.Ma_Role == role_Quyens[0].Ma_Role).ToListAsync();
                foreach (var item in role_Quyens)
                {
                    Role_Quyen role_Quyen = new Role_Quyen();
                    role_Quyen=await _context.Role_Quyens.Where(x=>x.Ma_Role==item.Ma_Role && x.Ma_Quyen==item.Ma_Quyen)
                            .FirstOrDefaultAsync();
                    if(role_Quyen!=null)//kiểm tra quyền đó đã có chưa
                    {
                        continue;
                    }
                    else//chưa có thì thêm vào cho role
                    {
                        await _context.Role_Quyens.AddAsync(item);
                        foreach (var nguoidung_Role in nguoiDung_Role)
                        {
                            NguoiDung_Quyen nd_quyen = new NguoiDung_Quyen();
                            nd_quyen=await _context.NguoiDung_Quyens.Where(x=>x.Ma_NguoiDung==nguoidung_Role.Ma_NguoiDung
                                        && x.Ma_Quyen==item.Ma_Quyen).FirstOrDefaultAsync();
                            if(nd_quyen!=null)
                            {
                                continue;
                            }
                            else
                            {
                                NguoiDung_Quyen nguoidung_quyen = new NguoiDung_Quyen()
                                {
                                    Ma_NguoiDung = nguoidung_Role.Ma_NguoiDung,
                                    Ma_Quyen = item.Ma_Quyen
                                };
                                await _context.NguoiDung_Quyens.AddAsync(nguoidung_quyen);
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
        public async Task<bool> DeleteAlNothavelRole_QuyenAsync(List<Role_Quyen> role_Quyens)
        {
            bool ret = false;
            try
            {
                List<Role_Quyen> role_Quyennothave = new List<Role_Quyen>();
                List<int> id_role_quyens = (from p in role_Quyens
                                               select p.Ma_Quyen).ToList();
                //lấy các quyền mà role bỏ đi và xóa nó
                role_Quyennothave = await _context.Role_Quyens.Where(x => !id_role_quyens.Contains(x.Ma_Quyen)
                                          && x.Ma_Role == role_Quyens[0].Ma_Role).ToListAsync();
                foreach (var item in role_Quyennothave)
                {
                    _context.Role_Quyens.Remove(item);
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
