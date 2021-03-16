using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentService_UsingConsul.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Batch", "Marks", "Name" },
                values: new object[] { 1, "B001", 90, "Ajay" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Batch", "Marks", "Name" },
                values: new object[] { 2, "B002", 98, "Deepak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
