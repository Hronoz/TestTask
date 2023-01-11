using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TestTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllTime = table.Column<int>(type: "int", nullable: false),
                    FirstOperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageTime = table.Column<double>(type: "float", nullable: false),
                    AverageValue = table.Column<double>(type: "float", nullable: false),
                    MedianValue = table.Column<double>(type: "float", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    RowQty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
