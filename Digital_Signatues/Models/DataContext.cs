using Microsoft.EntityFrameworkCore;

namespace Digital_Signatues.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //ràng buộc 2 khóa chính  1 bảng cần sử dụng fluent API
            model.Entity<NguoiDung_PhongBan>().HasKey(e => new { e.Ma_NguoiDung, e.Ma_PhongBan });

            model.Entity<NguoiDung_Role>().HasKey(e => new { e.Ma_NguoiDung, e.Ma_Role });

            model.Entity<Role_Quyen>().HasKey(e => new { e.Ma_Role, e.Ma_Quyen });

            model.Entity<NguoiDung_Quyen>().HasKey(e => new { e.Ma_NguoiDung, e.Ma_Quyen });

            model.Entity<NguoiDung>()
                        .HasMany(p => p.KySoNguoiDuyet_Dungs)
                        .WithOne(c => c.NguoiDung) // Different here
                        .HasForeignKey(c => new { c.Ma_NguoiDung });

            model.Entity<NguoiDung>()
                        .HasMany(p => p.KySoNguoiDuyet_Taos)
                        .WithOne(c => c.NguoiTao) // Different here
                        .HasForeignKey(c => new { c.Ma_NguoiTao });


            model.Entity<NguoiDung>()
                        .HasMany(p => p.KySoThongSo_NguoiDung)
                        .WithOne(c => c.NguoiDung) // Different here
                        .HasForeignKey(c => new { c.Ma_NguoiDung });

            model.Entity<NguoiDung>()
                       .HasMany(p => p.KySoThongSo_NguoiKyThu)
                       .WithOne(c => c.NguoiKyThu) // Different here
                       .HasForeignKey(c => new { c.Ma_NguoiKyThu });

            model.Entity<NguoiDung>()
                      .HasMany(p => p.KySoThongSo_NguoiUpdate)
                      .WithOne(c => c.NguoiUpdate) // Different here
                      .HasForeignKey(c => new { c.Ma_NguoiUpDate });
        }

        public DbSet<ChucDanh> ChucDanhs { get; set; }
        public DbSet<KySo> KySos { get; set; }
        public DbSet<KySoDeXuat> KySoDeXuats { get; set; }
        public DbSet<KySoFile> KySoFiles { get; set;}
        public DbSet<KySoFileDetail> KySoFileDetails { get; set; }
        public DbSet<KySoLog> KySoLogs { get; set; }
        public DbSet<KySoNguoiDuyet> KySoNguoiDuyets { get; set; }
        public DbSet<KySoQuyTrinh> KySoQuyTrinhs { get; set; }
        public DbSet<KySoThongSo> KySoThongSos { get; set; }
        public DbSet<KySoThongSoHinh> KySoThongSoHinhs { get; set; }
        public DbSet<KySoVungKy> KySoVungKys { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NguoiDung_PhongBan> NguoiDung_PhongBans { get; set; }
        public DbSet<NguoiDung_Quyen> NguoiDung_Quyens { get; set; }
        public DbSet<NguoiDung_Role> NguoiDung_Roles { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Role_Quyen> Role_Quyens { get; set; }
        public DbSet<OTP> OTPs { get; set; }
    }
}
