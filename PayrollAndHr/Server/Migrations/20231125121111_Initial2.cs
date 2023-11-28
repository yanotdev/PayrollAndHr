using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollAndHr.Server.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogin",
                table: "tblUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogin",
                table: "tblUser");
        }
    }
}
