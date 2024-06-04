using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepoLayer.Migrations
{
    /// <inheritdoc />
    public partial class CustomerChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customers",
                newName: "phone");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FName",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "email",
                table: "customers");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "customers",
                newName: "Name");
        }
    }
}
