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
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Otp = table.Column<string>(type: "varchar(6)", nullable: false),
                    expiredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isUse = table.Column<bool>(type: "bit", nullable: false)
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
                    NgayTao = table.Column<DateTime>(type: "date", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Isdeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ma_ChucDanh = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false),
                    Block = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "KySoTests",
                columns: table => new
                {
                    Id_KySoTest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_NguoiDung = table.Column<int>(type: "int", nullable: false),
                    inputFile = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    imgSign = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    pageSign = table.Column<int>(type: "int", nullable: false),
                    x = table.Column<float>(type: "real", nullable: false),
                    y = table.Column<float>(type: "real", nullable: false),
                    img_w = table.Column<float>(type: "real", nullable: false),
                    img_h = table.Column<float>(type: "real", nullable: false),
                    NgayKyTest = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KySoTests", x => x.Id_KySoTest);
                    table.ForeignKey(
                        name: "FK_KySoTests_NguoiDungs_Id_NguoiDung",
                        column: x => x.Id_NguoiDung,
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
                    DateAdded = table.Column<DateTime>(type: "Date", nullable: false),
                    Ten_NguoiDung = table.Column<string>(type: "nvarchar(255)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_KySoTests_Id_NguoiDung",
                table: "KySoTests",
                column: "Id_NguoiDung");

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
                name: "KySoTests");

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
                name: "PhongBans");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ChucDanhs");
        }
    }
}
