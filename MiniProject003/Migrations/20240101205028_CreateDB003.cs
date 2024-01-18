using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject003.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiniProject003_Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject003_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiniProject003_Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject003_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiniProject003_PersonsNationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProject003_PersonsNationalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiniProject003_PersonsNationalities_MiniProject003_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "MiniProject003_Nationalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MiniProject003_PersonsNationalities_MiniProject003_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "MiniProject003_Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiniProject003_PersonsNationalities_NationalityId",
                table: "MiniProject003_PersonsNationalities",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_MiniProject003_PersonsNationalities_PersonId",
                table: "MiniProject003_PersonsNationalities",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiniProject003_PersonsNationalities");

            migrationBuilder.DropTable(
                name: "MiniProject003_Nationalities");

            migrationBuilder.DropTable(
                name: "MiniProject003_Persons");
        }
    }
}
