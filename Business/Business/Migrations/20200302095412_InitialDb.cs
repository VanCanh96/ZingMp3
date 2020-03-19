using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Business.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(maxLength: 1, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    VipId = table.Column<int>(maxLength: 1, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Vips_VipId",
                        column: x => x.VipId,
                        principalTable: "Vips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, "Nam", null, null },
                    { 2, new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, "Nữ", null, null }
                });

            migrationBuilder.InsertData(
                table: "Vips",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, "Vip 1", null, null },
                    { 2, new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, "Vip 2", null, null },
                    { 99, new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, "Master", null, null }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Address", "CreateAt", "CreateBy", "DateOfBirth", "GenderId", "IsActive", "Name", "Password", "UpdateAt", "UpdateBy", "UserName", "VipId" },
                values: new object[] { 1, "Đà Nẵng", new DateTime(2020, 3, 2, 9, 54, 12, 214, DateTimeKind.Utc), 0, new DateTime(1996, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Admin", "123456", null, null, "admin", 99 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_GenderId",
                table: "Accounts",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_VipId",
                table: "Accounts",
                column: "VipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Vips");
        }
    }
}
