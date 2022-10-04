using Microsoft.EntityFrameworkCore.Migrations;

namespace WEA.Persistance.Migrations
{
    public partial class tbl_child_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "TblChildren",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "TblChildren");
        }
    }
}
