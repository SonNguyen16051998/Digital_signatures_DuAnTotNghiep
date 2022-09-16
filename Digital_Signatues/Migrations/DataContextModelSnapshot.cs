﻿// <auto-generated />
using System;
using Digital_Signatues.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Digital_Signatues.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Digital_Signatues.Models.ChucDanh", b =>
                {
                    b.Property<int>("Ma_ChucDanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Oder")
                        .HasColumnType("int");

                    b.Property<string>("Ten_ChucDanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Ma_ChucDanh");

                    b.ToTable("ChucDanhs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySo", b =>
                {
                    b.Property<int>("Ma_KySo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Ma_NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Ten_KySo")
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ThoiDiem")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThuMuc")
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Ma_KySo");

                    b.HasIndex("Ma_NguoiTao");

                    b.ToTable("KySos");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoDeXuat", b =>
                {
                    b.Property<int>("Ma_KySoDeXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ma_KySo")
                        .HasColumnType("int");

                    b.Property<int>("Ma_KySoFile")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenFile")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Ma_KySoDeXuat");

                    b.HasIndex("Ma_KySo");

                    b.HasIndex("Ma_KySoFile");

                    b.HasIndex("Ma_NguoiDung");

                    b.ToTable("KySoDeXuats");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoFile", b =>
                {
                    b.Property<int>("Ma_KySoFile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("FlagKySo")
                        .HasColumnType("bit");

                    b.Property<string>("Gui")
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Json")
                        .HasColumnType("ntext");

                    b.Property<int>("Ma_KySo")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiKyCuoi")
                        .HasColumnType("int");

                    b.Property<int>("Ma_QRCode")
                        .HasColumnType("int");

                    b.Property<string>("NewGui")
                        .HasColumnType("nvarchar(55)");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenFile")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenFileMoi")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ThuMuc")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Ma_KySoFile");

                    b.HasIndex("Ma_KySo");

                    b.HasIndex("Ma_NguoiKyCuoi");

                    b.ToTable("KySoFiles");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoFileDetail", b =>
                {
                    b.Property<int>("Ma_KySoDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ma_KySo")
                        .HasColumnType("int");

                    b.Property<int>("Ma_KySoFile")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_ThongSo")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Ma_KySoDetail");

                    b.HasIndex("Ma_KySo");

                    b.HasIndex("Ma_KySoFile");

                    b.HasIndex("Ma_NguoiDung");

                    b.HasIndex("Ma_ThongSo");

                    b.ToTable("KySoFileDetails");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoLog", b =>
                {
                    b.Property<int>("Ma_KySoLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_Role")
                        .HasColumnType("int");

                    b.Property<int>("Ma_ThongSo")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Ma_KySoLog");

                    b.HasIndex("Ma_NguoiDung");

                    b.HasIndex("Ma_Role");

                    b.ToTable("KySoLogs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoNguoiDuyet", b =>
                {
                    b.Property<int>("Idex_NguoiDuyet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ma_KySo")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiTao")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SoThuTu")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("ThaoTac")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Idex_NguoiDuyet");

                    b.HasIndex("Ma_KySo");

                    b.HasIndex("Ma_NguoiDung");

                    b.HasIndex("Ma_NguoiTao");

                    b.ToTable("KySoNguoiDuyets");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoQuyTrinh", b =>
                {
                    b.Property<int>("Ma_kySoQuyTrinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_PhongBan")
                        .HasColumnType("int");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.Property<string>("TenQuyTrinh")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Ma_kySoQuyTrinh");

                    b.HasIndex("Ma_NguoiDung");

                    b.HasIndex("Ma_PhongBan");

                    b.ToTable("KySoQuyTrinhs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoThongSo", b =>
                {
                    b.Property<int>("Ma_KySoThongSo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hinh1")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Hinh2")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Hinh3")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Hinh4")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Hinh5")
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LastTrySign")
                        .HasColumnType("datetime2");

                    b.Property<string>("LyDoMacDinh")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiKyThu")
                        .HasColumnType("int");

                    b.Property<int>("Ma_NguoiUpDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChuKyHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassCode")
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Serial")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TieuDe1")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TieuDe2")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TieuDe3")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TieuDe4")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TieuDe5")
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Ma_KySoThongSo");

                    b.HasIndex("Ma_NguoiDung");

                    b.HasIndex("Ma_NguoiKyThu");

                    b.HasIndex("Ma_NguoiUpDate");

                    b.ToTable("KySoThongSos");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoThongSoHinh", b =>
                {
                    b.Property<int>("Ma_ThongSoHinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Ma_ThongSo")
                        .HasColumnType("int");

                    b.Property<string>("TenHinh")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Ma_ThongSoHinh");

                    b.HasIndex("Ma_ThongSo");

                    b.ToTable("KySoThongSoHinhs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoVungKy", b =>
                {
                    b.Property<int>("Ma_KySoVungKy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Json")
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Ma_KySoVungKy");

                    b.HasIndex("Ma_NguoiDung");

                    b.ToTable("KySoVungKys");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung", b =>
                {
                    b.Property<int>("Ma_NguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Block")
                        .HasColumnType("bit");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Ma_ChucDanh")
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Ma_NguoiDung");

                    b.HasIndex("Ma_ChucDanh")
                        .IsUnique();

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_PhongBan", b =>
                {
                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_PhongBan")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("Date");

                    b.HasKey("Ma_NguoiDung", "Ma_PhongBan");

                    b.HasIndex("Ma_PhongBan");

                    b.ToTable("NguoiDung_PhongBans");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_Quyen", b =>
                {
                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_Quyen")
                        .HasColumnType("int");

                    b.HasKey("Ma_NguoiDung", "Ma_Quyen");

                    b.HasIndex("Ma_Quyen");

                    b.ToTable("NguoiDung_Quyens");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_Role", b =>
                {
                    b.Property<int>("Ma_NguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("Ma_Role")
                        .HasColumnType("int");

                    b.HasKey("Ma_NguoiDung", "Ma_Role");

                    b.HasIndex("Ma_Role");

                    b.ToTable("NguoiDung_Roles");
                });

            modelBuilder.Entity("Digital_Signatues.Models.OTP", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Otp")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<bool>("isUse")
                        .HasColumnType("bit");

                    b.HasKey("email");

                    b.ToTable("OTPs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.PhongBan", b =>
                {
                    b.Property<int>("Ma_PhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("date");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Ten_PhongBan")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Ma_PhongBan");

                    b.ToTable("PhongBans");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Quyen", b =>
                {
                    b.Property<int>("Ma_Quyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ten_Quyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Ma_Quyen");

                    b.ToTable("Quyens");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Role", b =>
                {
                    b.Property<int>("Ma_Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Ten_Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Ma_Role");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Role_Quyen", b =>
                {
                    b.Property<int>("Ma_Role")
                        .HasColumnType("int");

                    b.Property<int>("Ma_Quyen")
                        .HasColumnType("int");

                    b.HasKey("Ma_Role", "Ma_Quyen");

                    b.HasIndex("Ma_Quyen");

                    b.ToTable("Role_Quyens");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySo", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySos")
                        .HasForeignKey("Ma_NguoiTao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoDeXuat", b =>
                {
                    b.HasOne("Digital_Signatues.Models.KySo", "KySo")
                        .WithMany("KySoDeXuats")
                        .HasForeignKey("Ma_KySo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.KySoFile", "KySoFile")
                        .WithMany("KySoDeXuats")
                        .HasForeignKey("Ma_KySoFile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoDeXuats")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KySo");

                    b.Navigation("KySoFile");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoFile", b =>
                {
                    b.HasOne("Digital_Signatues.Models.KySo", "KySo")
                        .WithMany("KySoFiles")
                        .HasForeignKey("Ma_KySo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoFile")
                        .HasForeignKey("Ma_NguoiKyCuoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KySo");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoFileDetail", b =>
                {
                    b.HasOne("Digital_Signatues.Models.KySo", "KySo")
                        .WithMany("KySoFileDetails")
                        .HasForeignKey("Ma_KySo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.KySoFile", "KySoFile")
                        .WithMany("KySoFileDetails")
                        .HasForeignKey("Ma_KySoFile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoFileDetail")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.KySoThongSo", "KySoThongSo")
                        .WithMany("KySoFileDetails")
                        .HasForeignKey("Ma_ThongSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KySo");

                    b.Navigation("KySoFile");

                    b.Navigation("KySoThongSo");

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoLog", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoLog")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.Role", "Role")
                        .WithMany("KySoLogs")
                        .HasForeignKey("Ma_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoNguoiDuyet", b =>
                {
                    b.HasOne("Digital_Signatues.Models.KySo", "KySo")
                        .WithMany("KySoNguoiDuyets")
                        .HasForeignKey("Ma_KySo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoNguoiDuyet_Dungs")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiTao")
                        .WithMany("KySoNguoiDuyet_Taos")
                        .HasForeignKey("Ma_NguoiTao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KySo");

                    b.Navigation("NguoiDung");

                    b.Navigation("NguoiTao");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoQuyTrinh", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("kySoQuyTrinhs")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.PhongBan", "PhongBan")
                        .WithMany("KySoQuyTrinhs")
                        .HasForeignKey("Ma_PhongBan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoThongSo", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoThongSo_NguoiDung")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiKyThu")
                        .WithMany("KySoThongSo_NguoiKyThu")
                        .HasForeignKey("Ma_NguoiKyThu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiUpdate")
                        .WithMany("KySoThongSo_NguoiUpdate")
                        .HasForeignKey("Ma_NguoiUpDate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("NguoiKyThu");

                    b.Navigation("NguoiUpdate");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoThongSoHinh", b =>
                {
                    b.HasOne("Digital_Signatues.Models.KySoThongSo", "KySoThongSo")
                        .WithMany("KySoThongSoHinhs")
                        .HasForeignKey("Ma_ThongSo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KySoThongSo");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoVungKy", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("KySoVungKy")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung", b =>
                {
                    b.HasOne("Digital_Signatues.Models.ChucDanh", "ChucDanh")
                        .WithOne("NguoiDung")
                        .HasForeignKey("Digital_Signatues.Models.NguoiDung", "Ma_ChucDanh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucDanh");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_PhongBan", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("NguoiDung_PhongBan")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.PhongBan", "PhongBan")
                        .WithMany("NguoiDung_PhongBan")
                        .HasForeignKey("Ma_PhongBan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_Quyen", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("NguoiDung_Quyens")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.Quyen", "Quyen")
                        .WithMany("NguoiDung_Quyens")
                        .HasForeignKey("Ma_Quyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Quyen");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung_Role", b =>
                {
                    b.HasOne("Digital_Signatues.Models.NguoiDung", "NguoiDung")
                        .WithMany("NguoiDung_Role")
                        .HasForeignKey("Ma_NguoiDung")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.Role", "Role")
                        .WithMany("NguoiDung_Role")
                        .HasForeignKey("Ma_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Role_Quyen", b =>
                {
                    b.HasOne("Digital_Signatues.Models.Quyen", "Quyen")
                        .WithMany("Role_Quyen")
                        .HasForeignKey("Ma_Quyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digital_Signatues.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Ma_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyen");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Digital_Signatues.Models.ChucDanh", b =>
                {
                    b.Navigation("NguoiDung");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySo", b =>
                {
                    b.Navigation("KySoDeXuats");

                    b.Navigation("KySoFileDetails");

                    b.Navigation("KySoFiles");

                    b.Navigation("KySoNguoiDuyets");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoFile", b =>
                {
                    b.Navigation("KySoDeXuats");

                    b.Navigation("KySoFileDetails");
                });

            modelBuilder.Entity("Digital_Signatues.Models.KySoThongSo", b =>
                {
                    b.Navigation("KySoFileDetails");

                    b.Navigation("KySoThongSoHinhs");
                });

            modelBuilder.Entity("Digital_Signatues.Models.NguoiDung", b =>
                {
                    b.Navigation("KySoDeXuats");

                    b.Navigation("KySoFile");

                    b.Navigation("KySoFileDetail");

                    b.Navigation("KySoLog");

                    b.Navigation("KySoNguoiDuyet_Dungs");

                    b.Navigation("KySoNguoiDuyet_Taos");

                    b.Navigation("kySoQuyTrinhs");

                    b.Navigation("KySos");

                    b.Navigation("KySoThongSo_NguoiDung");

                    b.Navigation("KySoThongSo_NguoiKyThu");

                    b.Navigation("KySoThongSo_NguoiUpdate");

                    b.Navigation("KySoVungKy");

                    b.Navigation("NguoiDung_PhongBan");

                    b.Navigation("NguoiDung_Quyens");

                    b.Navigation("NguoiDung_Role");
                });

            modelBuilder.Entity("Digital_Signatues.Models.PhongBan", b =>
                {
                    b.Navigation("KySoQuyTrinhs");

                    b.Navigation("NguoiDung_PhongBan");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Quyen", b =>
                {
                    b.Navigation("NguoiDung_Quyens");

                    b.Navigation("Role_Quyen");
                });

            modelBuilder.Entity("Digital_Signatues.Models.Role", b =>
                {
                    b.Navigation("KySoLogs");

                    b.Navigation("NguoiDung_Role");
                });
#pragma warning restore 612, 618
        }
    }
}
