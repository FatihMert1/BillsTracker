using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Api.Migrations
{
    public partial class CreateBillsAndCategoryReleations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bills_tracker");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "bills_tracker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    title = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                schema: "bills_tracker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    price = table.Column<float>(type: "float(10,2)", nullable: false),
                    category_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.id);
                    table.ForeignKey(
                        name: "FK_bills_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "bills_tracker",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bills_category_id",
                schema: "bills_tracker",
                table: "bills",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bills",
                schema: "bills_tracker");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "bills_tracker");
        }
    }
}
