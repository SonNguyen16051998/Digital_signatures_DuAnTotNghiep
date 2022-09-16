using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Signatues.Migrations
{
    public partial class digital_signatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucDanhs",
                columns: table => new
                {
                    Ma_ChucDanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_ChucDanh = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Oder = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucDanhs", x => x.Ma_ChucDanh);
                });

            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Otp = table.Column<string>(type: "varchar(6)", nullable: true),
                    expiredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isUse = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Ma_PhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_PhongBan = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "date", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Ma_PhongBan);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    Ma_Quyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Quyen = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.Ma_Quyen);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Ma_Role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten_Role = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Ma_Role);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(40)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Sdt = table.Column<string>(type: "varchar(15)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ma_ChucDanh = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false),
                    Block = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.Ma_NguoiDung);
                    table.ForeignKey(
                        name: "FK_NguoiDungs_ChucDanhs_Ma_ChucDanh",
                        column: x => x.Ma_ChucDanh,
                        principalTable: "ChucDanhs",
                        principalColumn: "Ma_ChucDanh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role_Quyens",
                columns: table => new
                {
                    Ma_Role = table.Column<int>(type: "int", nullable: false),
                    Ma_Quyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Quyens", x => new { x.Ma_Role, x.Ma_Quyen });
                    table.ForeignKey(
                        name: "FK_Role_Quyens_Quyens_Ma_Quyen",
                        column: x => x.Ma_Quyen,
                        principalTable: "Quyens",
                        principalColumn: "Ma_Quyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Quyens_Roles_Ma_Role",
                        column: x => x.Ma_Role,
                        principalTable: "Roles",
                        principalColumn: "Ma_Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySoLogs",
                columns: table => new
                {
                    Ma_KySoLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Ma_Role = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ma_ThongSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoLogs", x => x.Ma_KySoLog);
                    table.ForeignKey(
                        name: "FK_KySoLogs_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoLogs_Roles_Ma_Role",
                        column: x => x.Ma_Role,
                        principalTable: "Roles",
                        principalColumn: "Ma_Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySoQuyTrinhs",
                columns: table => new
                {
                    Ma_kySoQuyTrinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyTrinh = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Ma_PhongBan = table.Column<int>(type: "int", nullable: false),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    STT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoQuyTrinhs", x => x.Ma_kySoQuyTrinh);
                    table.ForeignKey(
                        name: "FK_KySoQuyTrinhs_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoQuyTrinhs_PhongBans_Ma_PhongBan",
                        column: x => x.Ma_PhongBan,
                        principalTable: "PhongBans",
                        principalColumn: "Ma_PhongBan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySos",
                columns: table => new
                {
                    Ma_KySo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NguoiTao = table.Column<int>(type: "int", nullable: false),
                    ThuMuc = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ThoiDiem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ten_KySo = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySos", x => x.Ma_KySo);
                    table.ForeignKey(
                        name: "FK_KySos_NguoiDungs_Ma_NguoiTao",
                        column: x => x.Ma_NguoiTao,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySoThongSos",
                columns: table => new
                {
                    Ma_KySoThongSo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Hinh1 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Hinh2 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Hinh3 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Hinh4 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Hinh5 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    LyDoMacDinh = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    PassCode = table.Column<string>(type: "nvarchar(55)", nullable: true),
                    Ma_NguoiUpDate = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(55)", nullable: true),
                    NgayChuKyHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    LastTrySign = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ma_NguoiKyThu = table.Column<int>(type: "int", nullable: false),
                    TieuDe1 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TieuDe2 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TieuDe3 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TieuDe4 = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TieuDe5 = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoThongSos", x => x.Ma_KySoThongSo);
                    table.ForeignKey(
                        name: "FK_KySoThongSos_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoThongSos_NguoiDungs_Ma_NguoiKyThu",
                        column: x => x.Ma_NguoiKyThu,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KySoThongSos_NguoiDungs_Ma_NguoiUpDate",
                        column: x => x.Ma_NguoiUpDate,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KySoVungKys",
                columns: table => new
                {
                    Ma_KySoVungKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Json = table.Column<string>(type: "nvarchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoVungKys", x => x.Ma_KySoVungKy);
                    table.ForeignKey(
                        name: "FK_KySoVungKys_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung_PhongBans",
                columns: table => new
                {
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Ma_PhongBan = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung_PhongBans", x => new { x.Ma_NguoiDung, x.Ma_PhongBan });
                    table.ForeignKey(
                        name: "FK_NguoiDung_PhongBans_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_PhongBans_PhongBans_Ma_PhongBan",
                        column: x => x.Ma_PhongBan,
                        principalTable: "PhongBans",
                        principalColumn: "Ma_PhongBan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung_Quyens",
                columns: table => new
                {
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Ma_Quyen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung_Quyens", x => new { x.Ma_NguoiDung, x.Ma_Quyen });
                    table.ForeignKey(
                        name: "FK_NguoiDung_Quyens_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_Quyens_Quyens_Ma_Quyen",
                        column: x => x.Ma_Quyen,
                        principalTable: "Quyens",
                        principalColumn: "Ma_Quyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung_Roles",
                columns: table => new
                {
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Ma_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung_Roles", x => new { x.Ma_NguoiDung, x.Ma_Role });
                    table.ForeignKey(
                        name: "FK_NguoiDung_Roles_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDung_Roles_Roles_Ma_Role",
                        column: x => x.Ma_Role,
                        principalTable: "Roles",
                        principalColumn: "Ma_Role",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySoFiles",
                columns: table => new
                {
                    Ma_KySoFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_KySo = table.Column<int>(type: "int", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TenFileMoi = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ThuMuc = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Gui = table.Column<string>(type: "nvarchar(55)", nullable: true),
                    NewGui = table.Column<string>(type: "nvarchar(55)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    FlagKySo = table.Column<bool>(type: "bit", nullable: false),
                    Ma_NguoiKyCuoi = table.Column<int>(type: "int", nullable: false),
                    SignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Json = table.Column<string>(type: "ntext", nullable: true),
                    Ma_QRCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoFiles", x => x.Ma_KySoFile);
                    table.ForeignKey(
                        name: "FK_KySoFiles_KySos_Ma_KySo",
                        column: x => x.Ma_KySo,
                        principalTable: "KySos",
                        principalColumn: "Ma_KySo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoFiles_NguoiDungs_Ma_NguoiKyCuoi",
                        column: x => x.Ma_NguoiKyCuoi,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KySoNguoiDuyets",
                columns: table => new
                {
                    Idex_NguoiDuyet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_KySo = table.Column<int>(type: "int", nullable: false),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SoThuTu = table.Column<int>(type: "int", nullable: false),
                    ThaoTac = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Ma_NguoiTao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoNguoiDuyets", x => x.Idex_NguoiDuyet);
                    table.ForeignKey(
                        name: "FK_KySoNguoiDuyets_KySos_Ma_KySo",
                        column: x => x.Ma_KySo,
                        principalTable: "KySos",
                        principalColumn: "Ma_KySo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoNguoiDuyets_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KySoNguoiDuyets_NguoiDungs_Ma_NguoiTao",
                        column: x => x.Ma_NguoiTao,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KySoThongSoHinhs",
                columns: table => new
                {
                    Ma_ThongSoHinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_ThongSo = table.Column<int>(type: "int", nullable: false),
                    TenHinh = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoThongSoHinhs", x => x.Ma_ThongSoHinh);
                    table.ForeignKey(
                        name: "FK_KySoThongSoHinhs_KySoThongSos_Ma_ThongSo",
                        column: x => x.Ma_ThongSo,
                        principalTable: "KySoThongSos",
                        principalColumn: "Ma_KySoThongSo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KySoDeXuats",
                columns: table => new
                {
                    Ma_KySoDeXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_KySo = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ma_KySoFile = table.Column<int>(type: "int", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoDeXuats", x => x.Ma_KySoDeXuat);
                    table.ForeignKey(
                        name: "FK_KySoDeXuats_KySoFiles_Ma_KySoFile",
                        column: x => x.Ma_KySoFile,
                        principalTable: "KySoFiles",
                        principalColumn: "Ma_KySoFile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoDeXuats_KySos_Ma_KySo",
                        column: x => x.Ma_KySo,
                        principalTable: "KySos",
                        principalColumn: "Ma_KySo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KySoDeXuats_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KySoFileDetails",
                columns: table => new
                {
                    Ma_KySoDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_KySo = table.Column<int>(type: "int", nullable: false),
                    Ma_KySoFile = table.Column<int>(type: "int", nullable: false),
                    Ma_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    Ma_ThongSo = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoFileDetails", x => x.Ma_KySoDetail);
                    table.ForeignKey(
                        name: "FK_KySoFileDetails_KySoFiles_Ma_KySoFile",
                        column: x => x.Ma_KySoFile,
                        principalTable: "KySoFiles",
                        principalColumn: "Ma_KySoFile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KySoFileDetails_KySos_Ma_KySo",
                        column: x => x.Ma_KySo,
                        principalTable: "KySos",
                        principalColumn: "Ma_KySo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KySoFileDetails_KySoThongSos_Ma_ThongSo",
                        column: x => x.Ma_ThongSo,
                        principalTable: "KySoThongSos",
                        principalColumn: "Ma_KySoThongSo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KySoFileDetails_NguoiDungs_Ma_NguoiDung",
                        column: x => x.Ma_NguoiDung,
                        principalTable: "NguoiDungs",
                        principalColumn: "Ma_NguoiDung",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KySoDeXuats_Ma_KySo",
                table: "KySoDeXuats",
                column: "Ma_KySo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoDeXuats_Ma_KySoFile",
                table: "KySoDeXuats",
                column: "Ma_KySoFile");

            migrationBuilder.CreateIndex(
                name: "IX_KySoDeXuats_Ma_NguoiDung",
                table: "KySoDeXuats",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFileDetails_Ma_KySo",
                table: "KySoFileDetails",
                column: "Ma_KySo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFileDetails_Ma_KySoFile",
                table: "KySoFileDetails",
                column: "Ma_KySoFile");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFileDetails_Ma_NguoiDung",
                table: "KySoFileDetails",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFileDetails_Ma_ThongSo",
                table: "KySoFileDetails",
                column: "Ma_ThongSo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFiles_Ma_KySo",
                table: "KySoFiles",
                column: "Ma_KySo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoFiles_Ma_NguoiKyCuoi",
                table: "KySoFiles",
                column: "Ma_NguoiKyCuoi");

            migrationBuilder.CreateIndex(
                name: "IX_KySoLogs_Ma_NguoiDung",
                table: "KySoLogs",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoLogs_Ma_Role",
                table: "KySoLogs",
                column: "Ma_Role");

            migrationBuilder.CreateIndex(
                name: "IX_KySoNguoiDuyets_Ma_KySo",
                table: "KySoNguoiDuyets",
                column: "Ma_KySo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoNguoiDuyets_Ma_NguoiDung",
                table: "KySoNguoiDuyets",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoNguoiDuyets_Ma_NguoiTao",
                table: "KySoNguoiDuyets",
                column: "Ma_NguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KySoQuyTrinhs_Ma_NguoiDung",
                table: "KySoQuyTrinhs",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoQuyTrinhs_Ma_PhongBan",
                table: "KySoQuyTrinhs",
                column: "Ma_PhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_KySos_Ma_NguoiTao",
                table: "KySos",
                column: "Ma_NguoiTao");

            migrationBuilder.CreateIndex(
                name: "IX_KySoThongSoHinhs_Ma_ThongSo",
                table: "KySoThongSoHinhs",
                column: "Ma_ThongSo");

            migrationBuilder.CreateIndex(
                name: "IX_KySoThongSos_Ma_NguoiDung",
                table: "KySoThongSos",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_KySoThongSos_Ma_NguoiKyThu",
                table: "KySoThongSos",
                column: "Ma_NguoiKyThu");

            migrationBuilder.CreateIndex(
                name: "IX_KySoThongSos_Ma_NguoiUpDate",
                table: "KySoThongSos",
                column: "Ma_NguoiUpDate");

            migrationBuilder.CreateIndex(
                name: "IX_KySoVungKys_Ma_NguoiDung",
                table: "KySoVungKys",
                column: "Ma_NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_PhongBans_Ma_PhongBan",
                table: "NguoiDung_PhongBans",
                column: "Ma_PhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_Quyens_Ma_Quyen",
                table: "NguoiDung_Quyens",
                column: "Ma_Quyen");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_Roles_Ma_Role",
                table: "NguoiDung_Roles",
                column: "Ma_Role");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_Ma_ChucDanh",
                table: "NguoiDungs",
                column: "Ma_ChucDanh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Quyens_Ma_Quyen",
                table: "Role_Quyens",
                column: "Ma_Quyen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KySoDeXuats");

            migrationBuilder.DropTable(
                name: "KySoFileDetails");

            migrationBuilder.DropTable(
                name: "KySoLogs");

            migrationBuilder.DropTable(
                name: "KySoNguoiDuyets");

            migrationBuilder.DropTable(
                name: "KySoQuyTrinhs");

            migrationBuilder.DropTable(
                name: "KySoThongSoHinhs");

            migrationBuilder.DropTable(
                name: "KySoVungKys");

            migrationBuilder.DropTable(
                name: "NguoiDung_PhongBans");

            migrationBuilder.DropTable(
                name: "NguoiDung_Quyens");

            migrationBuilder.DropTable(
                name: "NguoiDung_Roles");

            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.DropTable(
                name: "Role_Quyens");

            migrationBuilder.DropTable(
                name: "KySoFiles");

            migrationBuilder.DropTable(
                name: "KySoThongSos");

            migrationBuilder.DropTable(
                name: "PhongBans");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "KySos");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "ChucDanhs");
        }
    }
}
