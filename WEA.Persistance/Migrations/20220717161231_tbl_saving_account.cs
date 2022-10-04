using Microsoft.EntityFrameworkCore.Migrations;

namespace WEA.Persistance.Migrations
{
    public partial class tbl_saving_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "TblSavingAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "TblSavingAccount");
        }
    }
}
